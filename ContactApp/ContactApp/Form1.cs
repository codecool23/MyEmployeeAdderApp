using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApp
{
    public partial class Form1 : Form
    {
        //array
        private Contact[] nameBook = new Contact[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void Write(Contact obj)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine(nameBook.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for(int i = 0; i < nameBook.Length; i++)
            {
                sw.WriteLine(nameBook[i].FirstName);
                sw.WriteLine(nameBook[i].LastName);
                sw.WriteLine(nameBook[i].Phone);
            }

            sw.Close();
        }

        private void Read()
        {
            StreamReader sr = new StreamReader("Contacts.txt");
            nameBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for ( int i = 0; i < nameBook.Length; i++)
            {
                nameBook[i] = new Contact();
                nameBook[i].FirstName = sr.ReadLine();
                nameBook[i].LastName = sr.ReadLine();
                nameBook[i].Phone = sr.ReadLine();
                
            }

            sr.Close();

        }

        private void Display()
        {
            lstContacts.Items.Clear();

            for( int i = 0; i < nameBook.Length; i++)
            {
                lstContacts.Items.Add(nameBook[i].ToString());
            }
        }

        private void ClearList()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.Phone = txtPhone.Text;

            Write(obj);
            NameSort();
            Read();
            Display();
            ClearList();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameSort();
            Display();
        }

        private void NameSort()
        {
            Contact temp;
            bool swap;

            do
            {
                swap = false;

                for (int i = 0; i < (nameBook.Length - 1); i++)
                {
                    if(nameBook[i].LastName.CompareTo(nameBook[i+1].LastName) > 0)
                    {
                        temp = nameBook[i];
                        nameBook[i] = nameBook[i + 1];
                        nameBook[i + 1] = temp;
                        swap = true;
                    }
                }


            } while (swap == true);
        }
    }
}
