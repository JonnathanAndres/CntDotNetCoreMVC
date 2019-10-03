using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2
{
    public interface IAdder
    {
        string Add(int a, int b);
    }

    public class BasicCalculator : IAdder
    {
        private readonly IOperationFormatter _formatter;
        public BasicCalculator(IOperationFormatter operationFormatter)
        {
            this._formatter = operationFormatter;
        }

        public string Add(int a, int b) => _formatter.Format(a, "+", b, a + b);
    }

    public interface IOperationFormatter
    {
        string Format(int a, string operation, int b, int result);
    }

    public class OperationFormatter : IOperationFormatter
    {
        public string Format(int a, string operation, int b, int result)
        {
            return $"{a}{operation}{b}={result}";
        }
    }


}
