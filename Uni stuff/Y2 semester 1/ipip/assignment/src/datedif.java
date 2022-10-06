import java.util.Date;
import java.util.Scanner;
public class datedif {
	public static void main(String[] args){
	Date d1;
	Date d2;
	}
	public int getDifferenceDays(Date d1, Date d2) {
		int daysdiff=0;
		long diff = d2.getTime() - d1.getTime();
		long diffDays = diff / (24 * 60 * 60 * 1000)+1;
		 daysdiff = (int) diffDays;
		return daysdiff;
	
		 }
	
	}

