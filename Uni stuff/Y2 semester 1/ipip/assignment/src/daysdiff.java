
import java.util.Date;
import java.util.Scanner;
import java.text.SimpleDateFormat;
public class daysdiff {
	public static void main(String[] args){
		
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

			System.out.print("there are " + diffDays + " days between the dates.");

		} catch (Exception e) {
			e.printStackTrace();
		}
			}	
}

