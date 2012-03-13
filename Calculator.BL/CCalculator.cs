using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.BL
{
    public class CCalculator
    {
        #region Properties

        private string msNumber = string.Empty;
        private double mdNumber;

        private double mdNum1, mdNum2;
        private char msOperator;

        private bool mbFirst;


        #endregion

        #region Numbers

        public string NumberKey(char vcKey)
        {
            msNumber += vcKey;
            return msNumber;
        }

        public int DecUsed()
        {
            return msNumber.IndexOf('.');
        }

        #endregion

        #region Operations

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public void Subtract()
        {
            throw new System.NotImplementedException();
        }

        public void Multiply()
        {
            throw new System.NotImplementedException();
        }

        public void Divide()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region AdvOperations

        public void SquareRoot()
        {
            throw new System.NotImplementedException();
        }

        public void Inverse()
        {
            throw new System.NotImplementedException();
        }

        public void FlipSign()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public string Calc()
        {
            switch (msOperator)
            {
                case '+':
                    mdNumber = mdNum1 + mdNum2;
                    break;
                case '-':
                    mdNumber = mdNum1 - mdNum2;
                    break;
                case '*':
                    mdNumber = mdNum1 * mdNum2;
                    break;
                case '/':
                    mdNumber = mdNum1 / mdNum2;
                    break;
            }

            msNumber = mdNumber.ToString();
            return msNumber;
        }

        public string Back()
        {
            if (msNumber.Length > 0)
            {
                // get rid of last character
                msNumber = msNumber.Remove(msNumber.Length - 1);
            }

            return msNumber;
        }

        public string Clear()
        {
            msNumber = string.Empty;

            return msNumber;
        }


        public string SetOperatorByLetter(char vcLetter)
        {
            switch (vcLetter)
            {
                case 'A':
                    SetOperator('+');
                    break;
                case 'S':
                    SetOperator('-');
                    break;
                case 'M':
                    SetOperator('*');
                    break;
                case 'D':
                    SetOperator('/');
                    break;
            }
            if (mbFirst)
            {
                mdNum1 = mdNumber;
            }
            else
            {
                mdNum2 = mdNumber;
            }
            mbFirst = !mbFirst;

            return msOperator.ToString();
        }

        private void SetOperator(char vcOperator)
        {
            msOperator = vcOperator;
        }

    }
}
