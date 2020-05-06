namespace control
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.theta1 = new System.Windows.Forms.TextBox();
            this.theta2 = new System.Windows.Forms.TextBox();
            this.theta3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.z = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Xi = new System.Windows.Forms.Button();
            this.Yi = new System.Windows.Forms.Button();
            this.Zi = new System.Windows.Forms.Button();
            this.Xd = new System.Windows.Forms.Button();
            this.Yd = new System.Windows.Forms.Button();
            this.Zd = new System.Windows.Forms.Button();
            this.theta1i = new System.Windows.Forms.Button();
            this.theta2i = new System.Windows.Forms.Button();
            this.theta3i = new System.Windows.Forms.Button();
            this.theta1d = new System.Windows.Forms.Button();
            this.theta2d = new System.Windows.Forms.Button();
            this.theta3d = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.programbox = new System.Windows.Forms.TextBox();
            this.pointtext = new System.Windows.Forms.TextBox();
            this.command = new System.Windows.Forms.TextBox();
            this.point = new System.Windows.Forms.TextBox();
            this.getpoint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.enter = new System.Windows.Forms.Button();
            this.clearpro = new System.Windows.Forms.Button();
            this.clearpoint = new System.Windows.Forms.Button();
            this.sethome = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cam = new Emgu.CV.UI.ImageBox();
            this.tred = new System.Windows.Forms.TextBox();
            this.tgreen = new System.Windows.Forms.TextBox();
            this.tblue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cam)).BeginInit();
            this.SuspendLayout();
            // 
            // theta1
            // 
            this.theta1.Location = new System.Drawing.Point(62, 8);
            this.theta1.Name = "theta1";
            this.theta1.Size = new System.Drawing.Size(71, 20);
            this.theta1.TabIndex = 0;
            // 
            // theta2
            // 
            this.theta2.Location = new System.Drawing.Point(62, 34);
            this.theta2.Name = "theta2";
            this.theta2.Size = new System.Drawing.Size(71, 20);
            this.theta2.TabIndex = 1;
            // 
            // theta3
            // 
            this.theta3.Location = new System.Drawing.Point(62, 60);
            this.theta3.Name = "theta3";
            this.theta3.Size = new System.Drawing.Size(71, 20);
            this.theta3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Theta 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Theta 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Theta 3";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(62, 86);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(71, 20);
            this.x.TabIndex = 8;
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(62, 112);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(71, 20);
            this.y.TabIndex = 9;
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(62, 138);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(71, 20);
            this.z.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "X";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Z";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.z);
            this.panel1.Controls.Add(this.y);
            this.panel1.Controls.Add(this.x);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.theta3);
            this.panel1.Controls.Add(this.theta2);
            this.panel1.Controls.Add(this.theta1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 181);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(158, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 180);
            this.panel2.TabIndex = 11;
            // 
            // Xi
            // 
            this.Xi.BackColor = System.Drawing.Color.Lime;
            this.Xi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xi.Location = new System.Drawing.Point(12, 4);
            this.Xi.Name = "Xi";
            this.Xi.Size = new System.Drawing.Size(35, 29);
            this.Xi.TabIndex = 12;
            this.Xi.Text = "X+";
            this.Xi.UseVisualStyleBackColor = false;
            this.Xi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Xi_MouseDown);
            this.Xi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Xi_MouseUp);
            // 
            // Yi
            // 
            this.Yi.BackColor = System.Drawing.Color.Lime;
            this.Yi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yi.Location = new System.Drawing.Point(51, 4);
            this.Yi.Name = "Yi";
            this.Yi.Size = new System.Drawing.Size(35, 29);
            this.Yi.TabIndex = 13;
            this.Yi.Text = "Y+";
            this.Yi.UseVisualStyleBackColor = false;
            this.Yi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Yi_MouseDown);
            this.Yi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Yi_MouseUp);
            // 
            // Zi
            // 
            this.Zi.BackColor = System.Drawing.Color.Lime;
            this.Zi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zi.Location = new System.Drawing.Point(92, 4);
            this.Zi.Name = "Zi";
            this.Zi.Size = new System.Drawing.Size(35, 29);
            this.Zi.TabIndex = 14;
            this.Zi.Text = "Z+";
            this.Zi.UseVisualStyleBackColor = false;
            this.Zi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseDown);
            this.Zi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zi_MouseUp);
            // 
            // Xd
            // 
            this.Xd.BackColor = System.Drawing.Color.Red;
            this.Xd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Xd.Location = new System.Drawing.Point(12, 39);
            this.Xd.Name = "Xd";
            this.Xd.Size = new System.Drawing.Size(35, 29);
            this.Xd.TabIndex = 15;
            this.Xd.Text = "X-";
            this.Xd.UseVisualStyleBackColor = false;
            this.Xd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Xd_MouseDown);
            this.Xd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Xd_MouseUp);
            // 
            // Yd
            // 
            this.Yd.BackColor = System.Drawing.Color.Red;
            this.Yd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yd.Location = new System.Drawing.Point(51, 39);
            this.Yd.Name = "Yd";
            this.Yd.Size = new System.Drawing.Size(35, 29);
            this.Yd.TabIndex = 16;
            this.Yd.Text = "Y-";
            this.Yd.UseVisualStyleBackColor = false;
            this.Yd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Yd_MouseDown);
            this.Yd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Yd_MouseUp);
            // 
            // Zd
            // 
            this.Zd.BackColor = System.Drawing.Color.Red;
            this.Zd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zd.Location = new System.Drawing.Point(92, 39);
            this.Zd.Name = "Zd";
            this.Zd.Size = new System.Drawing.Size(35, 29);
            this.Zd.TabIndex = 17;
            this.Zd.Text = "Z-";
            this.Zd.UseVisualStyleBackColor = false;
            this.Zd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zd_MouseDown);
            this.Zd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zd_MouseUp);
            // 
            // theta1i
            // 
            this.theta1i.BackColor = System.Drawing.Color.Lime;
            this.theta1i.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta1i.Location = new System.Drawing.Point(12, 90);
            this.theta1i.Name = "theta1i";
            this.theta1i.Size = new System.Drawing.Size(35, 29);
            this.theta1i.TabIndex = 18;
            this.theta1i.Text = "ϴ1+";
            this.theta1i.UseVisualStyleBackColor = false;
            this.theta1i.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta1i_MouseDown);
            this.theta1i.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta1i_MouseUp);
            // 
            // theta2i
            // 
            this.theta2i.BackColor = System.Drawing.Color.Lime;
            this.theta2i.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta2i.Location = new System.Drawing.Point(51, 90);
            this.theta2i.Name = "theta2i";
            this.theta2i.Size = new System.Drawing.Size(35, 29);
            this.theta2i.TabIndex = 19;
            this.theta2i.Text = "ϴ2+";
            this.theta2i.UseVisualStyleBackColor = false;
            this.theta2i.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta2i_MouseDown);
            this.theta2i.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta2i_MouseUp);
            // 
            // theta3i
            // 
            this.theta3i.BackColor = System.Drawing.Color.Lime;
            this.theta3i.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta3i.Location = new System.Drawing.Point(92, 90);
            this.theta3i.Name = "theta3i";
            this.theta3i.Size = new System.Drawing.Size(35, 29);
            this.theta3i.TabIndex = 20;
            this.theta3i.Text = "ϴ3+";
            this.theta3i.UseVisualStyleBackColor = false;
            this.theta3i.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta3i_MouseDown);
            this.theta3i.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta3i_MouseUp);
            // 
            // theta1d
            // 
            this.theta1d.BackColor = System.Drawing.Color.Red;
            this.theta1d.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta1d.Location = new System.Drawing.Point(12, 125);
            this.theta1d.Name = "theta1d";
            this.theta1d.Size = new System.Drawing.Size(35, 29);
            this.theta1d.TabIndex = 21;
            this.theta1d.Text = "ϴ1-";
            this.theta1d.UseVisualStyleBackColor = false;
            this.theta1d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta1d_MouseDown);
            this.theta1d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta1d_MouseUp);
            // 
            // theta2d
            // 
            this.theta2d.BackColor = System.Drawing.Color.Red;
            this.theta2d.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta2d.Location = new System.Drawing.Point(51, 125);
            this.theta2d.Name = "theta2d";
            this.theta2d.Size = new System.Drawing.Size(35, 29);
            this.theta2d.TabIndex = 22;
            this.theta2d.Text = "ϴ2-";
            this.theta2d.UseVisualStyleBackColor = false;
            this.theta2d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta2d_MouseDown);
            this.theta2d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta2d_MouseUp);
            // 
            // theta3d
            // 
            this.theta3d.BackColor = System.Drawing.Color.Red;
            this.theta3d.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theta3d.Location = new System.Drawing.Point(92, 125);
            this.theta3d.Name = "theta3d";
            this.theta3d.Size = new System.Drawing.Size(35, 29);
            this.theta3d.TabIndex = 23;
            this.theta3d.Text = "ϴ3-";
            this.theta3d.UseVisualStyleBackColor = false;
            this.theta3d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theta3d_MouseDown);
            this.theta3d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theta3d_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.theta3d);
            this.panel3.Controls.Add(this.theta2d);
            this.panel3.Controls.Add(this.theta1d);
            this.panel3.Controls.Add(this.theta3i);
            this.panel3.Controls.Add(this.theta2i);
            this.panel3.Controls.Add(this.theta1i);
            this.panel3.Controls.Add(this.Zd);
            this.panel3.Controls.Add(this.Yd);
            this.panel3.Controls.Add(this.Xd);
            this.panel3.Controls.Add(this.Zi);
            this.panel3.Controls.Add(this.Yi);
            this.panel3.Controls.Add(this.Xi);
            this.panel3.Location = new System.Drawing.Point(168, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(146, 180);
            this.panel3.TabIndex = 24;
            // 
            // programbox
            // 
            this.programbox.Location = new System.Drawing.Point(2, 188);
            this.programbox.Multiline = true;
            this.programbox.Name = "programbox";
            this.programbox.Size = new System.Drawing.Size(161, 179);
            this.programbox.TabIndex = 26;
            // 
            // pointtext
            // 
            this.pointtext.Location = new System.Drawing.Point(168, 188);
            this.pointtext.Multiline = true;
            this.pointtext.Name = "pointtext";
            this.pointtext.Size = new System.Drawing.Size(145, 179);
            this.pointtext.TabIndex = 27;
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(2, 377);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(58, 20);
            this.command.TabIndex = 28;
            // 
            // point
            // 
            this.point.Location = new System.Drawing.Point(66, 378);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(42, 20);
            this.point.TabIndex = 29;
            // 
            // getpoint
            // 
            this.getpoint.BackColor = System.Drawing.Color.Yellow;
            this.getpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getpoint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.getpoint.Location = new System.Drawing.Point(168, 375);
            this.getpoint.Name = "getpoint";
            this.getpoint.Size = new System.Drawing.Size(69, 25);
            this.getpoint.TabIndex = 30;
            this.getpoint.Text = "Get Point";
            this.getpoint.UseVisualStyleBackColor = false;
            this.getpoint.Click += new System.EventHandler(this.getpoint_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(66, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Point";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(114, 377);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(42, 20);
            this.time.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Time";
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Orange;
            this.play.Location = new System.Drawing.Point(6, 416);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(36, 28);
            this.play.TabIndex = 32;
            this.play.Text = "Play";
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Orange;
            this.stop.Location = new System.Drawing.Point(48, 416);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(54, 28);
            this.stop.TabIndex = 32;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // enter
            // 
            this.enter.BackColor = System.Drawing.Color.Orange;
            this.enter.Location = new System.Drawing.Point(109, 416);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(47, 28);
            this.enter.TabIndex = 32;
            this.enter.Text = "Enter";
            this.enter.UseVisualStyleBackColor = false;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // clearpro
            // 
            this.clearpro.BackColor = System.Drawing.Color.Orange;
            this.clearpro.Location = new System.Drawing.Point(162, 416);
            this.clearpro.Name = "clearpro";
            this.clearpro.Size = new System.Drawing.Size(83, 29);
            this.clearpro.TabIndex = 32;
            this.clearpro.Text = "Clear Program";
            this.clearpro.UseVisualStyleBackColor = false;
            this.clearpro.Click += new System.EventHandler(this.clearpro_Click);
            // 
            // clearpoint
            // 
            this.clearpoint.BackColor = System.Drawing.Color.Tomato;
            this.clearpoint.Location = new System.Drawing.Point(243, 375);
            this.clearpoint.Name = "clearpoint";
            this.clearpoint.Size = new System.Drawing.Size(72, 25);
            this.clearpoint.TabIndex = 32;
            this.clearpoint.Text = "Clear Point";
            this.clearpoint.UseVisualStyleBackColor = false;
            this.clearpoint.Click += new System.EventHandler(this.clearpoint_Click);
            // 
            // sethome
            // 
            this.sethome.BackColor = System.Drawing.Color.Orange;
            this.sethome.Location = new System.Drawing.Point(251, 416);
            this.sethome.Name = "sethome";
            this.sethome.Size = new System.Drawing.Size(64, 29);
            this.sethome.TabIndex = 32;
            this.sethome.Text = "Set Home";
            this.sethome.UseVisualStyleBackColor = false;
            this.sethome.Click += new System.EventHandler(this.sethome_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cam
            // 
            this.cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cam.Location = new System.Drawing.Point(319, 1);
            this.cam.Name = "cam";
            this.cam.Size = new System.Drawing.Size(363, 208);
            this.cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cam.TabIndex = 2;
            this.cam.TabStop = false;
            // 
            // tred
            // 
            this.tred.Location = new System.Drawing.Point(351, 215);
            this.tred.Name = "tred";
            this.tred.Size = new System.Drawing.Size(37, 20);
            this.tred.TabIndex = 33;
            // 
            // tgreen
            // 
            this.tgreen.Location = new System.Drawing.Point(351, 251);
            this.tgreen.Name = "tgreen";
            this.tgreen.Size = new System.Drawing.Size(37, 20);
            this.tgreen.TabIndex = 34;
            // 
            // tblue
            // 
            this.tblue.Location = new System.Drawing.Point(351, 287);
            this.tblue.Name = "tblue";
            this.tblue.Size = new System.Drawing.Size(37, 20);
            this.tblue.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(410, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Number of red object";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Lime;
            this.label11.Location = new System.Drawing.Point(410, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Number of green object";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(410, 294);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Number of blue object";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(687, 457);
            this.Controls.Add(this.tblue);
            this.Controls.Add(this.tgreen);
            this.Controls.Add(this.tred);
            this.Controls.Add(this.cam);
            this.Controls.Add(this.clearpoint);
            this.Controls.Add(this.sethome);
            this.Controls.Add(this.clearpro);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.play);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.getpoint);
            this.Controls.Add(this.time);
            this.Controls.Add(this.point);
            this.Controls.Add(this.command);
            this.Controls.Add(this.pointtext);
            this.Controls.Add(this.programbox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Control Terminal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox theta1;
        private System.Windows.Forms.TextBox theta2;
        private System.Windows.Forms.TextBox theta3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.TextBox z;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Xi;
        private System.Windows.Forms.Button Yi;
        private System.Windows.Forms.Button Zi;
        private System.Windows.Forms.Button Xd;
        private System.Windows.Forms.Button Yd;
        private System.Windows.Forms.Button Zd;
        private System.Windows.Forms.Button theta1i;
        private System.Windows.Forms.Button theta2i;
        private System.Windows.Forms.Button theta3i;
        private System.Windows.Forms.Button theta1d;
        private System.Windows.Forms.Button theta2d;
        private System.Windows.Forms.Button theta3d;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox programbox;
        private System.Windows.Forms.TextBox pointtext;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.TextBox point;
        private System.Windows.Forms.Button getpoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Button clearpro;
        private System.Windows.Forms.Button clearpoint;
        private System.Windows.Forms.Button sethome;
        private System.Windows.Forms.Timer timer1;
        private Emgu.CV.UI.ImageBox cam;
        private System.Windows.Forms.TextBox tred;
        private System.Windows.Forms.TextBox tgreen;
        private System.Windows.Forms.TextBox tblue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

