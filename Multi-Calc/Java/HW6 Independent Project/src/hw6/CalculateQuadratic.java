package hw6;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

/*
 * @author Elbert
 */
public class CalculateQuadratic implements ActionListener {
    private JPanel panel;
    private JTextField[] field;

    public CalculateQuadratic(JTextField[] f, JPanel p) {
        this.field = f;
        this.panel = p;
    }

    @Override
    public void actionPerformed(ActionEvent ae) {
        //Assign variables to corresponding textboxes
        double a = Double.parseDouble(field[0].getText());
        double b = Double.parseDouble(field[1].getText());
        double c = Double.parseDouble(field[2].getText());
        //Assigns d as equation under radical to see if X(s) will become
        //Real or Imaginary
        double d = ((b * b) - (4 * a * c));
        
        if (d >= 0) { //Executes if Real answers will be given
            double x1 = (-b + Math.sqrt(d)) / (2 * a);
            double x2 = (-b - Math.sqrt(d)) / (2 * a);

            JTextField field4 = new JTextField("" + x1);
            field4.setBounds(170, 75, 100, 20);
            field4.setEditable(false);
            panel.add(field4);

            if (x1 != x2) { //If both x's are different
                JTextField field5 = new JTextField("" + x2);
                field5.setBounds(170, 125, 100, 20);
                field5.setEditable(false);
                panel.add(field5);
            }

        } else if (d < 0) { //executes if answer will become imaginary
            JOptionPane.showMessageDialog(null, "Unreal Answer");
        }
    }
}
