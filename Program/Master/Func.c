#include "func.h"
#include "delay.h"
#include "Driver_init.h"
#include <string.h> 
#include <stdlib.h> 



#define BufferSize       5
uint8_t SPI_MASTER_Buffer_Tx[BufferSize+1] ;
float  destheta[3],theta[3],ramptime[3];
uint8_t tick,not_ramping[3],count,startframe_rx,rx_spi[BufferSize];
uint8_t SPI_MASTER_Buffer_Rx,temp,spi_busy,frame_count;
uint8_t RxBuffer[BufferSize+1];
uint8_t TxBuffer[BufferSize+1];
////////////////////////  Normal function  ///////////////////////////////////////
void send_spi_float(char ofcode,float datasend)
{
	int TxIdx=0,i;
memcpy(SPI_MASTER_Buffer_Tx, &datasend, sizeof datasend);
	SPI_MASTER_Buffer_Tx[4]=ofcode;
	for(i=5;i>=1;i--)
	{
		SPI_MASTER_Buffer_Tx[i]=SPI_MASTER_Buffer_Tx[i-1];
	}
	SPI_MASTER_Buffer_Tx[0]=250;
	while (TxIdx < BufferSize+1)
  {
    /* Wait for SPI_MASTER Tx buffer empty */
    while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);
    /* Send SPI_MASTER data */
    SPI_I2S_SendData(SPI1, SPI_MASTER_Buffer_Tx[TxIdx++]);
		while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);
		delay_us(5);
  }

}
void spi_to_slave(char id,char ofcode,float data)
{
			if ( id==0)
			{
			//	while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);
				GPIO_ResetBits(GPIOA,GPIO_Pin_4);
				send_spi_float(ofcode,data);
				GPIO_SetBits(GPIOA,GPIO_Pin_4);
			}
			if ( id==1)
			{
			//	while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);
				GPIO_ResetBits(GPIOA,GPIO_Pin_3);
				send_spi_float(ofcode,data);
				GPIO_SetBits(GPIOA,GPIO_Pin_3);
			}
			if ( id==2)
			{
			//	while (SPI_I2S_GetFlagStatus(SPI1, SPI_I2S_FLAG_TXE) == RESET);
				GPIO_ResetBits(GPIOA,GPIO_Pin_2);
				send_spi_float(ofcode,data);
				GPIO_SetBits(GPIOA,GPIO_Pin_2);
			}
}
void uart1_send()
{

	int i=0,j=0;

	if ( tick>=30)
	{
		for (i=0;i<3;i++)
		{
			for (j=0;j<6;j++)
			TxBuffer[j]=0;
			memcpy(TxBuffer, &theta[i], sizeof theta);
			for (j=4;j>0;j--)
			TxBuffer[j]=TxBuffer[j-1];
			TxBuffer[0]=100; //opcode start
			TxBuffer[5]=i;    // opcode slave
		if (not_ramping[i]==1)
			TxBuffer[5]=TxBuffer[5]+16;
		for (j=0;j<6;j++)
		{
		while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
		USART_SendData( USART1, TxBuffer[j]);
		}
		}
		tick=0;
	}


}


////////////////////////  Interupt routine  ///////////////////////////////////////

void SPI1_IRQHandler(void)
{
	int robotnum=0;
	float datarx=0;
  if(SPI_I2S_GetITStatus(SPI1,SPI_I2S_IT_RXNE)!=0)
  {	
		SPI_MASTER_Buffer_Rx=SPI_I2S_ReceiveData(SPI1);
		if(startframe_rx==1)
		{
			rx_spi[frame_count]=SPI_MASTER_Buffer_Rx;
			frame_count++;
		}
		if(frame_count==5)
		{
			startframe_rx=0;
			frame_count=0;
			
		memcpy(&datarx, rx_spi, sizeof datarx); 
		robotnum=(rx_spi[4]& 0x0f)-10;
		if (robotnum<3 & robotnum>=0) // of code slave
		{
				theta[robotnum]=datarx;
			not_ramping[robotnum]=(rx_spi[4] & 0xf0)>>4;
		}
	}
		
		
		if (SPI_MASTER_Buffer_Rx ==0xff)
		{
			startframe_rx=1;
		}
  }
}
void DMA1_Channel5_IRQHandler(void)
{
	int j=0;
	int robotnum=0;
	float datarx=0;
  if(DMA_GetITStatus(DMA1_IT_TC5))
  {
    DMA_ClearITPendingBit(DMA1_IT_GL5);
		if (RxBuffer[0]==200) //opcode start
		{
			spi_busy=1;
			for (j=0;j<5;j++)
			RxBuffer[j]=RxBuffer[j+1];
		memcpy(&datarx, RxBuffer, sizeof datarx);
		robotnum=(RxBuffer[4]& 0x0f)-10;
		if (robotnum<3 & robotnum>=0) // of code slave destheta
		{
				destheta[robotnum]=datarx;
				spi_to_slave(robotnum,2,destheta[robotnum]);
		}
		if (robotnum<6 & robotnum>=3) // of code slave ramp
		{
				ramptime[robotnum-3]=datarx;
				spi_to_slave(robotnum-3,1,ramptime[robotnum-3]);
		}
		robotnum=RxBuffer[4];
		if (robotnum==2)  // ofcode open gripper		
				GPIO_SetBits(GPIOA,GPIO_Pin_0);		
		if (robotnum==4) // ofcode close gripper
				GPIO_ResetBits(GPIOA,GPIO_Pin_0);			
		spi_busy=0;
		}
  }
}

void TIM3_IRQHandler()
{
	TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
	
}
void SysTick_Handler()
{
		tick++;
	count++;
	if(spi_busy==0)
	{

		if(count==30)
		spi_to_slave(0,0,0);
		if(count==70)	
		spi_to_slave(1,0,0);
		if(count==90)	
		spi_to_slave(2,0,0);
		if(count>=99)
		count=0;
		}
	TimingDelay_Decrement();
	
}


