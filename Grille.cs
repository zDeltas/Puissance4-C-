using System;

namespace Puissance4
{
    public class Grille
    {
        public const int Ligne = 6;
        public const int Colonne = 7;
        public static char[,] grille = new char[Ligne, Colonne];

        public Grille()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Affichage.AfficheGrille(Ligne, Colonne);
        }

        public bool PlacerPiont(int Pos, Joueur j)
        {
            if(Pos == -1)
            {
                return true;
            }
            for (int i = 0; i <= Ligne; i++)
            {
                if (i == 6)
                {
                    grille[Ligne - 1, Pos] = j.Id;
                }
                else if (grille[i, Pos] == Puissance4.Jeton1 || grille[i, Pos] == Puissance4.Jeton2)
                {
                    if (i == 0)
                    {
                        return true;
                    }else{
                        grille[i - 1, Pos] = j.Id;
                        break;
                    }
                }
            }
            /*if (j.Id == Puissance4.Jeton1)
            {
                Console.Beep(20000, 150);
            }
            else
            {
                Console.Beep(25000,150);
            }*/
            
            return false;
        }

        public bool TestWin(Joueur j)
        {
            //Line test
            for (int l = 0; l < Ligne; l++)
            {
                for(int c = 0; c < Colonne-3; c++)
                {
                    if (grille[l, c] == j.Id && grille[l, c + 1] == j.Id && grille[l, c + 2] == j.Id && grille[l, c + 3] == j.Id) return true;
                }
            }
            //Test column
            for (int l = 0; l < Ligne-3; l++)
            {
                for (int c = 0; c < Colonne; c++)
                {
                    if (grille[l, c] == j.Id && grille[l + 1, c] == j.Id && grille[l + 2, c] == j.Id && grille[l + 3, c] == j.Id) return true;

                }
            }
            //Tester les diagonales positive
            for (int l = 0; l < Ligne-3; l++)
            {
                for (int c = 3; c < Colonne; c++)
                {
                    if (grille[l, c] == j.Id && grille[l+1, c - 1] == j.Id && grille[l+2, c - 2] == j.Id && grille[l+3, c - 3] == j.Id) return true;
                }
            }
            //Tester les diagonales negative
            for (int l = 0; l < Ligne - 3; l++)
            {
                for (int c = 0; c < Colonne-3; c++)
                {
                    if (grille[l, c] == j.Id && grille[l + 1, c + 1] == j.Id && grille[l + 2, c + 2] == j.Id && grille[l + 3, c + 3] == j.Id) return true;
                }
            }

            return false;
        }
    }
}
