namespace Puissance4
{
    public class JoueurIA : Joueur
    {
        public JoueurIA(string Order, char id, System.ConsoleColor color)
            : base(id, color)
        {
            Nom = "Mr Robot";
            AlphaBeta Alphabeta = new AlphaBeta();
        }

        public override int ChoixPosition()
        {
            return 5;
        }
    }
}
