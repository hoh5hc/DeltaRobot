#include "func.h"
#include "delay.h"
//#include "LCD_Driver.h"
#include "Driver_init.h"
#include <string.h> 
#include <stdlib.h> 

__IO int32_t ENC_Cycles;

int main()
{
	SysTick_Config(SystemCoreClock / 1000);		
	ENC_Cycles=-1;
	Basic_timer_init();
	PWM_init();
	spi_init_slave();
	TIM_SetCompare1(TIM2,0);
	Enc_config();
	ENC_Cycles=0;
	TIM1->CNT=0;
	
TIM_SetCompare1(TIM2,9000);
	while(1)
	{
			
	SampleTime_0_1s();
//		GPIO_WriteBit(GPIOB,GPIO_Pin_13,Bit_RESET);
//		TIM_SetCompare1(TIM2,5000);
//		delay_us(5000);
//		GPIO_WriteBit(GPIOB,GPIO_Pin_13,Bit_SET);			
//		TIM_SetCompare1(TIM2,5000);
//		delay_us(5000);
	}
		
}
