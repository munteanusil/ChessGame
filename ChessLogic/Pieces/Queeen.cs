namespace ChessLogic
{
    public class Queeen : Piece
    {
        public override PieceType Type => PieceType.Queen;

        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.South,
            Direction.Est,
            Direction.West,
            Direction.NorthEst,
            Direction.NorthWest,
            Direction.SouthEst,
            Direction.SouthWest,
        };

        public Queeen(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
           Queeen copy = new Queeen(Color);
           copy.HasMoved = HasMoved;
           return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }

        public override bool CanCaptureOpponetKing(Position from, Board board)
        {
            return GetMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });

        }
    }
}
