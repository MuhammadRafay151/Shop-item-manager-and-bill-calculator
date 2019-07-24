using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace STATIONARY_MANAGER
{
    public partial class Form1 : Form
    { bool admin_open = false;
        read r1;
        ArrayList list1 = new ArrayList();
        Image a;
        double wh=0, rt=0;



        public Form1()
        {
            InitializeComponent();
            detail.Hide();
            panel3.Hide();
            panel4.Top = button1.Top;
            
            try {  a = Image.FromFile(Directory.GetCurrentDirectory() + "\\buttontheme.png");

                button1.BackgroundImage = a;
            }
            catch(FileNotFoundException)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(a!=null)
            {
                button1.BackgroundImage = a;
                button2.BackgroundImage = null;
                button3.BackgroundImage = null;

            }
            
            panel4.Top = button1.Top;
            panel4.Height = button1.Height;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ADMIN")
                {
                    f.BringToFront();
                    admin_open = true;
                    break;
                }
                else
                    admin_open = false;
            }
            if (admin_open == false)
            {
                ADMIN a1 = new ADMIN();
                a1.MdiParent = this;
                panel2.Controls.Add(a1);
                a1.Show();
                a1.Dock = DockStyle.Fill;
                a1.BringToFront();
                
              
            }
           
         
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(a!=null)
            {
                button2.BackgroundImage = a;
                button1.BackgroundImage = null;
                button3.BackgroundImage = null;
            }
           
            panel4.Top = button2.Top;
            panel4.Height = button2.Height;
            detail.Show();
            detail.BringToFront();
            listBox1.Items.Clear();
             r1 = new read();
            int i = r1.read_data();
            //MessageBox.Show(i.ToString());
            for(int a=0;a<i-1;a++)
            {
                listBox1.Items.Add(r1.item_adder(a));
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            detail.Hide();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            label1.Text = "WHOLE SALE PRICE "+ r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex)-2].ToString();
            label2.Text = "RETAIL PRICE PRICE " + r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 1];
            if(double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 1]) - double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 2])>0)
            label3.Text = "PROFIT OF "+(double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 1]) - double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 2])).ToString()+" RUPEES";
            else
                label3.Text = "LOSS OF " + (double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 1]) - double.Parse(r1[listBox1.SelectedIndex, r1.sub_index(listBox1.SelectedIndex) - 2])).ToString() + " RUPEES";


        }

        private void button3_Click(object sender, EventArgs e)
        {if(a!=null)
            {
                button3.BackgroundImage = a;
                button2.BackgroundImage = null;
                button1.BackgroundImage = null;
            }
           
            panel4.Top = button3.Top;
            panel4.Height = button3.Height;
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            panel3.Show();
            panel3.BringToFront();
            r1 = new read();
            int i = r1.read_data();
            //MessageBox.Show(i.ToString());
            for (int a = 0; a < i - 1; a++)
            {
                listBox2.Items.Add(r1.item_adder(a));
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("PLease select an item from right list and then press \"ADD\" button\nIf you want to remove item from bill list select that particular item from bill list and then press\"REMOVE FROM BILL BUTTON\"\n\t\t***THANLK YOU***");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.Add(listBox2.SelectedItem);

                list1.Add(r1[listBox2.SelectedIndex, r1.sub_index(listBox2.SelectedIndex) - 2]);
                list1.Add(r1[listBox2.SelectedIndex, r1.sub_index(listBox2.SelectedIndex) - 1]);
                label4.Text = "W.H.RATE";
                label5.Text = "R.T.RATE";
                wh = 0;
                rt = 0;
                for (int i = 0; i < list1.Count; i++)
                {
                    label4.Text += "\n" + list1[i];
                    wh += Convert.ToDouble(list1[i]);
                    i++;
                    label5.Text += "\n" + list1[i];
                    rt += Convert.ToDouble(list1[i]);
                }
          
                label6.Text = "Total whole sale rate=" + wh.ToString();
                label7.Text = "Total Retail rate=" + rt.ToString();
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("PLEASE SELECT ITEM ");
            }
           
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try {
                int selectindex = listBox3.SelectedIndex;
                wh =wh-Convert.ToDouble( list1[selectindex]);
                rt = rt-Convert.ToDouble(list1[selectindex+1]);
                label6.Text = "Total whole sale rate=" + wh.ToString();
                label7.Text = "Total Retail rate=" + rt.ToString();
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
          
                list1.RemoveAt(selectindex);
        
            list1.RemoveAt(selectindex);
                label4.Text = "W.H.RATE";
                label5.Text = "R.T.RATE";
               
                for (int i = 0; i < list1.Count; i++)
                {
                    label4.Text += "\n" + list1[i];
                    i++;
                   label5.Text += "\n" + list1[i];
                }
           }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("PLEASE SELECT ITEM");
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
    }
}
