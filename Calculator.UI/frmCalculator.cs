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
            lblDisplay.Text = string.Empty;
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
        }


        // 0-9 number keys
        private void btnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnSender = (Button)sender;

                lblDisplay.Text = oCalculator.NumberKey(btnSender.Name[3]);
            }
        }
        // decimal
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (oCalculator.DecUsed() == -1)
            {
                lblDisplay.Text = oCalculator.NumberKey('.');
            }
        }


        // +,-,*,/ operators
        private void btnOperatorClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnSender = (Button)sender;

                lblOperator.Text = oCalculator.SetOperatorByLetter(btnSender.Name[3]);
            }
        }

    }
}
