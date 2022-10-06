import java.util.Scanner;
import java.util.Date;
public class mydate {
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
	
	
	}
}
