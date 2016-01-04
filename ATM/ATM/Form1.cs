using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Form1 : Form
    {
        Button btn = new Button();

        public Form1()
        {
          //  InitializeComponent();
            btn.SetBounds(60, 60, 120, 60);
            btn.BackColor = Color.PowderBlue;
            btn.Click += new EventHandler(this.btnEvent_Click);
            Controls.Add(btn);
            btn.Text = "Open ATM";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void btnEvent_Click(object sender, EventArgs e)
        {
            System.Threading.Thread atm =
               new System.Threading.Thread(new System.Threading.ThreadStart(starter));
            atm.Start();
            // btn.BackColor = Color.Red;
            // Form2 openAtm = new Form2();
            //  openAtm.Show();


        }

        //Starts the ATM form, method used in the upper 
        private void starter()
        {
            Application.Run(new Form2());
        }

    }

}
