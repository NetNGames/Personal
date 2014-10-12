package hw6;

/**
 * Author: Elbert Date: Dec 11, 2012 A program to
 */
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.beans.PropertyChangeEvent;
import java.util.Scanner;
import javax.swing.*;

class Main extends JFrame {

    private JTabbedPane tabbedPane;
    private JPanel panel1;
    private JPanel panel2;

    public Main() {
        setTitle("Multi-Calc"); //Sets windows name
        setSize(400, 300); //Sets to fixed windows size

        JPanel topPanel = new JPanel();
        topPanel.setLayout(new BorderLayout());
        getContentPane().add(topPanel);

        // Create the tab pages
        createTab1();
        createTab2();

        // Create a tabbed panes
        tabbedPane = new JTabbedPane();
        tabbedPane.addTab("Quadratic", panel1); //Add panel1 as Quadratic Tab
        tabbedPane.addTab("Vectors", panel2); //Add panel2 as Vectors Tab
        topPanel.add(tabbedPane, BorderLayout.CENTER);
    }

    public void createTab1() {
        panel1 = new JPanel();
        panel1.setLayout(null); //Allows for greater control over exact position

        //Displays input _X^2+_X+_=0
        final JTextField field1 = new JTextField();
        field1.setBounds(90, 15, 40, 20);
        panel1.add(field1);
        JLabel label1 = new JLabel("X^2 +");
        label1.setBounds(135, 15, 50, 20);
        panel1.add(label1);
        final JTextField field2 = new JTextField();
        field2.setBounds(170, 15, 40, 20);
        panel1.add(field2);
        JLabel label2 = new JLabel("X +");
        label2.setBounds(220, 15, 50, 20);
        panel1.add(label2);
        final JTextField field3 = new JTextField();
        field3.setBounds(240, 15, 40, 20);
        panel1.add(field3);
        JLabel label3 = new JLabel("= 0");
        label3.setBounds(290, 15, 50, 20);
        panel1.add(label3);

        //Displays answers
        JLabel label4 = new JLabel("X =");
        label4.setBounds(150, 75, 50, 20);
        panel1.add(label4);
        JLabel label5 = new JLabel("X =");
        label5.setBounds(150, 125, 50, 20);
        panel1.add(label5);
        
        //Combines input fields into array
        JTextField[] field = {field1, field2, field3};
        JButton calc = new JButton("Calculate");
        calc.setBounds(75, 200, 100, 20);
        //Puts array and panel components into calculation when clicked
        calc.addActionListener(new CalculateQuadratic(field, panel1));
        panel1.add(calc);

        JButton clear = new JButton("Clear");
        clear.setBounds(225, 200, 100, 20);
        //Clears input textfields when clicked
        clear.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                field1.setText(null);
                field2.setText(null);
                field3.setText(null);
            }
        });
        panel1.add(clear);

    }

    public void createTab2() {
        panel2 = new JPanel();
        panel2.setLayout(null);

        //V Vector display
        JLabel label1 = new JLabel("V =");
        label1.setBounds(95, 15, 50, 20);
        panel2.add(label1);
        final JTextField field1 = new JTextField();
        field1.setBounds(125, 15, 40, 20);
        panel2.add(field1);
        JLabel label2 = new JLabel("i +");
        label2.setBounds(170, 15, 50, 20);
        panel2.add(label2);
        final JTextField field2 = new JTextField();
        field2.setBounds(185, 15, 40, 20);
        panel2.add(field2);
        JLabel label3 = new JLabel("j +");
        label3.setBounds(230, 15, 50, 20);
        panel2.add(label3);
        final JTextField field3 = new JTextField();
        field3.setBounds(245, 15, 40, 20);
        panel2.add(field3);
        JLabel label4 = new JLabel("k");
        label4.setBounds(290, 15, 50, 20);
        panel2.add(label4);

        //W Vector display
        JLabel label5 = new JLabel("W =");
        label5.setBounds(95, 40, 50, 20);
        panel2.add(label5);
        final JTextField field4 = new JTextField();
        field4.setBounds(125, 40, 40, 20);
        panel2.add(field4);
        JLabel label6 = new JLabel("i +");
        label6.setBounds(170, 40, 50, 20);
        panel2.add(label6);
        final JTextField field5 = new JTextField();
        field5.setBounds(185, 40, 40, 20);
        panel2.add(field5);
        JLabel label7 = new JLabel("j +");
        label7.setBounds(230, 40, 50, 20);
        panel2.add(label7);
        final JTextField field6 = new JTextField();
        field6.setBounds(245, 40, 40, 20);
        panel2.add(field6);
        JLabel label8 = new JLabel("k");
        label8.setBounds(290, 40, 50, 20);
        panel2.add(label8);

        //Single Digit answers
        JLabel label9 = new JLabel("Dot Product");
        label9.setBounds(10, 70, 100, 20);
        panel2.add(label9);
        JLabel label10 = new JLabel("V o W =");
        label10.setBounds(20, 90, 100, 20);
        panel2.add(label10);
        JLabel label11 = new JLabel("Magnitudes");
        label11.setBounds(10, 125, 100, 20);
        panel2.add(label11);
        JLabel label12 = new JLabel("||V|| =");
        label12.setBounds(20, 145, 100, 20);
        panel2.add(label12);
        JLabel label13 = new JLabel("||W|| =");
        label13.setBounds(20, 165, 100, 20);
        panel2.add(label13);

        //Cross Product display     
        JLabel label14 = new JLabel("Cross Product");
        label14.setBounds(140, 70, 100, 20);
        panel2.add(label14);
        JLabel label15 = new JLabel("V x W =");
        label15.setBounds(160, 90, 100, 20);
        panel2.add(label15);
        JLabel label19 = new JLabel("i +");
        label19.setBounds(250, 90, 40, 20);
        panel2.add(label19);
        JLabel label20 = new JLabel("j +");
        label20.setBounds(310, 90, 40, 20);
        panel2.add(label20);
        JLabel label21 = new JLabel("k");
        label21.setBounds(370, 90, 40, 20);
        panel2.add(label21);
        
        //Unit Vector display
        JLabel label16 = new JLabel("Unit Vectors");
        label16.setBounds(140, 125, 100, 20);
        panel2.add(label16);
        JLabel label17 = new JLabel("V =");
        label17.setBounds(160, 145, 100, 20);
        panel2.add(label17);
        JLabel label18 = new JLabel("W =");
        label18.setBounds(160, 165, 100, 20);
        panel2.add(label18);       
        JLabel label22 = new JLabel("i +");
        label22.setBounds(250, 145, 40, 20);
        panel2.add(label22);
        JLabel label23 = new JLabel("j +");
        label23.setBounds(310, 145, 40, 20);
        panel2.add(label23);
        JLabel label24 = new JLabel("k");
        label24.setBounds(370, 145, 40, 20);
        panel2.add(label24);           
        JLabel label25 = new JLabel("i +");
        label25.setBounds(250, 165, 40, 20);
        panel2.add(label25);
        JLabel label26 = new JLabel("j +");
        label26.setBounds(310, 165, 40, 20);
        panel2.add(label26);
        JLabel label27 = new JLabel("k");
        label27.setBounds(370, 165, 40, 20);
        panel2.add(label27);
        
        //Combines input fields into array
        JTextField[] field = {field1, field2, field3, field4, field5, field6};
        JButton calc = new JButton("Calculate");
        calc.setBounds(75, 200, 100, 20);
        calc.addActionListener(new CalculateVectors(field, panel2));
        panel2.add(calc);

        JButton clear = new JButton("Clear");
        clear.setBounds(225, 200, 100, 20);
        clear.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                field1.setText(null);
                field2.setText(null);
                field3.setText(null);
                field4.setText(null);
                field5.setText(null);
                field6.setText(null);
            }
        });
        panel2.add(clear);

    }

    public static void main(String args[]) {
        Main mainFrame = new Main(); // Create starting Frame
        mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //Exits program on close
        mainFrame.setVisible(true); //Displays main window
        mainFrame.setResizable(false); //Disables resizing
        mainFrame.setLocationRelativeTo(null); //Loads up in the center of the screen
    }
}