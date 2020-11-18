using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    public class Joueur
    {
        public string Nom { get; set; }
        public char Id { get; set; }

        public Joueur(string nom, char id)
        {
            Nom = nom;
            Id = id;
        }

        public static int Touch()
        {
            ConsoleKeyInfo t = Console.ReadKey();
            if(t.Key == ConsoleKey.LeftArrow)
            {
                return 4;
            }else if(t.Key == ConsoleKey.RightArrow)
            {
                return 6;
            }else if(t.Key == ConsoleKey.Enter)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }

    }
}
