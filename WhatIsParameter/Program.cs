using System;

namespace WhatIsParameter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Description desc = new Description();

            //int number1 = 10;
            //int number2 = 20;
            //desc.ValueTypeParam(number1, number2);
            //Console.WriteLine("After ValueType --- first : {0}, second : {1}", number1, number2);
            //desc.RefTypeParam(ref number1, ref number2);
            //Console.WriteLine("After RefType --- first : {0}, second : {1}", number1, number2);

            //int number;
            //desc.OutTypeParam(out number);
            //Console.WriteLine(number);

            desc.FlexibleTypeParam(10, 20, 30, 40, 50, 60, 70);
        }
    }
}