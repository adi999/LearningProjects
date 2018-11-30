using System;

namespace ChessValidator
{
    class Program
    {
        public class ChessPiece
        {
            public char color;
            public char piece;

            public ChessPiece()
            {
                color = '-';
                piece = '-';
            }

            public ChessPiece(char color, char piece)
            {
                this.color = color;
                this.piece = piece;
            }

        }

        public class ChessBoard
        {
            private ChessPiece[,] chessBoard;

            public ChessBoard()
            {
                chessBoard = new ChessPiece[8, 8];
            }

            public void InitializeChessBoard()
            {
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        char color = '-', piece = '-';

                        if(i == 0 || i == 1)
                        {
                            color = 'W';
                        }

                        if(i == 6 || i == 7)
                        {
                            color = 'B';
                        }

                        if(j == 0 || j == 7)
                        {
                            piece = 'R';
                        }

                        if(j == 1 || j == 6)
                        {
                            piece = 'H';
                        }

                        if(j == 2 || j == 5)
                        {
                            piece = 'B';
                        }

                        if(j == 3)
                        {
                            piece = 'Q';
                        }

                        if(j == 4)
                        {
                            piece = 'K';
                        }

                        if(i == 1 || i == 6)
                        {
                            piece = 'P';
                        }

                        if(i != 0 && i != 1 && i != 6 && i != 7)
                        {
                            piece = '-';
                        }
                        chessBoard[i, j] = new ChessPiece(color, piece);
                    }
                }
            }

            public void DisplayChessBoard()
            {
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        Console.Write(chessBoard[i, j].color.ToString() + chessBoard[i, j].piece.ToString() + "  ");
                    }
                    Console.WriteLine();
                }
            }

            public bool IsChessPieceAtPos(char color, char piece, int posRow, int posCol)
            {
                return (chessBoard[posRow, posCol].color == color && chessBoard[posRow, posCol].piece == piece);
            }

            public bool IsPositionValid(int rowPos, int colPos)
            {
                if(rowPos < 0 || rowPos > 7)
                {
                    return false;
                }

                if(colPos < 0 || colPos > 7)
                {
                    return false;
                }

                return true;
            }

            public bool IsChessPieceOfSameColorAtPos(char color, int rowPos, int colPos)
            {
                var chessPiece = chessBoard[rowPos, colPos];
                if(chessPiece.color == color)
                {
                    return true;
                }

                return false;
            }

            public bool AreGeneralMoveRulesValid(char color, char piece, int startRow, int startCol, int endRow, int endCol)
            {
                if (!IsPositionValid(startRow, startCol) || !IsPositionValid(endRow, endCol))
                {
                    return false;
                }

                if (!IsChessPieceAtPos(color, piece, startRow, startCol))
                {
                    return false;
                }

                if (IsChessPieceOfSameColorAtPos(color, endRow, endCol))
                {
                    return false;
                }

                return true;
            }


            public bool IsValidHorseMove(int startRow, int startCol, int endRow, int endCol)
            {
                if(Math.Abs(startRow - endRow) == 2 && Math.Abs(startCol - endCol) == 1)
                {
                    return true;
                }

                if (Math.Abs(startRow - endRow) == 1 && Math.Abs(startCol - endCol) == 2)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            public bool IsValidPawnMove(char color, int startRow, int startCol, int endRow, int endCol)
            {
                if(!IsChessPieceOfSameColorAtPos(color, endRow, endCol))
                {
                    //capture move
                    if(color == 'W' && endRow == startRow + 1 && Math.Abs(startCol - endCol) == 1)
                    {
                        return true;
                    }

                    if (color == 'B' && endRow == startRow - 1 && Math.Abs(startCol - endCol) == 1)
                    {
                        return true;
                    }
                }

                if(color == 'W' && endRow == startRow + 1 && startCol == endCol)
                {
                    return true;
                }

                if(color == 'B' && endRow == startRow - 1 && startCol == endCol)
                {
                    return true;
                }

                return false;
            }

            public bool IsValidDiagonalMove(int startRow, int startCol, int endRow, int endCol)
            {
                if(Math.Abs(startRow - endRow) != Math.Abs(startCol - endCol))
                {
                    return false;
                }

                if (startRow < endRow && startCol < endCol)
                {
                    int i = startRow + 1; int j = startCol + 1;
                   while(i < endRow && j < endCol)
                    {
                        var chessPiece = chessBoard[i, j];
                        if (chessPiece.color != '-')
                        {
                            return false;
                        }
                        i = i + 1; j = j + 1;
                    }
                }

                if (startRow > endRow && startCol < endCol)
                {
                    int i = startRow - 1; int j = startCol + 1;
                    while (i > endRow && j < endCol)
                    {
                        var chessPiece = chessBoard[i, j];
                        if (chessPiece.color != '-')
                        {
                            return false;
                        }
                        i = i - 1; j = j + 1;
                    }
                }

                if (startRow > endRow && startCol > endCol)
                {
                    int i = startRow - 1; int j = startCol - 1;
                    while (i > endRow && j > endCol)
                    {
                        var chessPiece = chessBoard[i, j];
                        if (chessPiece.color != '-')
                        {
                            return false;
                        }
                        i = i - 1; j = j - 1;
                    }
                }

                if (startRow < endRow && startCol > endCol)
                {
                    int i = startRow + 1; int j = startCol - 1;
                    while (i < endRow && j > endCol)
                    {
                        var chessPiece = chessBoard[i, j];
                        if (chessPiece.color != '-')
                        {
                            return false;
                        }
                        i = i + 1; j = j - 1;
                    }
                }

                return true;
            }

            public bool IsValidHorizontalMove(int startRow, int startCol, int endRow, int endCol)
            {

                if(startRow != endRow && startCol != endCol)
                {
                    return false;
                }

                for (int i = startRow + 1; i < endRow; i++)
                {
                    for (int j = startCol + 1; j < endCol; j++)
                    {
                        var chessPiece = chessBoard[i, j];
                        if (chessPiece.color != '-')
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public bool IsValidMove(char color, char piece, int startRow, int startCol, int endRow, int endCol)
            {
                if(!AreGeneralMoveRulesValid(color, piece, startRow, startCol, endRow, endCol))
                {
                    return false;
                }

                if(piece == 'H' && !IsValidHorseMove(startRow, startCol, endRow, endCol))
                {
                    return false;
                }

                if(piece == 'Q' && !IsValidDiagonalMove(startRow, startCol, endRow, endCol) && !IsValidHorizontalMove(startRow, startCol, endRow, endCol))
                {
                    return false;
                }

                if(piece == 'P' && !IsValidPawnMove(color, startRow, startCol, endRow, endCol))
                {
                    return false;
                }

                return true;
            }

            public void ExecuteMove(char color, char piece, int startRow, int startCol, int endRow, int endCol)
            {
                chessBoard[endRow, endCol] = new ChessPiece(color, piece);
                chessBoard[startRow, startCol] = new ChessPiece();
            }
        }
        
        static void Main(string[] args)
        {
            ChessBoard chessBoard = new ChessBoard();
            chessBoard.InitializeChessBoard();
            chessBoard.DisplayChessBoard();
            bool run = true;
            while(run)
            {
                var input = Console.ReadLine();
                var moveInput = input.Split(" ");
                var chessPiece = moveInput[0];
                var startPoint = Int32.Parse(moveInput[1]);
                var endPoint = Int32.Parse(moveInput[2]);
                int startRow = startPoint / 10;
                int startCol = startPoint % 10;
                int endRow = endPoint / 10;
                int endCol = endPoint % 10;
                if(chessBoard.IsValidMove(chessPiece[0], chessPiece[1], startRow, startCol, endRow, endCol))
                {
                    chessBoard.ExecuteMove(chessPiece[0], chessPiece[1], startRow, startCol, endRow, endCol);
                    Console.WriteLine(input + "  " + "Valid");

                }

                else
                {
                    Console.WriteLine(input + "  " + "InValid");
                }
                chessBoard.DisplayChessBoard();
            }
            Console.Read();
        }
    }
}
