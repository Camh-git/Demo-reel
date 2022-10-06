package app;
import java.awt.Color;
import java.awt.Button;
import java.awt.Graphics;
import java.awt.event.ActionListener;
import javax.swing.JApplet; 
import javax.swing.*;
import java.applet.*;
import javax.swing.JApplet.*;
import java.awt.Event.*;
import java.awt.Event;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;
import java.awt.Dimension;

public class applet extends Applet
{
	private Canvas c;{
	c = new Canvas();
	c.setPreferredSize(new Dimension(640,480));
	}
		
public void start(){
		
	}
	public void init(){
	
	
		
		Button click;
		Button button1 = null;
		Button button2 = null;
		Button button3 = null;
		button1 = new Button("leap");
		button2 = new Button("dayname");
		button3 = new Button("day of year");
		add(button1); add(button2);add(button3);
		//add(new Button("leap"));
		//add(new Button("dayname"));
		//add(new Button("dayofyear"));
		
		button1.addActionListener((ActionListener) this);
		button3.addActionListener((ActionListener) this);
		button2.addActionListener((ActionListener) this);
		
		//setBackground(Color.red);
		
	
	}
	
	/*public static action(Event evt,Object obj)
	{
	
	
		//if (e.getSource() == button1) 
	if (evt.arg=="button1")
	{
		//leap();
	}
	else if (evt.arg=="button2")
	{
		//Dayname();
	}
	else if (evt.arg=="button3")
	{
		//DaysDIFF();
	}
		
	}
	public void actionPerformed()
	{
	
	}
	public void paint(Graphics g){
	g.drawString("welcome", 100,50);
		
	}*/
}

