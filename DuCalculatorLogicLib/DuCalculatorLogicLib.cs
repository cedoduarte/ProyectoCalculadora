using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuCalculatorLogicLib
{
    public class CalculatorLogicLib
    {
        public CalculatorLogicLib()
        {
            sumInMemory = 0.0;
            sumSoFar = 0.0;
            factorSoFar = 0.0;
            waitingForOperand = true;
            pendingAdditiveOperator = "";
            pendingMultiplicativeOperator = "";
        }

        public void abortOperation(ref string display)
        {
            clearAll(ref display);
            display = "####";
        }

        public bool calculate(double rightOperand, ref string pendingOperator)
        {
            if (pendingOperator.Equals("+"))
            {
                sumSoFar += rightOperand;
            }
            else if (pendingOperator.Equals("-"))
            {
                sumSoFar -= rightOperand;
            }
            else if (pendingOperator.Equals("*"))
            {
                factorSoFar *= rightOperand;
            }
            else if (pendingOperator.Equals("/"))
            {
                if (rightOperand == 0.0)
                    return false;
                factorSoFar /= rightOperand;
            }
            return true;
        }

        public void pointClicked(ref string display)
        {
            if (waitingForOperand)
                display = "0";
            if (!display.Contains("."))
                display= display + ".";
            waitingForOperand = false;
        }

        public void unaryOperatorClicked(string clickedOperator, ref string display)
        {
            try
            {
                double operand = Convert.ToDouble(display);
                double result = 0.0;
                if (clickedOperator == "Sqrt")
                {
                    if (operand < 0.0)
                    {
                        abortOperation(ref display);
                        return;
                    }
                    result = Math.Sqrt(operand);
                }
                else if (clickedOperator == "x^2")
                {
                    result = Math.Pow(operand, 2.0);
                }
                else if (clickedOperator == "1/x")
                {
                    if (operand == 0.0)
                    {
                        abortOperation(ref display);
                        return;
                    }
                    result = 1.0 / operand;
                }
                display = result.ToString();
                waitingForOperand = true;
            }
            catch (Exception)
            {
            }
        }

        public void additiveOperatorClicked(string clickedOperator, ref string display)
        {
            try
            {
                double operand = Convert.ToDouble(display);
                if (pendingMultiplicativeOperator.Length != 0)
                {
                    if (!calculate(operand, ref pendingMultiplicativeOperator))
                    {
                        abortOperation(ref display);
                        return;
                    }
                    display = factorSoFar.ToString();
                    operand = factorSoFar;
                    factorSoFar = 0.0;
                    pendingMultiplicativeOperator = "";
                }
                if (pendingAdditiveOperator.Length != 0)
                {
                    if (!calculate(operand, ref pendingAdditiveOperator))
                    {
                        abortOperation(ref display);
                        return;
                    }
                    display = sumSoFar.ToString();
                }
                else
                {
                    sumSoFar = operand;
                }
                pendingAdditiveOperator = clickedOperator;
                waitingForOperand = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void multiplicativeOperatorClicked(string clickedOperator, ref string display)
        {
            try
            {
                double operand = Convert.ToDouble(display);
                if (pendingMultiplicativeOperator.Length != 0)
                {
                    if (!calculate(operand, ref pendingMultiplicativeOperator))
                    {
                        abortOperation(ref display);
                        return;
                    }
                    display = factorSoFar.ToString();
                }
                else
                {
                    factorSoFar = operand;
                }
                pendingMultiplicativeOperator = clickedOperator;
                waitingForOperand = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void equalClicked(ref string display)
        {
            try
            {
                double operand = Convert.ToDouble(display);
                if (pendingMultiplicativeOperator.Length != 0)
                {
                    if (!calculate(operand, ref pendingMultiplicativeOperator))
                    {
                        abortOperation(ref display);
                        return;
                    }
                    operand = factorSoFar;
                    factorSoFar = 0.0;
                    pendingMultiplicativeOperator = "";
                }
                if (pendingAdditiveOperator.Length != 0)
                {
                    if (!calculate(operand, ref pendingAdditiveOperator))
                    {
                        abortOperation(ref display);
                        return;
                    }
                    pendingAdditiveOperator = "";
                }
                else
                {
                    sumSoFar = operand;
                }
                display = sumSoFar.ToString();
                sumSoFar = 0.0;
                waitingForOperand = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void digitClicked(int digitValue, ref string display)
        {
            if (display.Equals("0") && digitValue == 0)
                return;
            if (waitingForOperand)
            {
                display = "";
                waitingForOperand = false;
            }
            display = display + digitValue.ToString();
        }

        public void changeSignClicked(ref string display)
        {
            string text = display;
            double value = Convert.ToDouble(text);
            if (value > 0.0)
            {
                text = "-" + text;
            }
            else if (value < 0.0)
            {
                text = text.Substring(1);
            }
            display = text;
        }

        public void backspaceClicked(ref string display)
        {
            if (waitingForOperand)
                return;
            string text = display;
            text = text.Substring(0, text.Length - 1);
            if (text.Equals(""))
            {
                text = "0";
                waitingForOperand = true;
            }
            display = text;
        }

        public void clear(ref string display)
        {
            if (waitingForOperand)
                return;
            display = "0";
            waitingForOperand = true;
        }

        public void clearAll(ref string display)
        {
            sumSoFar = 0.0;
            factorSoFar = 0.0;
            pendingAdditiveOperator = "";
            pendingMultiplicativeOperator = "";
            display = "";
            waitingForOperand = true;
        }

        public void clearMemory()
        {
            sumInMemory = 0.0;
        }

        public void readMemory(ref string display)
        {
            display = sumInMemory.ToString();
            waitingForOperand = true;
        }

        public void setMemory(ref string display)
        {
            equalClicked(ref display);
            sumInMemory = Convert.ToDouble(display);
        }

        public void addToMemory(ref string display)
        {
            equalClicked(ref display);
            sumInMemory += Convert.ToDouble(display);
        }

        private double sumInMemory;
        private double sumSoFar;
        private double factorSoFar;
        private string pendingAdditiveOperator;
        private string pendingMultiplicativeOperator;
        private bool waitingForOperand;
    }
}
