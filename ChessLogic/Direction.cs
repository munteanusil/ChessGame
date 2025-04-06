namespace ChessLogic
{
    public class Direction
    {
        public readonly static Direction North = new Direction(-1, 0);

        public readonly static Direction South = new Direction(1, 0);

        public readonly static Direction Est = new Direction(0,1);

        public readonly static Direction West = new Direction(0, -1);

        public readonly static Direction NorthEst = North + Est;

        public readonly static Direction NorthWest = North + West;

        public readonly static Direction SouthEst = South + Est;

        public readonly static Direction SouthWest  = South + West;
        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public static Direction operator +(Direction dir1, Direction dir2) 
        {
            return new Direction(dir1.RowDelta + dir1.ColumnDelta, dir2.RowDelta + dir2.ColumnDelta);
        }

        public static Direction operator *(int scalar, Direction dir) 
        { 
             return new Direction(scalar*dir.RowDelta, scalar*dir.ColumnDelta);
        }

    }
}
