using System;
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

        public static string RepeatString(string s, int x)
        {
            string Phrase = new System.Text.StringBuilder().Insert(0, s, x).ToString();
            return Phrase;
        }
        public static void Text(string phrase, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(phrase);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Presentation()
        {
            Console.Clear();
            string titre = "Puissance 4";
            Affichage.Text("Puissance 4 par Leny Anthunes et Damien Le Borgne", 1, 0, ConsoleColor.Red);
            Affichage.Text(titre, placerMot(titre, 2) + (titre.Length / 2), 5, ConsoleColor.Red);
        }

        public static void noResize()
        {
            /*
            string text = "Vous pouvez adapter la taille, une fois fait elle restera fixe, Appuiez sur une touche pour valider";
            Affichage.Text(text, 0, 10, ConsoleColor.Blue);

            Console.Read();
            */
            IntPtr handle = GetConsoleWindow();
            IntPtr Menu = GetSystemMenu(handle, false);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(Menu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(Menu, SC_SIZE, MF_BYCOMMAND);
            }
        }

        public static void HelpCommand(Joueur[] j )
        {
            string phrase = "Utiliser les fléches pour diriger le jeton";
            for (int i=0; i < Console.WindowWidth; i++)
            {
                Affichage.Text("-", i, Console.WindowHeight - 3, ConsoleColor.Blue);
            }
            Affichage.Text(phrase, Console.WindowWidth - phrase.Length, Console.WindowHeight - 2, ConsoleColor.Red);
            Affichage.Text(j[0].Nom, 5, Console.WindowHeight - 2, j[0].Color); 
            Affichage.Text(j[1].Nom, j[0].Nom.Length+6, Console.WindowHeight - 2, j[1].Color); 


        }

        public static void AfficheGrille(int Ligne, int Colonne)
        {
            string BarSup = Affichage.RepeatString("+---", Colonne);
            BarSup = BarSup + "+";
            string BarSep = "|";
            string Piont = Char.ToString((char)9632);
            int cursor = 0;
            for (int l = 0; l < Ligne; l++)
            {
                Affichage.Text(BarSup, placerMot(BarSup, 2) + (BarSup.Length / 2), l * 2 + 5, ConsoleColor.White);
                for (int c = 0; c < Colonne; c++)
                {

                    Affichage.Text(BarSep, placerMot(BarSep, 2) + (BarSep.Length / 2) + (cursor - 14), l * 2 + 6, ConsoleColor.White);

                    if (Grille.grille[l, c] != Puissance4.Jeton1 && Grille.grille[l, c] != Puissance4.Jeton2)
                    {
                        Affichage.Text(Piont, placerMot(Piont, 2) + (Piont.Length / 2) + (cursor - 12), l * 2 + 6, ConsoleColor.Black);
                    }
                    else if (Grille.grille[l, c] == Puissance4.Jeton2)
                    {
                        Affichage.Text(Piont, placerMot(Piont, 2) + (Piont.Length / 2) + (cursor - 12), l * 2 + 6, ConsoleColor.Yellow);
                    }
                    else if (Grille.grille[l, c] == Puissance4.Jeton1)
                    {
                        Affichage.Text(Piont, placerMot(Piont, 2) + (Piont.Length / 2) + (cursor - 12), l * 2 + 6, ConsoleColor.Red);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    cursor += 4;
                    Affichage.Text(BarSep, placerMot(BarSep, 2) + (BarSep.Length / 2) + (cursor - 14), l * 2 + 6, ConsoleColor.White);
                }
                cursor = 0;
                Affichage.Text(BarSup, placerMot(BarSup, 2) + (BarSup.Length / 2), Ligne * 2 + 5, ConsoleColor.White);
            }
        }
    }
}
