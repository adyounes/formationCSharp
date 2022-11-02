using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            int result = 0;
            bool operation_valide = false;

            switch (operation)
            {
                case '+':
                    operation_valide = true;
                    result = a + b;
                    break;
                case '-':
                    operation_valide = true;
                    result = a - b;
                    break;
                case '*':
                    operation_valide = true;
                    result = a * b;
                    break;
                case '/':
                    if (b != 0)
                    {
                        operation_valide = true;
                        result = a / b;
                    }
                    break;
                default:
                    break;
            }

            if (operation_valide)
            {
                Console.WriteLine($"{a} {operation} {b} = {result}");
            }
            else
            {
                Console.WriteLine(a + " " + operation + " " + b + " = Opération invalide.");
            }
        }





        public static void IntegerDivision(int a, int b)
        {
            int q, r;

            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide.");
            }
            else
            {
                q = a / b;
                r = a % b;
                if (r == 0)
                {
                    Console.WriteLine($"{a} = {q} * {b}");
                }
                else
                {
                    Console.WriteLine($"{a} = {q} * {b} + {r}");
                }
            }
        }

        public static void Pow(int a, int b)
        {
            int result = 1;

            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = Opération invalide");
            }
            else
            {
                for (int i = 1; i <= b; i++)
                {
                    result *= a;
                }
                Console.WriteLine($"{a} ^ {b} = {result}");
            }
        }
    }
}
