using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//
//
namespace MORSE
{    
    // класс - МОРЗЕ
    class Morse
    {
        private char Symb;      // символ
        private string Sign;    // знаки
        public static int Length;
        //
        // конструктор
        public Morse (char Symb1, string Sign1)
        {
            Symb = Symb1;
            Sign = Sign1;            
        }
        //
        // деструктор
        ~Morse() {}
        //
        // звуковое представление
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);  
        //
        // функция воспроизведения
        public void Sound()
        {
            int k = Form1.Var;   
            for (int i = 0; i < Sign.Length; i++)
            {
                if (Sign[i] == '.') Beep(500, 150 * k);
                if (Sign[i] == '-') Beep(500, 450 * k);
                Beep(37, 450);
            }
            if (Sign == "") Beep(37, 1050 * k);
            if (Length > 1)
            {
                Beep(37, 1050 * k);
                Length--;
            }
        }
        //
        // функция печати
        public void Print(System.Windows.Forms.RichTextBox RTB)
        {           
            RTB.Text += Symb + " (" + Sign + ") ";      
        }
        //
        // функция возврата символа
        public char GetChar ()
        {
            return Symb;
        }
    }
}
