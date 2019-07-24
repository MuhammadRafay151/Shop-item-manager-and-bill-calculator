using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace STATIONARY_MANAGER
{
    public partial class ADMIN : Form
    {
        read r1;
        string current_location=Directory.GetCurrentDirectory();
        public ADMIN()
        {
            InitializeComponent();
            panel2.BringToFront();
                   }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel2.BringToFront();
            item.Clear();
            wsp.Clear();
            rp.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                SIGNIN s1 = new SIGNIN();
                if (s1.authentication(textBox2.Text, textBox1.Text))
                {
                    panel2.Hide();
                    panel1.Show();
                    panel1.BringToFront();
                    textBox1.Clear();
                    textBox2.Clear();
                    r1 = new read();
                    int i = r1.read_data();
                    MessageBox.Show(i.ToString());
                    for (int a = 0; a < i - 1; a++)
                    {
                        listBox1.Items.Add(r1.item_adder(a));
                    }

                }
                else
                {
                    timer1.Start();
                    label6.Visible = true;
                }
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("EMPTY FIELDS");
            }
            catch(FileNotFoundException)
            { }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(timer1.Interval==2000)
            {
                timer1.Stop();
                label6.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double.Parse(wsp.Text);
                double.Parse(rp.Text);
                if (string.IsNullOrWhiteSpace(item.Text) || string.IsNullOrWhiteSpace(wsp.Text) || string.IsNullOrWhiteSpace(rp.Text))
                {
                    MessageBox.Show("Please fill all the fields");
                }
                else
                {
                    StreamWriter s1 = new StreamWriter(File.Open(current_location + "//items.txt", FileMode.Append));
                    s1.Write(item.Text.ToUpper() + " ");
                    s1.Write(wsp.Text.ToUpper() + " ");
                    s1.Write(rp.Text.ToUpper() + "\r\n");
                    s1.Close();

                }
                item.Clear();
                wsp.Clear();
                rp.Clear();
                label7.Text = "PROFIT";
            }
            catch(FormatException)
            {
                MessageBox.Show("PRICE MUST BE IN DIGITS");
            }
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               
                double i = double.Parse(rp.Text) - double.Parse(wsp.Text);
                if(i>0)
                label7.Text = "PROFIT OF "+i.ToString()+" RUPEES";
                else
                    label7.Text = "LOSS OF " + i.ToString() + " RUPEES";
            }
            catch(FormatException)
            {
                MessageBox.Show("AMOUNT IS NOT IN CORRECT FORMAT");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            r1.item_delete(listBox1.SelectedIndex);
            r1.write_data();
            listBox1.Items.Clear();
            r1 = new read();
            int i = r1.read_data();
            //MessageBox.Show(i.ToString());
            for (int a = 0; a < i - 1; a++)
            {
                listBox1.Items.Add(r1.item_adder(a));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
