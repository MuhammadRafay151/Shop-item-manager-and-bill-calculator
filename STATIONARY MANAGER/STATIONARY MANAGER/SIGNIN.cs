using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace STATIONARY_MANAGER
{
    class SIGNIN
    {
        string current_location=Directory.GetCurrentDirectory();
        
        public bool authentication(string password,string username)
        {
            if (File.Exists(current_location + "//authentication.txt")) 
            {
                StreamReader s1 = new StreamReader(File.Open(current_location + "//authentication.txt", FileMode.Open));
                string text = s1.ReadLine();
                s1.Close();
                string[] check = text.Split(' ');
                if (check[0] == username && check[1] == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if( username == "admin" && password == "admin")
                { return true; }
            }
            return false;
            
        }
    }
}
