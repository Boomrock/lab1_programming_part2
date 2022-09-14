using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Library;
namespace lab1_programming_part2
{
    public partial class Form1 : Form
    {
        Automobile automobile;
        List<Control> textboxs, labels;
        public Form1()
        {
            InitializeComponent();
            labels = new List<Control>();
            textboxs = new List<Control>();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                    textboxs.Add(item);
                if (item is Label)
                    labels.Add(item);
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    foreach (var item in textboxs)
                    {
                        item.Enabled = true;
                        item.Visible = true;
                    }
                    foreach (var item in labels)
                    {
                        item.Visible = true;
                    }
                    labels[4].Text = "марка";
                    labels[3].Text = "модель";
                    labels[2].Text = "год выпуска";
                    labels[1].Text = "год прохождения ТО";
                    labels[0].Text = "владелец";
                    break;
                case 1:
                    foreach (var item in textboxs)
                    {
                        item.Enabled = false;
                        item.Visible = false;

                    }
                    foreach (var item in labels)
                    {
                        item.Visible = false;

                    }
                    textboxs[4].Enabled = true;
                    textboxs[4].Visible = true;
                    labels[4].Visible = true;
                    labels[4].Text = "год прохождения ТО";
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    try
                    {
                        var brand = textboxs[4].Text;
                        var model = textboxs[3].Text;
                        var yearOFIssue = short.Parse(textboxs[2].Text);
                        var yearOfTecnicalInspection = short.Parse(textboxs[1].Text);
                        var onwer = textboxs[0].Text;
                        automobile = new Automobile(brand, model, yearOFIssue, yearOfTecnicalInspection, onwer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message); 
                    }
                    break;
                case 1:
                    try
                    {
                        var yearOfTecnicalInspection = short.Parse(textboxs[0].Text);
                        automobile.PassMOT(yearOfTecnicalInspection);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                        
                    }
                    break;

            }
        }
    }
}
