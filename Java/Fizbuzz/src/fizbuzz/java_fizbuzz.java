package fizbuzz;
import java.util.Scanner;



public class java_fizbuzz{
	
	private static final Scanner scan = new Scanner(System.in);
	
	public static void main(String[] args) {
		System.out.println("Please enter the target value");
		int target = scan.nextInt();	
		for (int i = 1; i < target; i++) {
			if(i%3 == 0 && i%5 == 0) {
				System.out.println("FIZZBUZZ");
			}
			else if (i%3 == 0) {
				System.out.println("FIZZ");
			}
			else if (i%5 == 0) {
				System.out.println("BUZZ");
			}
			else
			{
				System.out.println(i);
			}
				
		}
		System.out.println("\nEnd of Fizbuzz");
		
	}
}