using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Puissance4
{
    class Affichage
    {
        #region win32
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        #endregion

        public static int placerMot(string phrase, int x)
        {

            return Console.WindowWidth / x - phrase.Length;
        }

        public static void Text(string phrase, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(phrase);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Presentation()
        {
            Console.Clear();
            string titre = "Puissance 4";
            Affichage.Text("Puissance 4 par Leny Anthunes et Damien Le Borgne", 1, 0, ConsoleColor.Red);
            Affichage.Text(titre, placerMot(titre, 2)+(titre.Length/2), 5, ConsoleColor.Red);
        }

        public static void noResize()
        {
            string text = "Vous pouvez adapter la taille, une fois fait elle restera fixe, Appuiez sur une touche pour valider";
            Affichage.Text(text, 0, 10, ConsoleColor.Blue);

            Console.Read();

            IntPtr handle = GetConsoleWindow();
            IntPtr Menu = GetSystemMenu(handle, false);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(Menu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(Menu, SC_SIZE, MF_BYCOMMAND);
            }
            Console.Read();

        }
    }
}
