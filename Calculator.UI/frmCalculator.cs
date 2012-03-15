using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculator.BL;

namespace Calculator.UI
{
    public partial class frmCalculator : Form
    {
        CCalculator oCalculator;

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            oCalculator = new CCalculator();
        }


        // back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = oCalculator.Back();
        }
        //clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = oCalculator.Clear();
            lblOperator.Text = string.Empty;
        }


        // 0-9 number keys
        private void btnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnSender = (Button)sender;

                lblDisplay.Text = oCalculator.NumberKey(btnSender.Text).ToString();
            }
        }
        // decimal
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = oCalculator.DecimalKey().ToString();
        }


        // operators
        private void btnOperatorClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button)
                {
                    Button btnSender = (Button)sender;

                    if (oCalculator.SetOperator(btnSender.Text))
                    {
                        lblOperator.Text = oCalculator.Operator;
                    }
                    lblDisplay.Text = oCalculator.Number.ToString();

                }
            }
            catch (Exception ex)
            {
                oCalculator.Clear();
                lblOperator.Text = string.Empty;
                lblDisplay.Text = ex.Message;
            }
        }

        // = key
        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                lblDisplay.Text = oCalculator.Calc(true).ToString();
                lblOperator.Text = string.Empty;
            }
            catch (Exception ex)
            {
                oCalculator.Clear();
                lblOperator.Text = string.Empty;
                lblDisplay.Text = ex.Message;
            }
        }
    }
}
