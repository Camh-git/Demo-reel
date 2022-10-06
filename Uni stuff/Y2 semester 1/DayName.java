package assignment;
import java.util.Calendar;
import java.util.Scanner;
public class DayName {
	public static void main(String[] args){
		
		Calendar today = Calendar.getInstance();
		int day;
		int month;
		int year;
		 
		Scanner in = new Scanner(System.in);
		System.out.println("please enter the date");
		 day = in.nextInt();//getting the day value
		 System.out.println("please enter the month");
		 month = in.nextInt();//getting the day value
		 System.out.println("please enter the year");
		 year = in.nextInt();//getting the day value
		 month = month+1; // adjusts month so the calculation works
		 
		if (month < 4) {
		month += 12;
		year -= 1;
		} 
		int y = year % 100;
		int c = year / 100;
		int dayofWeek =((((month*26)/10)+ day+y+(y/4) + (c / 4)) + (5 * c)) % 7;
		 System.out.println(dayofWeek);
		 
	if(dayofWeek>5)
	{
		 System.out.println("the day was a Friday");
	} 
	else 
		if (dayofWeek >4 && dayofWeek<6)
		{
			System.out.println("the day was a Thursday");
		}
		else 
			if (dayofWeek >3 && dayofWeek<5)
			{
				System.out.println("the day was a Wednesday");
			}
			else 
				if (dayofWeek >2 && dayofWeek<4)
				{
					System.out.println("the day was a Tuesday");
				}
				else 
					if (dayofWeek >1 && dayofWeek<3)
					{
						System.out.println("the day was a Monday");
					}
					else 
						if (dayofWeek >0 && dayofWeek<2)
						{
							System.out.println("the day was a Sunday");
						}
						else 
							if (dayofWeek<1)
							{
								System.out.println("the day was a Saturday");
							}
  
	}
}
