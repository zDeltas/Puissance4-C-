using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Puissance4
{
    
    class Jeu
    {
        

        static void Main(string[] args)
        {

            Affichage.noResize();
            Affichage.Presentation();

            Puissance4.launchGame(Puissance4.NbJoueur());
            

            Console.Read();
        }
    }
}
