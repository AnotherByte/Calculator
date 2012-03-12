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

    }
}
