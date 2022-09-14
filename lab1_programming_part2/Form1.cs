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
                case 0:// создание объекта автомобиля 
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
                    button1.Enabled = true;
                    if (automobile is null)
                        comboBox1.Enabled = false;
                    break;
                case 1:// прохождение ТО
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
                    textboxs[4].Text = "";

                    labels[4].Visible = true;
                    labels[4].Text = "год прохождения ТО";

                    break;
                case 2://выписывание штрафа
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
                    textboxs[4].Text = "";

                    labels[4].Visible = true;
                    labels[4].Text = "Размер штрафа";

                    break;
                case 3:
                    foreach (var item in textboxs)
                    {
                        item.Enabled = true;
                        item.Visible = true;
                        item.Text = "";
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
                    textboxs[4].Text = automobile.Brand;
                    textboxs[3].Text = automobile.Model;
                    textboxs[2].Text = automobile.YearOFIssue.ToString();
                    textboxs[1].Text = automobile.YearOfTecnicalInspection.ToString();
                    textboxs[0].Text = automobile.Owner;
                    button1.Enabled = true;
                    if (automobile is null)
                        comboBox1.Enabled = false;
                    break;
                case 4:
                   
                    foreach (var item in textboxs)
                    {
                        item.Enabled = false;
                        item.Visible = false;
                        item.Text = "";
                    }
                    foreach (var item in labels)
                    {
                        item.Visible = false;
                    }
                    labels[4].Visible = true;
                    labels[4].Text = "владелец";

                    textboxs[4].Enabled = true;
                    textboxs[4].Visible = true;
                    textboxs[4].Text = automobile.Owner;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:// создание объекта автомобиля 
                    try
                    {
                        var brand = textboxs[4].Text;
                        var model = textboxs[3].Text;
                        var yearOFIssue = short.Parse(textboxs[2].Text);
                        var yearOfTecnicalInspection = short.Parse(textboxs[1].Text);
                        var onwer = textboxs[0].Text;
                        automobile = new Automobile(brand, model, yearOFIssue, yearOfTecnicalInspection, onwer);
                        comboBox1.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message); 
                    }
                    break;
                case 1:// прохождение ТО
                    try
                    {
                        var yearOfTecnicalInspection = short.Parse(textboxs[4].Text);
                        automobile?.PassMOT(yearOfTecnicalInspection);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                    break;
                case 2://выписывание штрафа 
                    try
                    {
                        var fine = int.Parse(textboxs[4].Text);
                        automobile?.IssueFine(fine);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                    break;
                case 3:
                    // в этом случае кнопка не нужна 
                    break;

            }
        }
    }
}
