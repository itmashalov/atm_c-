using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
namespace ATM
{

    public partial class Form2 : Form
    {
        Button btn = new Button();
        Button withdraw = new Button();
        Button check = new Button();
        Button retrn = new Button();
        Button back = new Button();
        Button amt1 = new Button();
        Button amt2 = new Button();
        Button amt3 = new Button();
        Button amt4 = new Button();
        TextBox txt1 = new TextBox();
        TextBox pin = new TextBox();
        Label lab1 = new Label();
        Label lab2 = new Label();

        int[,] acc = { { 300, 1111, 111111 }, { 750, 2222, 222222 }, { 3000, 3333, 333333 } };

        //  ac[1] = new Account(750, 2222, 222222);
        //      ac[2] = new Account(3000, 3333, 333333);

        public Form2()
        {
            this.Size = new System.Drawing.Size(800, 800);
            InitializeComponent();

            lab1.SetBounds(80, 40, 120, 60);
            lab2.SetBounds(80, 110, 120, 60);
            txt1.SetBounds(80, 60, 120, 60);
            pin.SetBounds(80, 60, 120, 60);
            btn.SetBounds(80, 80, 120, 30);
            withdraw.SetBounds(80, 110, 120, 30);
            amt1.SetBounds(0, 60, 50, 30);
            amt2.SetBounds(0, 90, 50, 30);
            amt3.SetBounds(235, 60, 50, 30);
            amt4.SetBounds(235, 90, 50, 30);
            check.SetBounds(80, 140, 120, 30);
            retrn.SetBounds(80, 170, 120, 30);
            back.SetBounds(80, 200, 120, 30);
            btn.BackColor = Color.PowderBlue;
            withdraw.BackColor = Color.PowderBlue;
            amt2.BackColor = Color.PowderBlue;
            amt1.BackColor = Color.PowderBlue;
            amt4.BackColor = Color.PowderBlue;
            amt3.BackColor = Color.PowderBlue;
            check.BackColor = Color.PowderBlue;
            retrn.BackColor = Color.PowderBlue;
            back.BackColor = Color.PowderBlue;
            btn.Click += new EventHandler(this.btnEvent_Click);
            withdraw.Click += new EventHandler(this.withdrawEvent_Click);
            amt2.Click += new EventHandler(this.amt2Event_Click);
            amt3.Click += new EventHandler(this.amt3Event_Click);
            amt4.Click += new EventHandler(this.amt4Event_Click);
            check.Click += new EventHandler(this.checkEvent_Click);
            retrn.Click += new EventHandler(this.retrnEvent_Click);
            back.Click += new EventHandler(this.backEvent_Click);
            amt1.Click += new EventHandler(this.amt1Event_Click);
            Controls.Add(btn);
            Controls.Add(txt1);
            Controls.Add(pin);
            Controls.Add(lab1);
            Controls.Add(lab2);
            Controls.Add(withdraw);
            Controls.Add(amt2);
            Controls.Add(amt3);
            Controls.Add(amt4);
            Controls.Add(retrn);
            Controls.Add(check);
            Controls.Add(back);
            Controls.Add(amt1);
            lab1.Text = "Enter account Number: ";


            lab2.Visible = false;
            pin.Visible = false;

            //String a = (acc[1, 2]).ToString();
            //   btn.Text = a;
            btn.Text = "Enter";
            withdraw.Visible = false;

            retrn.Visible = false;
            check.Visible = false;
            back.Visible = false;
            amt1.Visible = false;
            amt2.Visible = false;
            amt3.Visible = false;
            amt4.Visible = false;
            withdraw.Text = "Withdraw Money";
            amt1.Text = "10";
            amt2.Text = "20";
            amt3.Text = "50";
            amt4.Text = "500";
            check.Text = "Check Balance";
            retrn.Text = "Return Card";
            back.Text = "Back";
            //  txt1.Text = "Enter account ";
            //   txt1.Enabled = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// I use that method to check the account number and the pin using other functions for that purpose this method is activated when you click enter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEvent_Click(object sender, EventArgs e)
        {
            pin.Visible = true;
            if (checkAcc(txt1.Text) == true)
            {

                lab2.Text = "Correct Acc Number! ";
                lab2.Visible = true;
                txt1.Visible = false;
                pin.Visible = true;
                lab1.Text = "Enter Pin:";
                // int milliseconds = 2000;
                //Thread.Sleep(1);
                //  Thread.Sleep(1000);
                if (checkPin(txt1.Text, pin.Text) == true)
                {
                    lab2.Text = "Correct PIN! ";
                    pin.Visible = false;
                    btn.Visible = false;
                    lab2.Visible = false;
                    lab1.Text = "         Welcome";
                    withdraw.Visible = true;
                    check.Visible = true;
                    retrn.Visible = true;
                    back.Visible = false;

                }
                else
                {
                    //  Thread.Sleep(1000);
                    lab2.Text = "Wrong PIN! ";
                }


            }
            else
            {
                lab2.Visible = true;
                lab2.Text = "Wrong Acc Number! ";

                //   txt1.Text = " ";
            }


        }
        /// <summary>
        /// this method is activated when you are logged in already and when you click on withdraw money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void withdrawEvent_Click(object sender, EventArgs e)
        {
            withdraw.Visible = false;
            retrn.Visible = false;
            check.Visible = false;
            amt1.Visible = true;
            amt2.Visible = true;
            amt3.Visible = true;
            amt4.Visible = true;
        }
        /// <summary>
        ///  this method is activated when you are logged in already and when you click to check your balance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void checkEvent_Click(object sender, EventArgs e)
        {
            withdraw.Visible = false;
            retrn.Visible = false;
            check.Visible = false;
            int bal = balance(txt1.Text, pin.Text);
            lab1.Text = "Your Balance is:" + bal + " £";
            back.Visible = true;
        }
        /// <summary>
        /// this method is activated when you are logged in already and when you want to take your card back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void retrnEvent_Click(object sender, EventArgs e)
        {
            withdraw.Visible = false;
            retrn.Visible = false;
            check.Visible = false;
            lab1.Text = "Enter account Number: ";
            btn.Visible = true;
            txt1.Visible = true;
            txt1.Text = "";
            pin.Text = "";
        }
        /// <summary>
        /// I activate that method when you click on the button back and it will return you back in the main menu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backEvent_Click(object sender, EventArgs e)
        {
            back.Visible = false;
            withdraw.Visible = true;
            retrn.Visible = true;
            check.Visible = true;
            lab1.Text = "     Select an option";

            amt1.Visible = false;
            amt2.Visible = false;
            amt3.Visible = false;
            amt4.Visible = false;

        }
        /// <summary>
        /// this button method is created to ask the user if he wants to withdraw certain amount of money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void amt1Event_Click(object sender, EventArgs e)
        {
            int bal = balance(txt1.Text, pin.Text);
            if (bal < 10)
            {
                lab1.Text = "Insufficient Funds";
            }
            else
            {
                setBalance(txt1.Text, pin.Text, 10);
                bal = balance(txt1.Text, pin.Text);
                lab1.Text = "Your Balance is:" + bal + " £"; ;
            }

            back.Visible = true;

        }
        /// <summary>
        /// this button method is created to ask the user if he wants to withdraw certain amount of money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void amt2Event_Click(object sender, EventArgs e)
        {
            int bal = balance(txt1.Text, pin.Text);
            if (bal < 20)
            {
                lab1.Text = "Insufficient Funds";
            }
            else
            {
                setBalance(txt1.Text, pin.Text, 20);
                bal = balance(txt1.Text, pin.Text);
                lab1.Text = "Your Balance is:" + bal + " £"; ;
            }
            back.Visible = true;
        }
        /// <summary>
        /// this button method is created to ask the user if he wants to withdraw certain amount of money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void amt3Event_Click(object sender, EventArgs e)
        {
            int bal = balance(txt1.Text, pin.Text);
            if (bal < 50)
            {
                lab1.Text = "Insufficient Funds";
            }
            else
            {
                setBalance(txt1.Text, pin.Text, 50);
                bal = balance(txt1.Text, pin.Text);
                lab1.Text = "Your Balance is:" + bal + " £"; ;
            }
            back.Visible = true;
        }
        /// <summary>
        /// this button method is created to ask the user if he wants to withdraw certain amount of money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void amt4Event_Click(object sender, EventArgs e)
        {
            int bal = balance(txt1.Text, pin.Text);
            if (bal < 500)
            {
                lab1.Text = "Insufficient Funds";
            }
            else
            {
                setBalance(txt1.Text, pin.Text, 500);
                bal = balance(txt1.Text, pin.Text);
                lab1.Text = "Your Balance is:" + bal + " £"; ;
            }
            back.Visible = true;
        }
        /// <summary>
        /// this boolean method used to check if the entered account number is in the database in our case in our 3d array
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>

        bool checkAcc(String ac)
        {
            for (int i = 0; i < 3; i++)
            {
                String accExist = (acc[i, 2]).ToString();
                if (accExist == ac)
                {
                    return true;

                }




            }
            return false;
        }


        /// <summary>
        /// this boolean method used to check if the entered account number is in the database in our case in our array
        /// </summary>
        /// <param name="ac"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        bool checkPin(String ac, String pin)
        {
            for (int i = 0; i < 3; i++)
            {
                String pinExist = (acc[i, 1]).ToString();
                String accExist = (acc[i, 2]).ToString();
                if (pinExist == pin && accExist == ac)
                {
                    return true;

                }




            }
            return false;
        }
        /// <summary>
        /// i use that method to return the balance 
        /// </summary>
        /// <param name="ac"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        int balance(String ac, String pin)
        {
            for (int i = 0; i < 3; i++)
            {
                String pinExist = (acc[i, 1]).ToString();
                String accExist = (acc[i, 2]).ToString();
                if (pinExist == pin && accExist == ac)
                {
                    return acc[i, 0];

                }





            }
            return 1;
        }
        /// <summary>
        /// i use that method to set the new balance after a withdraw has happend
        /// </summary>
        /// <param name="ac"></param>
        /// <param name="pin"></param>
        /// <param name="amt"></param>
        void setBalance(String ac, String pin, int amt)
        {
            for (int i = 0; i < 3; i++)
            {
                String pinExist = (acc[i, 1]).ToString();
                String accExist = (acc[i, 2]).ToString();
                if (pinExist == pin && accExist == ac)
                {
                    acc[i, 0] = acc[i, 0] - amt;

                }





            }

        }
    }
}
