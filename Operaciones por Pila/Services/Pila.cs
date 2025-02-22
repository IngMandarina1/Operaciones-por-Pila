namespace Operaciones_por_Pila.Services
{
    public class Pila
    {
        public char[] Elementos { get; set; }
        public int TOPE { get; set; }

        public Pila(int tamaño)
        {
            Elementos = new char[tamaño];
            TOPE = 0;
        }

        public bool IsEmpty => TOPE == 0;
        public bool IsFull => TOPE == Elementos.Length;

        public void Push(char elemento)
        {
            if (IsFull) return;
            Elementos[TOPE] = elemento;
            TOPE++;
        }

        public char Pop()
        {
            if (IsEmpty)
                return '\0';

            TOPE--;
            return Elementos[TOPE];
        }

        public char Peek()
        {
            if (IsEmpty)
                return '\0';

            return Elementos[TOPE - 1];
        }

    }
}
