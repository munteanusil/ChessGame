namespace ChessLogic
{
    public class GameState
    {

        //this class interacte with UI Project

        public Board Board { get; }   //Board configuration

        public Player CurrenPlayer { get; private set; } // witch player is current player

        public Result Result { get; private set; } = null;
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
            IEnumerable<Move> MoveCandidates = piece.GetMoves(pos,Board);
            return MoveCandidates.Where(move => move.IsLegal(Board));
        }


        public void MakeMove(Move move)
        {
            move.Execute(Board);
            CurrenPlayer = CurrenPlayer.Opponent();
            CheckForGameOver();
        }

        public IEnumerable<Move> AllLegalMoveFor(Player player)
        {
            IEnumerable<Move> moveCandiates = Board.PiecePositionFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos,Board);
            });
            return moveCandiates.Where(move => move.IsLegal(Board));
        }

        private void CheckForGameOver()
        {
            if (!AllLegalMoveFor(CurrenPlayer).Any())
            {
                if (Board.IsInCheck(CurrenPlayer))
                {
                    Result.Win(CurrenPlayer.Opponent());
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }

        public bool IsGameOver()
        {
            return Result != null;
        }

    }
}
