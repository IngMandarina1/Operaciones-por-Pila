using System.Linq.Expressions;
using System.Text;

namespace Operaciones_por_Pila.Services
{
    public static class Conversion
    {

        private static int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;
            if (operador == '*' || operador == '/')
                return 2;
            if (operador == '^')
                return 3;
            return 0;
        }

        public static string ConversionOP(string expresion)
        {
            Pila pila = new Pila(expresion.Length);
            StringBuilder postfija = new StringBuilder();

            foreach (char c in expresion)
            {
                if (char.IsLetterOrDigit(c))
                {
                    postfija.Append(c);
                }
                else if (c == '(')
                {
                    pila.Push(c);
                }
                else if (c == ')')
                {
                    while (!pila.IsEmpty && pila.Peek() != '(')
                    {
                        postfija.Append(pila.Pop());
                    }
                    if (!pila.IsEmpty) pila.Pop();
                }
                else
                {
                    while (!pila.IsEmpty && Prioridad(pila.Peek()) >= Prioridad(c))
                    {
                        postfija.Append(pila.Pop());
                    }
                    pila.Push(c);
                }
            }

            while (!pila.IsEmpty)
            {
                postfija.Append(pila.Pop());
            }

            return postfija.ToString();
        }

        public static double Evaluar(string expresionPostfija)
        {
            Pila pila = new Pila(expresionPostfija.Length);

            foreach (char c in expresionPostfija)
            {
                if (char.IsDigit(c)) 
                {
                    pila.Push(c);
                }
                else 
                {
                    double op2 = pila.Pop() - '0';
                    double op1 = pila.Pop() - '0';
                    double resultado = 0;

                    switch (c)
                    {
                        case '+': resultado = op1 + op2; break;
                        case '-': resultado = op1 - op2; break;
                        case '*': resultado = op1 * op2; break;
                        case '/': resultado = op1 / op2; break;
                        case '^': resultado = Math.Pow(op1, op2); break;
                    }

                    pila.Push((char)(resultado + '0')); 
                }
            }

            return pila.Pop() - '0'; 
        }


    }



}
