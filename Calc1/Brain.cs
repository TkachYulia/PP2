using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc1
{
    enum CalcState
    {
        Zero, AccumulateDigits, Compute, Result
    }
    public delegate void ShowResultDelegate(string msg);
    class Brain
    {
        ShowResultDelegate resultDelegate;
        CalcState currentState = CalcState.Zero;
        string tempNumber = "";
        string resultNumber = "";
        string operation = "";
        public Brain(ShowResultDelegate resultDelegate)
        {
            this.resultDelegate = resultDelegate;
            tempNumber = "";
            operation = "";
        }
        public void Process(string msg)
        {
            string res = msg;

            switch (currentState)
            {
                case CalcState.Zero:
                    Zero(false, msg);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;
                case CalcState.Compute:
                    Compute(false, msg);
                    break;
                case CalcState.Result:
                    Result(false, msg);
                    break;
                default:
                    break;
            }
        }
        void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Zero;
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }
        void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.AccumulateDigits;
                tempNumber += msg;
                resultDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
            }
        }
        void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Compute;

                if (operation.Length > 0)
                {
                    Calculate();
                    resultDelegate(resultNumber);
                }
                else
                {
                    resultNumber = tempNumber;
                }

                tempNumber = "";
                operation = msg;
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }
        private int GCD(int x, int y)
        {
            List<int> xlist = new List<int>();
            for (int i = 1; i <= x / 2; i++)
            {
                if (x % i == 0)
                {
                    xlist.Add(i);
                }
            }
            List<int> ylist = new List<int>();
            for (int i = 1; i <= y / 2; i++)
            {
                if (y % i == 0)
                {
                    ylist.Add(i);
                }
            }
            var CommonList = xlist.Intersect(ylist);
            int gcd = CommonList.Max();
            return gcd;
        }
        private int IsCoprime(int x, int y)
        {
            List<int> xlist = new List<int>();
            for (int i = 2; i <= x / 2; i++)
            {
                if (x % i == 0)
                {
                    xlist.Add(x / i);
                }
            }
            List<int> ylist = new List<int>();
            for (int i = 1; i <= y / 2; i++)
            {
                if (y % i == 0)
                {
                    ylist.Add(y / i);
                }
            }
            var CommonList = xlist.Intersect(ylist);
            int v = CommonList.Count();
            if (v == 0) { return 1; }


            else
            {
                int val = CommonList.First();
                return val;
                // for(int i=0; i< xlist)

            }
            }
            void Result(bool isInput, string msg)
            {
                if (isInput)
                {
                    currentState = CalcState.Result;
                    Calculate();
                    resultDelegate(resultNumber);
                }
                else
                {
                    if (Rules.IsZero(msg))
                    {
                        Zero(true, msg);
                    }
                    else if (Rules.IsNonZeroDigit(msg))
                    {
                        AccumulateDigits(true, msg);
                    }
                    else if (Rules.IsOperator(msg))
                    {
                        operation = "";
                        tempNumber = resultNumber;
                        Compute(true, msg);
                    }
                }
            }
            void Calculate()
            {
                if (operation == "+")
                {
                    resultNumber = (double.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
                }
                else if (operation == "-")
                {
                    resultNumber = (double.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
                }
                else if (operation == "*")
                {
                    resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
                }
                else if (operation == "/")
                {
                    resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
                else if (operation == "^")
                {
                    resultNumber = (Math.Pow(int.Parse(resultNumber), int.Parse(tempNumber))).ToString();
               // resultNumber = (IsCoprime(int.Parse(resultNumber), int.Parse(tempNumber))).ToString();
            }
                else if (operation == "C")
                {
                resultNumber = (GCD(int.Parse(resultNumber), int.Parse(tempNumber))).ToString();
                // resultNumber = Convert.ToString(int.Parse(resultNumber), 2);
                //resultNumber = (Math.Cos(double.Parse(tempNumber))).ToString();
            }
            }
        }
    }

