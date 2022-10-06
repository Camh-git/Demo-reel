package app;
import java.applet.*;
import java.awt.Event.*;
import java.awt.Graphics;
import java.awt.Label;
import java.awt.TextField;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.Button;
import java.awt.Color;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

public class applett extends  Applet implements ActionListener{
  Button click;
  TextField in;
  TextField in2;
  TextField in3;
  TextField in4;
  TextField in5;
  TextField in6;
  static Label info;
  static Label info2;
  static Label info3;
  static Label info4;
  static Label info5;
  static Label info6;
  static Label result;
  static Label result2;
  static Label result3;
  
  public void init()
  {
	  click=new Button("click here once all the boxes are filled");
	  click.addActionListener(this);
	  result = new Label();
	  result2= new Label();
	  result3= new Label();
	  info = new Label("year to check for leap");
	  info2 = new Label("day1(dd/mm/yy");
	  info3 = new Label("day2(dd/mm/yy)");
	  info4 =new Label("dayname date");
	  info5 =new Label("dayname month");
	  info6 =new Label("dayname year");
	  in = new TextField(20);
	  in2= new TextField(20); 
	  in3= new TextField(20); 
	  in4= new TextField(20); 
	  in5= new TextField(20); 
	  in6= new TextField(20); 
	  add(click);
	  add(info);
	  add(in);
	  add(info2);
	  add(in2);
	  add(info3);
	  add(in3);
	  add(info4);
	  add(in4);
	  add(info5);
	  add(in5);
	  add(info6);
	  add(in6);
	  add(result);
	  add(result2);
	  add(result3);
  }
	public void paint(Graphics g)
	{
		g.drawString("welcome, please enter the required information then press the button",10 ,80 );
	}
	
public void actionPerformed(ActionEvent e)
{
	//leap();
	
	//Daysdiff();
	
	//Dayname();
	}
	

	private static void leap() {
		System.out.println("please enter the year you wish to check");
		Scanner getyear = new Scanner(System.in);
		String s = info.getText();
		int year = Integer.parseInt(s);
		if (year%400==0){
			result.setText(year+" is a leap year");
		}
		else if (year%100==0){
			result.setText(year+" is not a leap year");
		}
		else if((year%4==0) && (year%100!=0)){
			result.setText(year+" is a leap year");
		}
		else{
			result.setText(year+" is not a leap year");
	}
}
	private static void Daysdiff() {
		String day1 = "14/01/2012";
		String day2 = "18/01/2012";
		//getting the 
		System.out.println("please enter the dates, starting with the lowest first");
		System.out.println("please enter the first date in the format dd/mm/yyyy");
		Scanner getday = new Scanner(System.in);
		day1 = info2.getText();
		System.out.println("please enter the second date in the format dd/mm/yyyy");
		day2 = info3.getText();
		
		SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");

		Date d1;
		Date d2;

		try {
			d1 = format.parse(day1);
			d2 = format.parse(day2);

			//in milliseconds
			long diff = d2.getTime() - d1.getTime();
			long diffDays = diff / (24 * 60 * 60 * 1000);
			result2.setText("there are "+ diffDays + "days between the dates.");

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
		String a = info4.getText();
		 day = Integer.parseInt(a);//getting the day value
		 System.out.println("please enter the month");
		 String b = info5.getText();
		 month = Integer.parseInt(b);//getting the day value
		 System.out.println("please enter the year");
		 String d = info6.getText();
		 year = Integer.parseInt(d);//getting the day value
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
		result3.setText("theday was a friday ");
	} 
	else 
		if (dayofWeek >4 && dayofWeek<6)
		{
			result3.setText("theday was thursday ");
		}
		else 
			if (dayofWeek >3 && dayofWeek<5)
			{
				result3.setText("theday was wednesday ");
			}
			else 
				if (dayofWeek >2 && dayofWeek<4)
				{
					result3.setText("theday was a tuesday ");
				}
				else 
					if (dayofWeek >1 && dayofWeek<3)
					{
						result3.setText("theday was a monday ");
					}
					else 
						if (dayofWeek >0 && dayofWeek<2)
						{
							result3.setText("theday was a sunday ");
						}
						else 
							if (dayofWeek<1)
							{
								result3.setText("theday was a saturday ");
							}
  
}



	
	
	
	//result.setText("it worked");
}

