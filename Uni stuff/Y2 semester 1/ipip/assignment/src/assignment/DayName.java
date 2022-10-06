package assignment;
import java.util.Calendar;
public class DayName {
	public static void main(String[] args){
		
		Calendar today = Calendar.getInstance();
		int day = today.get(Calendar.DATE);
		int month = today.get(Calendar.MONTH) + 1;
		int year = today.get(Calendar.YEAR);
		
		 
		if (month < 3) {
		month += 12;
		year -= 1;
		} 
		int y = year % 100;
		int c = year / 100;
		int dayofWeek =((((month*26)/10)+ day+y+(y/4) + (c / 4)) + (5 * c)) % 7;
		 System.out.println(dayofWeek);
	if(dayofWeek==0)
	{
	   System.out.println("the date is a saturday");
	}
	else if(dayofWeek==1)
	{
     System.out.println("the date is a sunday");
	}
	else if(dayofWeek==2)
	{
     System.out.println("the date is a monday");
	}
	else if(dayofWeek==3)
	{
     System.out.println("the date is a tuesday");
	}
	else if(dayofWeek==4)
	{
     System.out.println("the date is a wednesday");
	}
	else if(dayofWeek==5)
	{
     System.out.println("the date is a thursday");
	}
	else if(dayofWeek==6)
	{
     System.out.println("the date is a friday");	
	}	
		/*int day;
	int WeekDay;
	int month;
	int year;
	int c;
	int y;
	
	c=(String.format("%02d",Integer.valueOf(year.getValue())))
			
     WeekDay==([2.68*month -0.2]+day+y+[y/4]+[c/4]-2*c)%7;*/
		
		
		
	/*public String dayName(int day, int month, int year
	 * a method to return the day name (e.g. Sunday, Monday, etc.).  NB the day number can be determined using Zeller's congruence via the formula:  
	 */
	/*d= ([2.6*M - 0.2] + D + Y + [Y/4] + [C/4] -2*C) modulo 7  
	where: 
	d is the day of the week (0=Sunday, 1=Monday etc) D is the day of the month M is 
	the month number (March = 1, April =2, .., December =10, and January and February
	are months 1 and 2 of the following year) C is the two most significant digits of 
	the year (i.e. for 2004, C is 20) Y is the two least significant digits of the year. 
	[X] is the next whole number down from the true value of X.  */
    }
}
