using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Threading;
using System.Timers;

namespace control
{
  
    public partial class Form1 : Form
    {
        public static float[,] theta = new float[3,2];
        public static float xr = 0, yr = 0, zr = 0;

        public static float[] destheta = new float[3];
        public static float xdes = 0, ydes = 0, zdes = 0;

        public static byte StartFrame=0;
        public static byte[] rc_buffer= new byte[5];       
        public static byte rc_count=0,stoping=0;
       

        public static float[,] pointtheta = new float[15,3];
        public static byte numpoint=0,numcode=0;
        public static uint[,] program = new uint[30, 3];
        public static uint count;
        public static byte buttonclick = 0,timerbutton=0;
        private Thread demorun = null;
        

        SerialPort _serialPort;
         // robot geometry
         // (look at pics above for explanation)
         const float e = 35;     // end effector
         const float f = 300;     // base
         const float re = 300;
         const float rf = 130;
 
         // trigonometric constants
         const float sqrt3 = (float)1.73205080756;
         const float pi = (float)3.141592653;    // PI
         const float sin120 = (float)sqrt3 / (float)2.0;
         const float cos120 = (float)-0.5;
         const float tan60 = (float)sqrt3;
         const float sin30 = (float)0.5;
         const float tan30 = 1 / sqrt3;
         
        //image process var
         private Thread imageprocess = null;
         private Capture capture;        //takes images from camera as image frames
         public static byte[] img_color = new byte[3];







        public Form1()
        {
            InitializeComponent();
            comportinit();
           // imageprocess = new Thread(new ThreadStart(this.imagezone));
          //  imageprocess.Start();

         
        }
   

        public void  comportinit()
        {

            _serialPort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();
        }

        public void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
       {
           SerialPort sp = (SerialPort)sender;
           int indata = sp.ReadByte();
           
           if (StartFrame == 1)
           {
               rc_buffer[rc_count] = (byte)indata;
               rc_count++;
           }
           if (rc_count == 5)
           {
               rc_count = 0;
               StartFrame = 0;
               float data = BitConverter.ToSingle(rc_buffer, 0);
               if ((rc_buffer[4] & 0x0f) < 3)
               {
                   if ((data < 0.01 & data > 0) | (data > -0.01 & data < 0))
                       data = 0;
                   if (data < 180 & data > -180)
                   {
                       theta[rc_buffer[4] & 0x0f, 0] = data;    // theta
                       theta[rc_buffer[4] & 0x0f, 1] = rc_buffer[4] >> 4; // done ramp
                   }
                   Array.Clear(rc_buffer, 0, 5);
               }
               sp.DiscardInBuffer();
           }
           if (indata == 100)
               StartFrame = 1;
    
       }

       
     private void senduart(byte func,float data)
        {
           
            int i;
            byte[] destheta1 = new byte[6];
            byte[] destheta1t = BitConverter.GetBytes(data);

            for (i = 4; i > 0; i--)
            {
                destheta1[i] = destheta1t[i - 1];
   
            }

            destheta1[0] = 200;
            destheta1[5] = func;
 
            _serialPort.Write(destheta1, 0, 6);
            _serialPort.DiscardOutBuffer();   
            

        }

   // kinematic for deltar robot//
        //================================================//
     public int delta_calcForward(float theta1, float theta2, float theta3, out float x0, out float y0, out float z0) 
    {
     float t = (f-e)*tan30/2;
     float dtr = pi / (float)180.0;
    theta1 = theta1 * dtr;
    theta2 = theta2 * dtr;
    theta3 = theta3 * dtr;
    x0 = y0 = z0 = 0;
    float y1 = -(t + rf * (float)Math.Cos(theta1));
    float z1 = -rf * (float)Math.Sin(theta1);

    float y2 = (t + rf * (float)Math.Cos(theta2)) * sin30;
     float x2 = y2*tan60;
     float z2 = -rf * (float)Math.Sin(theta2);

     float y3 = (t + rf * (float)Math.Cos(theta3)) * sin30;
     float x3 = -y3*tan60;
     float z3 = -rf * (float)Math.Sin(theta3);
 
     float dnm = (y2-y1)*x3-(y3-y1)*x2;
 
     float w1 = y1*y1 + z1*z1;
     float w2 = x2*x2 + y2*y2 + z2*z2;
     float w3 = x3*x3 + y3*y3 + z3*z3;
     
     // x = (a1*z + b1)/dnm
     float a1 = (z2-z1)*(y3-y1)-(z3-z1)*(y2-y1);
     float b1 = -((w2-w1)*(y3-y1)-(w3-w1)*(y2-y1))/2;
 
     // y = (a2*z + b2)/dnm;
     float a2 = -(z2-z1)*x3+(z3-z1)*x2;
     float b2 = ((w2-w1)*x3 - (w3-w1)*x2)/2;
 
     // a*z^2 + b*z + c = 0
     float a = a1*a1 + a2*a2 + dnm*dnm;
     float b = 2*(a1*b1 + a2*(b2-y1*dnm) - z1*dnm*dnm);
     float c = (b2-y1*dnm)*(b2-y1*dnm) + b1*b1 + dnm*dnm*(z1*z1 - re*re);
  
     // discriminant
     float d = b*b - (float)4.0*a*c;
     if (d < 0) return -1; // non-existing point
 
     z0 = -(float)0.5*(b+(float)Math.Sqrt(d))/a;
     x0 = (a1*z0 + b1)/dnm;
     y0 = (a2*z0 + b2)/dnm;
     return 0;
 }

     public int delta_calcAngleYZ(float x0t, float y0t, float z0t,out float temptheta) 
 {
     temptheta = 0;
     float y1 = -0.5f * 0.57735f * f; // f/2 * tg 30
      y0t=y0t - 0.5f * 0.57735f*e;    // shift center to edge
     // z = a + b*y
     float a = (x0t*x0t + y0t*y0t + z0t*z0t +rf*rf - re*re - y1*y1)/(2*z0t);
     float b = (y1-y0t)/z0t;
     // discriminant
     float d = -(a+b*y1)*(a+b*y1)+rf*(b*b*rf+rf); 
     if (d < 0) return -1; // non-existing point
     float yj = (y1 - a*b - (float)Math.Sqrt(d))/(b*b + 1); // choosing outer point
     float zj = a + b*yj;
     temptheta = 180.0f * (float)Math.Atan(-zj / (y1 - yj)) / pi +((yj > y1) ? 180.0f : 0.0f);
     return 0;
     
 }

 // inverse kinematics: (x0, y0, z0) -> (theta1, theta2, theta3)
 // returned status: 0=OK, -1=non-existing position
     int delta_calcInverse(float x0, float y0, float z0,out float theta1,out float theta2,out float theta3) {
     theta1 = theta2 = theta3 = 0;
         
     int status = delta_calcAngleYZ(x0, y0, z0,out theta1);
     if (status == 0) status = delta_calcAngleYZ(x0 * (float)Math.Cos(2 * pi / 3) + y0 * (float)Math.Sin(2 * pi / 3), y0 * (float)Math.Cos(2 * pi / 3) - x0 * (float)Math.Sin(2 * pi / 3), z0, out theta2);  // rotate coords to +120 deg
     if (status == 0) status = delta_calcAngleYZ(x0 * (float)Math.Cos(2 * pi / 3) - y0 * (float)Math.Sin(2 * pi / 3), y0 * (float)Math.Cos(2 * pi / 3) + x0 * (float)Math.Sin(2 * pi / 3), z0, out theta3);  // rotate coords to -120 deg
     return status;
 }
 // system event handler//
        //======================================================//
    

// button xyz
     private void Xi_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 1;
     }
     private void Xi_MouseUp(object sender, MouseEventArgs e)
     {
         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void Yi_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 2;
     }
     private void Yi_MouseUp(object sender, MouseEventArgs e)
     {
         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void Zi_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 3;
     }
     private void Zi_MouseUp(object sender, MouseEventArgs e)
     {
         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void Xd_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 4;
     }
     private void Xd_MouseUp(object sender, MouseEventArgs e)
     {
         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void Yd_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 5;
     }
     private void Yd_MouseUp(object sender, MouseEventArgs e)
     {
         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void Zd_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 6;
     }
     private void Zd_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     //theta button
     private void theta1i_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 7;
     }
     private void theta1i_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void theta2i_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 8;
     }
     private void theta2i_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void theta3i_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 9;
     }
     private void theta3i_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void theta1d_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 10;
     }
     private void theta1d_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void theta2d_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 11;
     }
     private void theta2d_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }
     private void theta3d_MouseDown(object sender, MouseEventArgs e)
     {

         timer2.Enabled = true;
         buttonclick = 12;
     }
     private void theta3d_MouseUp(object sender, MouseEventArgs e)
     {

         timer2.Enabled = false;
         buttonclick = 0;
     }

// timer for button
     private void timer2_Tick(object sender, EventArgs e)
     {
         int i = 0;
         float[] destheta1 = new float[3];
         if (buttonclick <= 6)
         {
            delta_calcForward(destheta[0], destheta[1], destheta[2], out xdes,out ydes,out zdes);
            
             switch(buttonclick)
             {
                 case 1: xdes++; break;                  
                 case 2: ydes++; break;    
                 case 3: zdes++; break;
                 case 4: xdes--; break;
                 case 5: ydes--; break;
                 case 6: zdes--; break;
                 default: break;
             }
            i= delta_calcInverse(xdes, ydes, zdes, out destheta1[0], out destheta1[1], out destheta1[2]);
             if(i==0)
             {
                 destheta[0] = destheta1[0];
                 destheta[1] = destheta1[1];
                 destheta[2] = destheta1[2];

             }
            
         }
         else if (buttonclick <= 12)
         {
             switch (buttonclick)
             {
                 case 7: destheta[0]++; break;
                 case 8: destheta[1]++; break;
                 case 9: destheta[2]++; break;
                 case 10: destheta[0]--; break;
                 case 11: destheta[1]--; break;
                 case 12: destheta[2]--; break;
                 default: break;
             }
         }
         senduart(10, destheta[0]);
         Thread.Sleep(3);
         senduart(11, destheta[1]);
         Thread.Sleep(3);
         senduart(12, destheta[2]);
         Thread.Sleep(3);

     }

     private void getpoint_Click(object sender, EventArgs e)
     {
         pointtheta[numpoint, 0] = destheta[0];
         pointtheta[numpoint, 1] = destheta[1];
         pointtheta[numpoint, 2] = destheta[2];

        
         pointtext.Text += "Point_" + numpoint.ToString() + "= ( " + Convert.ToString(pointtheta[numpoint, 0]) + "," + Convert.ToString(pointtheta[numpoint, 1]) + "," + Convert.ToString(pointtheta[numpoint, 2]) + ")\r\n";
         numpoint++;
     }

     private void enter_Click(object sender, EventArgs e)
     {
         if (command.Text == "goto")
             program[numcode, 0] = 1;
         else if (command.Text == "wait")
             program[numcode, 0] = 2;
         else if (command.Text == "gripper")
             program[numcode, 0] = 3;
         else if (command.Text == "if")
             program[numcode, 0] = 4;
         else
             program[numcode, 0] = 0;
            
         if (program[numcode, 0] != 0)
         {
             if (program[numcode, 0] <= 3)
                 program[numcode, 1] = uint.Parse(point.Text);
             else
             {
                 if (point.Text == "red")
                     program[numcode, 1] = 1;
                 else if (point.Text == "green")
                     program[numcode, 1] = 2;
                 else if (point.Text == "blue") 
                     program[numcode, 1] = 3;
                 else
                     program[numcode, 1] = 0;
             }
             program[numcode, 2] = uint.Parse(time.Text);
             switch (program[numcode, 0])
             {
                 case 1: programbox.Text += "Go To Point P" + point.Text + " With Time " + time.Text + "\r\n";
                     break;
                 case 2: programbox.Text += "Wait Time " + time.Text + "\r\n";
                     break;
                 case 3: programbox.Text += "Gripper " + point.Text + "\r\n";
                     break;
                 case 4: programbox.Text += "if " + point.Text + " else jump " + time.Text + "\r\n";
                     break;
                 default: break;
             }
             numcode++;

         }
         
     }

     private void clearpro_Click(object sender, EventArgs e)
     {
         programbox.Clear();
         numcode = 0;
         Array.Clear(program, 0, program.Length);
     }

     private void clearpoint_Click(object sender, EventArgs e)
     {
         pointtext.Clear();
         numpoint = 0;
         Array.Clear(pointtheta, 0, pointtheta.Length);

     }

     private void play_Click(object sender, EventArgs e)
     {
         
         stoping = 0;
         demorun = new Thread(new ThreadStart(this.Demoprogram));
         demorun.Start();
         
     }

     private void stop_Click(object sender, EventArgs e)
     {
         stoping = 1;
         demorun.Abort();
     }

     private void sethome_Click(object sender, EventArgs e)
     {
         senduart(10,180);
         senduart(11,180);
         senduart(12,180);
         Array.Clear(destheta, 0, destheta.Length);
         delta_calcForward(destheta[0], destheta[1], destheta[2], out xdes, out ydes, out zdes);
     }

    
     private void timer1_Tick(object sender, EventArgs e)
     {

         tred.Text = Convert.ToString(img_color[0]);
         tblue.Text = Convert.ToString(img_color[1]);
         tgreen.Text = Convert.ToString(img_color[2]);
         theta1.Text = theta[0, 0].ToString();
         theta2.Text = theta[1, 0].ToString();
         theta3.Text = theta[2, 0].ToString();
         delta_calcForward(theta[0, 0], theta[1, 0], theta[2, 0], out xr, out yr, out zr);
         x.Text = xr.ToString();
         y.Text = yr.ToString();
         z.Text = zr.ToString();
     }

     private void Form1_Load(object sender, EventArgs e)
     {

     }
     private void Demoprogram()
     {
         int running = 0;
         if(stoping==0)
         {
             while (running <= numcode)
             {
                 if (program[running, 0] == 1)
                 {
                     senduart(13, ((float)program[running, 2]) / 10);
                     Thread.Sleep(3);
                     senduart(14, ((float)program[running, 2]) / 10);
                     Thread.Sleep(3);
                     senduart(15, ((float)program[running, 2]) / 10);
                     Thread.Sleep(3);

                     destheta[0] = pointtheta[program[running, 1], 0];
                     destheta[1] = pointtheta[program[running, 1], 1];
                     destheta[2] = pointtheta[program[running, 1], 2];
                     senduart(10, destheta[0]);
                     Thread.Sleep(3);
                     senduart(11, destheta[1]);
                     Thread.Sleep(3);
                     senduart(12, destheta[2]);


                 }
                 else if (program[running, 0] == 3)
                 {
                     if (program[running, 1] == 1)
                         senduart(2, 0);
                     else
                         senduart(4, 0);
                 }
                 else if (program[running, 0] == 4)
                 {
                     if (program[running, 1] == 1 & img_color[0] == 0)
                     {
                         running = running + (int)program[running, 2];
                     }
                     if (program[running, 1] == 2 & img_color[2] == 0)
                     {
                         running = running + (int)program[running, 2];
                     }
                     if (program[running, 1] == 3 & img_color[1] == 0)
                     {
                         running = running + (int)program[running, 2];
                     }

                 }

                 Thread.Sleep((int)program[running, 2]);
                 running++;
                 if (running >= numcode)
                     running = 0;
             }
         }

     }

     private void imagezone()
     {
         int i = 0;
         byte j = 0;

         try
         {
             capture = new Capture();
         }
         catch (NullReferenceException excpt)
         {
             MessageBox.Show(excpt.Message);
         }
         Thread.Sleep(2000);
     
         
         while (true)
         {
             Image<Bgr, Byte> image = capture.QueryFrame();  //line 1
             Image<Hsv, Byte> imgHsv = image.Convert<Hsv, Byte>();
             // ImageFrame = ImageFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
             

             for (i = 0; i < 3; i++)
             {
                 Image<Gray, byte> imgthres = new Image<Gray, byte>(imgHsv.Size);
                 if (i == 0)
                     red(imgHsv, out imgthres);
                 else if (i == 1)
                     blue(imgHsv, out imgthres);
                 else if (i == 2)
                    green(imgHsv, out imgthres);

                 //erode and dilate
                 StructuringElementEx element = new StructuringElementEx(5, 5, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
                 CvInvoke.cvErode(imgthres, imgthres, element, 1);
                 element = new StructuringElementEx(5, 5, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
                 CvInvoke.cvDilate(imgthres, imgthres, element, 1);
                 //
                 //contour


                 using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                     for (Contour<Point> contours = imgthres.FindContours(); contours != null; contours = contours.HNext)
                     {
                         
                         if (contours.Area > 400) //only consider contours with area greater than 250
                         {
                             j++;
                             image.Draw(contours, new Bgr(Color.Gold), 4);

                         }
                     }
                
                 img_color[i] = j;
                 j = 0;
             }
           
             
             cam.Image = image;
      
         }
     
     
     }
     private void red(Image<Hsv, Byte> imgHsv,out Image<Gray, byte> colordetimg)
     {
         Image<Gray, Byte>[] channels = imgHsv.Split();  //split into components
         Image<Gray, Byte> imghue = channels[0];            //hsv, so channels[0] is hue.
         Image<Gray, Byte> imgsat = channels[1];            //hsv, so channels[1] is sat.
         Image<Gray, Byte> imgval = channels[2];            //hsv, so channels[2] is value.
         //filter out all but "the color you want"...seems to be 0 to 128 ?
         Image<Gray, byte> huefilter1 = imghue.InRange(new Gray(0), new Gray(10));
         Image<Gray, byte> huefilter2 = imghue.InRange(new Gray(159), new Gray(180));

         Image<Gray, byte> satfilter = imgsat.InRange(new Gray(127), new Gray(255));
         //use the value channel to filter out all but brighter colors
         Image<Gray, byte> valfilter = imgval.InRange(new Gray(56), new Gray(255));


         //now and the two to get the parts of the imaged that are colored and above some brightness.
          colordetimg = (huefilter1.Or(huefilter2)).And(valfilter).And(satfilter);

     }

     private void green(Image<Hsv, Byte> imgHsv, out Image<Gray, byte> colordetimg)
     {
         Image<Gray, Byte>[] channels = imgHsv.Split();  //split into components
         Image<Gray, Byte> imghue = channels[0];            //hsv, so channels[0] is hue.
         Image<Gray, Byte> imgsat = channels[1];            //hsv, so channels[1] is sat.
         Image<Gray, Byte> imgval = channels[2];            //hsv, so channels[2] is value.
         //filter out all but "the color you want"...seems to be 0 to 128 ?
         Image<Gray, byte> huefilter = imghue.InRange(new Gray(50), new Gray(80));
        

         Image<Gray, byte> satfilter = imgsat.InRange(new Gray(127), new Gray(255));
         //use the value channel to filter out all but brighter colors
         Image<Gray, byte> valfilter = imgval.InRange(new Gray(56), new Gray(255));


         //now and the two to get the parts of the imaged that are colored and above some brightness.
         colordetimg = huefilter.And(valfilter).And(satfilter);

     }

     private void blue(Image<Hsv, Byte> imgHsv, out Image<Gray, byte> colordetimg)
     {
         Image<Gray, Byte>[] channels = imgHsv.Split();  //split into components
         Image<Gray, Byte> imghue = channels[0];            //hsv, so channels[0] is hue.
         Image<Gray, Byte> imgsat = channels[1];            //hsv, so channels[1] is sat.
         Image<Gray, Byte> imgval = channels[2];            //hsv, so channels[2] is value.
         //filter out all but "the color you want"...seems to be 0 to 128 ?
         Image<Gray, byte> huefilter = imghue.InRange(new Gray(100), new Gray(140));


         Image<Gray, byte> satfilter = imgsat.InRange(new Gray(127), new Gray(255));
         //use the value channel to filter out all but brighter colors
         Image<Gray, byte> valfilter = imgval.InRange(new Gray(56), new Gray(255));


         //now and the two to get the parts of the imaged that are colored and above some brightness.
         colordetimg = huefilter.And(valfilter).And(satfilter);

     }

     private void label11_Click(object sender, EventArgs e)
     {

     }

     




    }
}   







