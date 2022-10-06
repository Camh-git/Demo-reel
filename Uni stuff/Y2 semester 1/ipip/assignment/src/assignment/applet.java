/*package assignment;
import java.awt.Color;
import java.awt.Button;
import java.awt.Graphics;
import java.awt.event.ActionListener;

import javax.swing.JApplet;
import java.awt.Event;

public class applet extends JApplet{

	public void start(){
		
	}
	public void init(){
		
		Button click;
		Button button1 = null;
		Button button2 = null;
		Button button3 = null;
		add(button1); add(button2);add(button3);
		button1 = new Button("leap");
		button2 = new Button("dayname");
		button3 = new Button("day of year");
		//add(new Button("leap"));
		//add(new Button("dayname"));
		//add(new Button("dayofyear"));
		
		button1.addActionListener((ActionListener) this);
		button3.addActionListener((ActionListener) this);
		button2.addActionListener((ActionListener) this);
		setBackground(Color.red);
		
	
	}
	
	public boolean action(Event evt,Object obj)
	{
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
	return true;	
	}
	public void actionPerformed()
	{
	
	}
	public void paint(Graphics g){
	g.drawString("welcome", 100,50);
		
	}
}
*/
