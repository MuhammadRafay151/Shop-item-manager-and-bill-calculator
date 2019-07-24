using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace STATIONARY_MANAGER
{
    class read
    {
        string[] d1;
        string[][] d2;
        
       
        public string file_data;
        
        
        public int read_data()
        {
           file_data= File.ReadAllText(Directory.GetCurrentDirectory() + "//items.txt");
            
            d1 = file_data.Split('\n');
            d2 = new string[d1.Length][];
            for(int i=0;i<d1.Length;i++)
            {
                d2[i] = d1[i].Split(' ');
            }
            return d1.Length;
        }
        public string this[int i,int j]
        {
            get { return d2[i][j]; }
        }
        public string item_adder(int i)
        {
            int j=d2[i].Length - 2;
            string item=null;

            for(int a=0;a<j;a++)
            {
               item += d2[i][a]+" ";
            }
            return item;

        }
        public int sub_index(int i)
        {//jacgged array ky ander jo array hy uske length return ker rha hy ye...
            return d2[i].Length;
        }
        public void item_delete(int index_no)
        {
            
            Array.Clear(d2, index_no, 1);
           
        }
        public void write_data()
        {
            StreamWriter s1 = new StreamWriter(File.Open(Directory.GetCurrentDirectory() + "//items.txt", FileMode.Create));
            //write data to file after item delete...
            for(int i=0;i<d2.Length-1;i++)
            { string x=null;
                try {
                    for (int j = 0; j < d2[i].Length; j++)
                    {
                        if (j < d2[i].Length - 1)
                            x += d2[i][j] + " ";
                        else
                            x += d2[i][j];

                    }
                    s1.Write(x + "\n");
                }
                catch(NullReferenceException)
                {
                    continue;
                }
                

            }
            s1.Close();
        }
    }
    
}
