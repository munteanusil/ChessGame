﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessLogic;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] pieceImages = new Image[8,8];
        
        private GameState gameState;
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeBord();

            gameState = new GameState(Player.White,Board.Initial());
            DrawBord(gameState.Board);
        }

        private void InitializeBord()
        {
            for(int r = 0;r<8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Image image = new Image();
                    pieceImages[r, c] = image;
                    PieceGrid.Children.Add(image);
                }
            }
        }

        private void DrawBord(Board board)
        {
            for(int r = 0; r <8; r++)
            {
                for(int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c];
                    pieceImages[r, c].Source = Images.GetImage(piece);
                }
            }
        }
    }
}