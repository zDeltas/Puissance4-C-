using System;

namespace Puissance4
{
    class Puissance4
    {

        protected internal static char Jeton1 = 'X';
        protected internal static char Jeton2 = 'O';


        public static int NbJoueur()
        {
            bool notGood = true;
            int choice = 2;
            string titre = "Entrer pour continuer";
            string hum = "Humain vs Humain";
            string comp = "Humain vs Computeur";

            Affichage.Text(hum, Affichage.placerMot(hum, 2) - 10, 10, ConsoleColor.Green);
            Affichage.Text(comp, Console.WindowWidth / 2 + 9, 10, ConsoleColor.Green);
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

        public static void LaunchGame(int player)
        {
            int returnPos = 0;
            int tours = 0;
            bool Win = false;

            Joueur j1 = new JoueurHumain("1", Puissance4.Jeton1, ConsoleColor.Red);
            Joueur j2 = new JoueurIA("2", Puissance4.Jeton2, ConsoleColor.Yellow);
            Joueur[] tableauJoueur = { j1, j2 };

            Grille g = new Grille();

            Affichage.HelpCommand(tableauJoueur);

            while (tours < 41 && Win == false)
            {
                for(int i=0; i < tableauJoueur.Length; i++)
                {  
                    while (g.PlacerPiont(returnPos - 1, tableauJoueur[i])) { returnPos = tableauJoueur[i].ChoixPosition(); }
                    returnPos = 0;
                    Affichage.AfficheGrille(Grille.Ligne, Grille.Colonne);
                    Win = g.TestWin(tableauJoueur[i]);
                    if (Win) break;
                }
            }
            Console.Clear();
            Console.WriteLine(Win);
        }
    }
}
