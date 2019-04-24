using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc1
{
    public partial class Form1 : Form
    {
        Brain brain;
        public Form1()
        {
            InitializeComponent();
            ShowResultDelegate showResult = new ShowResultDelegate(DisplayText);
            brain = new Brain(showResult);
        }
      

       private  void DisplayText(string msg)
        {
            textBox1.Text = msg;
        }
        

        public void btnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            brain.Process(button.Text);
        }
    }
}
