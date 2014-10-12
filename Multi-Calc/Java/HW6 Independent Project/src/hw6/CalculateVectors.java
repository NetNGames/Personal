package hw6;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

/*
 * @author Elbert
 */
public class CalculateVectors implements ActionListener {

    private JPanel panel;
    private JTextField[] field;

    public CalculateVectors(JTextField[] f, JPanel p) {
        this.field = f;
        this.panel = p;
    }

    @Override
    public void actionPerformed(ActionEvent ae) {
        //Assign variables to corresponding textboxes
        double v1 = Double.parseDouble(field[0].getText());
        double v2 = Double.parseDouble(field[1].getText());
        double v3 = Double.parseDouble(field[2].getText());
        double w1 = Double.parseDouble(field[3].getText());
        double w2 = Double.parseDouble(field[4].getText());
        double w3 = Double.parseDouble(field[5].getText());
        double Dot = v1 * w1 + v2 * w2 + v3 * w3;
        double MagV = Math.sqrt((v1 * v1) + (v2 * v2) + (v3 * v3));
        double MagW = Math.sqrt((w1 * w1) + (w2 * w2) + (w3 * w3));
        double UnitV1 = v1 / MagV;
        double UnitV2 = v2 / MagV;
        double UnitV3 = v3 / MagV;
        double UnitW1 = w1 / MagW;
        double UnitW2 = w2 / MagW;
        double UnitW3 = w3 / MagW;
        double CrossX = (v2 * w3 - v3 * w2);
        double CrossY = (v3 * w1 - v1 * w3);
        double CrossZ = (v1 * w2 - v2 * w1);


        JTextField field7 = new JTextField("" + Dot);
        field7.setBounds(70, 90, 50, 20);
        panel.add(field7);
        JTextField field8 = new JTextField("" + MagV);
        field8.setBounds(70, 145, 50, 20);
        panel.add(field8);
        JTextField field9 = new JTextField("" + MagW);
        field9.setBounds(70, 165, 50, 20);
        panel.add(field9);
        JTextField field10 = new JTextField("" + CrossX);
        field10.setBounds(205, 90, 40, 20);
        panel.add(field10);
        JTextField field13 = new JTextField("" + CrossY);
        field13.setBounds(265, 90, 40, 20);
        panel.add(field13);
        JTextField field14 = new JTextField("" + CrossZ);
        field14.setBounds(325, 90, 40, 20);
        panel.add(field14);
        JTextField field11 = new JTextField("" + UnitV1);
        field11.setBounds(205, 145, 40, 20);
        panel.add(field11);
        JTextField field15 = new JTextField("" + UnitV2);
        field15.setBounds(265, 145, 40, 20);
        panel.add(field15);
        JTextField field16 = new JTextField("" + UnitV3);
        field16.setBounds(325, 145, 40, 20);
        panel.add(field16);
        JTextField field12 = new JTextField(""+ UnitW1);
        field12.setBounds(205, 165, 40, 20);
        panel.add(field12);
        JTextField field17 = new JTextField(""+ UnitW2);
        field17.setBounds(265, 165, 40, 20);
        panel.add(field17);
        JTextField field18 = new JTextField(""+ UnitW3);
        field18.setBounds(325, 165, 40, 20);
        panel.add(field18);
    }
}