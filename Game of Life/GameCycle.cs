namespace Game_of_Life {
    public class GameCycle {
        public void ChangeBoardState(SavedBoard board) {
            board.Generation++;
            board.Layout = CreateNextGeneration(board);
        }

        private char[][] CreateNextGeneration(SavedBoard board) {
            var newGen = new char[board.Layout.Length][];
            for (var yAxis = 0; yAxis < board.Layout.Length; yAxis++) {
                newGen[yAxis] = new char[board.Layout[0].Length];
                AddCellToNewGen(board, yAxis, newGen);
            }
            return newGen;
        }

        private void AddCellToNewGen(SavedBoard board, int yAxis, char[][] newGen) {
            var neighbors = new char[3][];
            for (var xAxis = 0; xAxis < board.Layout[0].Length; xAxis++) {
                CreateArrayAroundCell(board, neighbors, yAxis, xAxis);
                newGen[yAxis][xAxis] = FindNextCellsNextState(neighbors);
                board.AliveCells += CheckIfStateChanged(board, yAxis, xAxis, newGen);
            }
        }

        private void CreateArrayAroundCell(SavedBoard board, char[][] neighbors, int yAxis, int xAxis) {
            for (var neighborY = 0; neighborY <= 2; neighborY++) {
                neighbors[neighborY] = new char[3];
                for (var neighborX = 0; neighborX <= 2; neighborX++) {
                    bool isNotInBorders = CheckForBorders(board, yAxis, xAxis, neighborY, neighborX);
                    if (isNotInBorders) {
                        neighbors[neighborY][neighborX] = ' ';
                    } else {
                        neighbors[neighborY][neighborX] = board.Layout[neighborY + yAxis - 1][neighborX + xAxis - 1];
                    }
                }
            }
        }

        private bool CheckForBorders(SavedBoard board, int yAxis, int xAxis, int neighborY, int neighborX) {
            bool isCrossingTopBorder = neighborY + yAxis - 1 < 0;
            bool isCorssingBottomBorder = neighborY + yAxis > board.Layout.Length;
            bool isCrossingLeftBorder = neighborX + xAxis - 1 < 0;
            bool isCrossingRightBorder = neighborX + xAxis > board.Layout[0].Length;
            bool isNotInBorders = isCrossingTopBorder || isCorssingBottomBorder || isCrossingLeftBorder ||
                                  isCrossingRightBorder;
            return isNotInBorders;
        }

        private char FindNextCellsNextState(char[][] array) {
            int currentCell = FindCurrentCellState(array);
            int aliveCellsAround = CountAliveNeighbors(array, currentCell);
            return DetermineNextCellState(array, aliveCellsAround);
        }

        private int CheckIfStateChanged(SavedBoard board, int yAxis, int xAxis, char[][] newGen) {
            char prevState = board.Layout[yAxis][xAxis];
            if (prevState == newGen[yAxis][xAxis]) {
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