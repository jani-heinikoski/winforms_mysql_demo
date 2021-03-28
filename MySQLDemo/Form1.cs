using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLDemo
{
    public partial class Form1 : Form
    {
        private DataManager dataManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataManager = DataManager.GetInstance();
            List<Customer> customers = dataManager.getCustomers();

            if (customers != null)
            {
                Console.WriteLine($"Found {customers.Count} customers:");
                foreach (Customer c in customers) {
                    Console.WriteLine($"{c.getID()}|{c.getName()}");
                }
            }
            
        }
    }
}
