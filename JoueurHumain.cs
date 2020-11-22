using System;


namespace Puissance4
{
    public class JoueurHumain : Joueur
    {
        public JoueurHumain(string Order, char id, ConsoleColor color)
            : base(id, color)
        {
            bool notGood = true;

            Console.Clear();
            while (notGood)
            {
                
                Affichage.Text(String.Format("Joueur {0} Entrer votre prénom: ", Order), 0, 0, ConsoleColor.Blue);
                Nom = Console.ReadLine();
                if (Nom.Length < 1)
                {
                    Affichage.Text("Merci d'écrire un prénom valide", 0, 1, ConsoleColor.Red);
                }
                else
                {
                    notGood = false;
                }
            }
            
        }



    }
}
