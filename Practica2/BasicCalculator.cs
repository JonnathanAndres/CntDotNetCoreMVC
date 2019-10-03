using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2
{
    interface IAdder
    {
        string Add(int a, int b);
    }

    public class BasicCalculator : IAdder
    {
        public string Add(int a, int b) => $"{a}+{b}={a + b}";
    }
}
