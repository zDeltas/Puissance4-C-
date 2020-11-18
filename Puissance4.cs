using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Puissance4
    {

        public Puissance4()
        {

        }

        public static int NbJoueur()
        {
            bool notGood = true;
            int choice = 2;
            string titre = "Entrer pour continuer";
            string hum = "Humain vs Humain";
            string comp = "Humain vs Computeur";
            
            Affichage.Text(hum, Affichage.placerMot(hum, 2)-10, 10, ConsoleColor.Green);
            Affichage.Text(comp, Console.WindowWidth/2+9, 10, ConsoleColor.Green);
            Affichage.Text(titre, Affichage.placerMot(titre, 2) + (titre.Length / 2), 15, ConsoleColor.Blue);

            Affichage.Text(">", Console.WindowWidth / 2 + 4, 10, ConsoleColor.Red);

            while (notGood)
            {
                switch (Joueur.Touch())
                {
                    case 4:
                        Affichage.Text(">", Console.WindowWidth / 2 + 4, 10, ConsoleColor.Black);
                        Affichage.Text("<", Console.WindowWidth / 2 - 6, 10, ConsoleColor.Red);
                        choice = 1;
                        break;
                    case 6:
                        Affichage.Text(">", Console.WindowWidth / 2 + 4, 10, ConsoleColor.Red);
                        Affichage.Text("<", Console.WindowWidth / 2 - 6, 10, ConsoleColor.Black);
                        choice = 2;
                        break;
                    case 5:
                        Affichage.Text(">", Console.WindowWidth / 2 + 4, 10, ConsoleColor.Red);
                        Affichage.Text("<", Console.WindowWidth / 2 - 6, 10, ConsoleColor.Black);
                        notGood = false;
                        return choice;
                }
            }
            return 0;
        }

        public static void launchGame(int player)
        {

            Grille g = new Grille();
            if(player == 2)
            {
                Joueur j1 = new JoueurHumain("salut", 'X');
                Joueur j2 = new JoueurIA("MrRobot", 'O');
            }
            else
            {
                Joueur j1 = new JoueurHumain("salut", 'X');
                Joueur j2 = new JoueurHumain("salut", 'O');
            }


            Grille.DisplayBoard();

        }
    }
}
