﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;

        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[] 
        {
            Direction.North,
            Direction.South,
            Direction.West,
            Direction.Est,
            Direction.NorthWest,
            Direction.NorthEst,
            Direction.SouthWest,
            Direction.SouthEst,
        };

        public King(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
           King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;

                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to; 
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board) 
        {
            foreach(Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }

        public override bool CanCaptureOpponetKing(Position from, Board board)
        {
           return MovePositions(from,board).Any(to =>
           {
               Piece piece = board[to];
               return piece != null && piece.Type == PieceType.King;
           });
        }


    }
}
