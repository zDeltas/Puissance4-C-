using System;


namespace Puissance4
{

    class Jeu
    {


        static void Main(string[] args)
        {

            Affichage.noResize();
            Affichage.Presentation();

            Puissance4.LaunchGame(Puissance4.NbJoueur());


            Console.Read();
        }
    }
}
