namespace ChessLogic
{
    public class GameState
    {

        //this class interacte with UI Project

        public Board Board { get; }   //Board configuration

        public Player CurrenPlayer { get; private set; } // witch player is current player

        public GameState( Player player, Board board)
        {
            Board = board;
            CurrenPlayer = player;

        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrenPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            return piece.GetMoves(pos,Board);
        }


        public void MakeMove(Move move)
        {
            move.Execute(Board);
            CurrenPlayer = CurrenPlayer.Opponent();
        }
    }
}
