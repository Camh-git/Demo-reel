package dates;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;
	
public class Mydate {
	
		public static void main(String[] args){
			leap();
		
			Daysdiff();
			
			Dayname();
			}
			

			private static void leap() {
				System.out.println("please enter the year you wish to check");
				Scanner getyear = new Scanner(System.in);
				int year = getyear.nextInt();
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
			private static void Daysdiff() {
				String day1 = "14/01/2012";
				String day2 = "18/01/2012";
				//getting the 
				System.out.println("please enter the dates, starting with the lowest first");
				System.out.println("please enter the first date in the format dd/mm/yyyy");
				Scanner getday = new Scanner(System.in);
				day1 = getday.next();
				System.out.println("please enter the second date in the format dd/mm/yyyy");
				day2 = getday.next();
				
				SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");

				Date d1;
				Date d2;

				try {
					d1 = format.parse(day1);
					d2 = format.parse(day2);

					//in milliseconds
					long diff = d2.getTime() - d1.getTime();
					long diffDays = diff / (24 * 60 * 60 * 1000);

					System.out.println("there are " + diffDays + " days between the dates.");

				} catch (Exception e) {
					e.printStackTrace();
				}
				
			}
			
			
			private static void Dayname() {	
				Calendar today = Calendar.getInstance();
				int day;
				int month;
				int year;
				System.out.println("next is  the dayname mehtod, please do not start any entries into this section with a 0"); 
				Scanner in = new Scanner(System.in);
				System.out.println("please enter the date(day)");
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
