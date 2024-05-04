using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar5
{
    public interface ICalc
    {     
        public double result { get; set; }
        public void Sum(int x);
        public void Sub(int x);
        public void Multy(int x);
        public void Divide(int x);
        public void CancelLast();
        event EventHandler<EventArgs> MyEventHandler;
    }
    public class Calculate : ICalc
    {
        public double result { get; set; }
        private Stack<double> lastResult = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        public void Divide(int x)
        {
            result /= x;
            MakeOperation();
        }

        public void Multy(int x)
        {
            result *= x;
            MakeOperation();
        }

        public void Sub(int x)
        {
            result -= x;
            MakeOperation();
        }

        public void Sum(int x)
        {
            result += x;
            MakeOperation();
        }
        public void MakeOperation()
        {
            lastResult.Push(result);
            PrintResult();
        }
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
        public void CancelLast()
        {
            if (lastResult.TryPop(out double res)) {
                result = res;
                PrintResult();
            }
        }
    }
}
