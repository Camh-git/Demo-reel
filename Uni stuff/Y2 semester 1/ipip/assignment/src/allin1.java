import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

public class allin1 {
	public static void main(String[] args){
		int day;
		int month;
		int year;
		Date date1;
		Date date2;
		System.out.println("please enter the day(1 to7)");
		 Scanner in = new Scanner(System.in);
		 day = in.nextInt();//getting the day value
		 while((day>7) || (day <1)){// verifying the day 
			 System.out.println ("please enter a valid day");
		  day = in.nextInt();//getting a new day value
		 }
		System.out.println("please enter the month (1-12)");
		 month = in.nextInt();// getting the month value
		 while((month>12) || (month <1))
		 {
		  System.out.println ("please enter a valid month");
		  month = in.nextInt();//getting a new month value
		 }
	
		System.out.println("please enter the year(0-9999)");
		 year = in.nextInt();// getting the year value
		 while((year>9999) || (year <0))
		 {
			 System.out.println ("please enter a valid year");
		  year= in.nextInt();//getting a new year value
		 }
		
		System.out.println("the selected date is "+ day + "/"+month+ "/"+ year);
		// calculating if the selected year a leap year
		if (year%400==0){
			System.out.println(year + " is a leap year");
		}
		else if (year%100==0){
			System.out.println(year + " is not a leap year");
		}
		else if((year%4==0) && (year%100!=0)){
			System.out.println(year + " is a leap year");
		}
		else{
			System.out.println(year + " is not a leap year");
		}
		Calendar today = Calendar.getInstance();
		 
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
	
	}
}
