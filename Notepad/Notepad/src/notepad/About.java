
package notepad;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class About extends JFrame implements ActionListener{
    
    About(){
        setBounds(400, 100, 600, 500);
        setLayout(null);
        ImageIcon i1 = new ImageIcon(ClassLoader.getSystemResource("icons/windows.png"));
        Image i2 = i1.getImage().getScaledInstance(300,60,Image.SCALE_DEFAULT);
        ImageIcon i3 = new ImageIcon(i2);
        JLabel headerIcon = new JLabel(i3);
        headerIcon.setBounds(70,40, 400, 80);
        add(headerIcon);
        
        
        JLabel text = new JLabel("<html>code <br> Version 0.1.0(os build java)<br>All right reserved</html>");
        text.setFont(new Font("San_Serif", Font.PLAIN,16));
        text.setBounds(150,100,500,200);
        add(text);
        
        JButton b1 = new JButton("OK");
        b1.setBounds(150,350,120,25);
        b1.addActionListener(this);
        add(b1);
        setVisible(true);
        
    }
    public void actionPerformed(ActionEvent ae )
    {
        this.setVisible(false);
    }
    public static void main(String[] args)
    {
        new About();
    }
    
}
