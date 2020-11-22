using System;

namespace Puissance4
{
    public class Joueur
    {
        public string Nom { get; set; }
        public char Id { get; set; }
        public ConsoleColor Color { get; set; }
        public Joueur(char id, ConsoleColor color)
        {
            Id = id;
            Color = color;
        }

        public static int Touch()
        {
            ConsoleKeyInfo t = Console.ReadKey();
            if (t.Key == ConsoleKey.LeftArrow)
            {
                return 4;
            }
            else if (t.Key == ConsoleKey.RightArrow)
            {
                return 6;
            }
            else if (t.Key == ConsoleKey.Enter)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }


        public virtual int ChoixPosition()
        {
            int StartPos = Console.WindowWidth / 2 - 1;
            int HeightPos = 18;
            int Space = 4;


            int minValue = (StartPos - 13);
            string Piont = Char.ToString((char)9632);
            int Width = StartPos;
            bool notGood = true;
            int touch = -1;
            while (notGood)
            {

                if (Id == 'O')
                {
                    Affichage.Text(Piont, StartPos + 0, HeightPos - 14, ConsoleColor.Yellow);
                    Affichage.Text("^", StartPos + 0, HeightPos, ConsoleColor.Red);
                }
                else
                {
                    Affichage.Text(Piont, StartPos + 0, HeightPos - 14, ConsoleColor.Red);
                    Affichage.Text("^", StartPos + 0, HeightPos, ConsoleColor.Yellow);
                }

                touch = Joueur.Touch();
                Affichage.Text(Piont, StartPos + 0, HeightPos - 14, ConsoleColor.Black);
                Affichage.Text("^", StartPos + 0, HeightPos, ConsoleColor.Black);
                switch (touch)
                {
                    case 4:

                        if (StartPos >= Width - 11)
                        {
                            StartPos -= Space;
                        }
                        break;
                    case 6:
                        if (StartPos <= Width + 11)
                        {
                            StartPos += Space;
                        }
                        break;
                    case 5:
                        return ((StartPos / 4 - Width / 4) + 4);
                }
            }
            return 0;
        }

    }
}
