#include "func.h"
#include "delay.h"
//#include "LCD_Driver.h"
#include "Driver_init.h"




int main()
{
	if (SysTick_Config(SystemCoreClock / 1000))
  { 
    /* Capture error */ 
    while (1);
  }	
	spi_init_master();
	 uart1_init();
	PWM_init();
	GPIO_SetBits(GPIOA,GPIO_Pin_4);
	GPIO_SetBits(GPIOA,GPIO_Pin_3);
	GPIO_SetBits(GPIOA,GPIO_Pin_2);
	delay_ms(3000);
	spi_to_slave(0,1,20);
	spi_to_slave(1,1,20);
	spi_to_slave(2,1,20);
	while(1)
	{
		uart1_send();
	

	}
	
	
		
}
