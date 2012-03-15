using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.BL
{
    public class CCalculator
    {
        #region Properties

        private string msNumber;

        private double mdNumber1;
        public double Number
        {
            get { return mdNumber1; }
        }

        private double mdNumber2;
        private double mdNumber3;
        private double mdNumberLast;

        private string msOperator1;
        private string msOperator2;
        private string msOperatorLast;
        public string Operator
        {
            get { return msOperator1; }
        }

        //something in first block
        private bool mbFirst;
        //something in second block
        private bool mbSecond;
        //something in third block
        private bool mbThird;
        private bool mbInput;

        public CCalculator()
        {
            this.Clear();
        }

        #endregion

        #region Methods

        public double NumberKey(string vsKey)
        {
            if (!mbInput)
            {
                mdNumber1 = 0;
                mbInput = true;
            }

            if (mdNumber1 == 0)
            {
                double.TryParse(vsKey, out mdNumber1);
                msNumber = mdNumber1.ToString();
            }
            else
            {
                msNumber += vsKey;
                double.TryParse(msNumber, out mdNumber1);
            }

            mbFirst = true;
            return mdNumber1;
        }

        public double DecimalKey()
        {
            if (msNumber.IndexOf('.') == -1)
            {
                msNumber += '.';
                double.TryParse(msNumber, out mdNumber1);
            }

            return mdNumber1;
        }


        // returns bool, true to say "go get operator", false to say "go get number1"
        public bool SetOperator(string vsOperator)
        {
            mbInput = false;
            bool bOutcome = true;

            if (mbFirst)
            {
                if (vsOperator == "sqrt")
                {
                    mdNumber1 = Math.Sqrt(mdNumber1);
                    msNumber = mdNumber1.ToString();
                    bOutcome = false;
                }
                else if (vsOperator == "1/X")
                {
                    if (mdNumber1 == 0)
                    { throw new Exception("Divide by Zero Error"); }

                    mdNumber1 = 1 / mdNumber1;
                    msNumber = mdNumber1.ToString();
                    bOutcome = false;
                }
                else if (vsOperator == "+/-")
                {
                    mdNumber1 = -1 * mdNumber1;
                    msNumber = mdNumber1.ToString();
                    bOutcome = false;
                }
                else if (mbFirst && !mbSecond)
                {
                    // only one number
                    mdNumber2 = mdNumber1;
                    mdNumber1 = 0;

                    mbFirst = false;
                    mbSecond = true;

                    msOperator1 = vsOperator;
                    return true;
                }
                else if (mbFirst && mbSecond && !mbThird)
                {
                    // two numbers, not 3
                    // check for order-of-op to see if you calculate the already entered numbers
                    if (vsOperator == "*" || vsOperator == "/")
                    {
                        // check for previous operator
                        if (msOperator1 == "*" || msOperator1 == "/")
                        {
                            // op1 has order of precedence
                            // calculate previous (op1)
                            this.Calc(false);
                            // go back through now with only one number
                            bOutcome = this.SetOperator(vsOperator);
                        }
                        else
                        {
                            // op1 is + or -
                            // op2 is calc first
                            // move data up
                            mdNumber3 = mdNumber2;
                            mdNumber2 = mdNumber1;
                            mdNumber1 = 0;

                            mbFirst = false;
                            mbSecond = true;
                            mbThird = true;

                            msOperator2 = msOperator1;
                            msOperator1 = vsOperator;
                            bOutcome = true;
                        }
                    }
                    else if (vsOperator == "+" || vsOperator == "-")
                    {
                        // op1 has order of precedence
                        // calculate previous (op1)
                        this.Calc(false);
                        // go back through now with only one number
                        bOutcome = this.SetOperator(vsOperator);
                    }
                }
                else if (mbFirst && mbSecond && mbThird)
                {
                    // all three numbers
                    // op1 (second entered op) must have greater precedence than op2 (first entered op)
                    // calc n1 op1 n2 (most recent two entered numbers and most recent op)
                    this.Calc(false);
                    // go back through now with only two numbers
                    bOutcome = this.SetOperator(vsOperator);
                }
            }
            else
            {
                if (mbSecond)
                {
                    // user changed mind on operator
                    // move data back, send through again

                    mdNumber1 = mdNumber2;

                    mbFirst = true;


                    if (mbThird)
                    {
                        mdNumber2 = mdNumber3;
                        mdNumber3 = 0;

                        mbSecond = true;
                        mbThird = false;

                        msOperator1 = msOperator2;
                    }
                    else
                    {
                        mdNumber2 = 0;
                        mbSecond = false;
                    }

                    bOutcome = this.SetOperator(vsOperator);
                }
                if (mbSecond && mbThird)
                {
                    // user changed mind on operator
                    // move data back, send through again

                    mdNumber1 = mdNumber2;
                    mdNumber2 = mdNumber3;
                    mdNumber3 = 0;

                    mbFirst = true;
                    mbSecond = true;
                    mbThird = false;

                    msOperator1 = msOperator2;

                    bOutcome = this.SetOperator(vsOperator);
                }
            }

            return bOutcome;
        }


        public double Calc(bool bCalcFully)
        {
            if (mbFirst && !mbSecond)
            {
                // hitting "=" again to do same calculation
                msOperator1 = msOperatorLast;
                mdNumber2 = mdNumber1;
                mdNumber1 = mdNumberLast;
            }

            mdNumberLast = mdNumber1;
            msOperatorLast = msOperator1;

            switch (msOperator1)
            {
                case "+":
                    mdNumber1 = mdNumber2 + mdNumber1;
                    break;
                case "-":
                    mdNumber1 = mdNumber2 - mdNumber1;
                    break;
                case "*":
                    mdNumber1 = mdNumber2 * mdNumber1;
                    break;
                case "/":
                    if (mdNumber1 == 0)
                    { throw new Exception("Divide by Zero Error"); }
                    mdNumber1 = mdNumber2 / mdNumber1;
                    break;
            }

            if (mbThird)
            {
                mdNumber2 = mdNumber3;
                msOperator1 = msOperator2;

                mbFirst = true;
                mbSecond = true;
                mbThird = false;

                if (bCalcFully)
                {
                    // if user hit "=" to get here, keep going
                    this.Calc(false);
                }
            }
            else
            {
                mbFirst = true;
                mbSecond = false;
                mbThird = false;
            }

            mbInput = false;
            msNumber = mdNumber1.ToString();
            return mdNumber1;
        }

        public string Back()
        {
            if (mbInput && msNumber.Length > 0)
            {
                // get rid of last character
                msNumber = msNumber.Remove(msNumber.Length - 1);

                if (msNumber == "")
                {
                    mdNumber1 = 0;
                    msNumber = "0";
                }
            }

            return msNumber;
        }

        public string Clear()
        {
            mdNumber1 = 0;
            mdNumber2 = 0;
            mdNumber3 = 0;
            mdNumberLast = 0;

            mbInput = true;
            mbFirst = false;
            mbSecond = false;
            mbThird = false;

            msNumber = "0";
            msOperator1 = string.Empty;
            msOperator2 = string.Empty;
            msOperatorLast = string.Empty;

            return msNumber;
        }


        #endregion

    }
}
