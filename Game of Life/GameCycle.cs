namespace Game_of_Life {
    public class GameCycle {
        public void ChangeBoardState(SavedBoard board) {
            var newGeneration = new char[board.Layout.Length][];
            CreateNextGeneration(board, newGeneration);
            board.Generation++;
            board.Layout = newGeneration;
        }

        private void CreateNextGeneration(SavedBoard board, char[][] newGeneration) {
            var neighbors = new char[3][];
            for (var yAxis = 0; yAxis < board.Layout.Length; yAxis++) {
                newGeneration[yAxis] = new char[board.Layout[0].Length];
                for (var xAxis = 0; xAxis < board.Layout[0].Length; xAxis++) {
                    CreateArrayAroundCell(board, neighbors, yAxis, xAxis);
                    newGeneration[yAxis][xAxis] = FindCurrentCellsNextState(neighbors);
                    board.AliveCells += CheckIfStateChanged(board, yAxis, xAxis, newGeneration);
                }
            }
        }

        private void CreateArrayAroundCell(SavedBoard board, char[][] neighbors, int yAxis, int xAxis)
        {
            for (var aliveCellY = 0; aliveCellY <= 2; aliveCellY++)
            {
                neighbors[aliveCellY] = new char[3];
                for (var aliveCellX = 0; aliveCellX <= 2; aliveCellX++)
                {
                    bool isCrossingTopBorder = aliveCellY + yAxis - 1 < 0;
                    bool isCorssingBottomBorder = aliveCellY + yAxis > board.Layout.Length;
                    bool isCrossingLeftBorder = aliveCellX + xAxis - 1 < 0;
                    bool isCrossingRightBorder = aliveCellX + xAxis > board.Layout[0].Length;
                    bool isNotInBorders = isCrossingTopBorder || isCorssingBottomBorder || isCrossingLeftBorder ||
                                         isCrossingRightBorder;
                    if (isNotInBorders)
                    {
                        neighbors[aliveCellY][aliveCellX] = ' ';
                    }
                    else {
                        neighbors[aliveCellY][aliveCellX] = board.Layout[aliveCellY + yAxis - 1][aliveCellX + xAxis - 1];
                    }
                }
            }
        }

        private char FindCurrentCellsNextState(char[][] array)
        {
            int aliveCellsAround = FindCurrentCellState(array);
            aliveCellsAround = CountAliveNeighbors(array, aliveCellsAround);
            return DetermineNextCellState(array, aliveCellsAround);
        }

        private int CheckIfStateChanged(SavedBoard board, int yAxis, int xAxis, char[][] newGeneration) {
            char prevState = board.Layout[yAxis][xAxis];
            if (prevState == newGeneration[yAxis][xAxis])
            {
                return 0;
            }
            if (prevState == 'X') {
                return -1;
            }
            return 1;    
        }

        private int FindCurrentCellState(char[][] array) {
            var aliveCellsAround = 0;
            bool isAlive = array[1][1] == 'X';
            if (isAlive) {
                aliveCellsAround--;
            }
            return aliveCellsAround;
        }

        private int CountAliveNeighbors(char[][] array, int aliveCellsAround) {
            for (var yAxis = 0; yAxis <= 2; yAxis++)
                for (var xAxis = 0; xAxis <= 2; xAxis++)
                    if (array[yAxis][xAxis] == 'X') {
                        aliveCellsAround++;
                    }
            return aliveCellsAround;
        }

        private char DetermineNextCellState(char[][] array, int aliveCellsAround) {
            switch (aliveCellsAround) {
                case 0:
                case 1:
                    return ' ';
                case 2:
                    return array[1][1];
                case 3:
                    return 'X';
                default:
                    return ' ';
            }
        }
    }
}