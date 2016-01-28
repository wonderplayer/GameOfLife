namespace Game_of_Life {
    public class GameCycle {
        public void ChangeBoardState(SavedGame game) {
            var ngen = new char[game.Board.Length][];
            CreateNextGeneration(game, ngen);
            game.Generation++;
            game.Board = ngen;
        }

        private void CreateNextGeneration(SavedGame game, char[][] ngen) {
            var aroundCell = new char[3][];
            for (var yAxis = 0; yAxis < game.Board.Length; yAxis++) {
                ngen[yAxis] = new char[game.Board[0].Length];
                for (var xAxis = 0; xAxis < game.Board[0].Length; xAxis++) {
                    CreateArrayAroundCell(game, aroundCell, yAxis, xAxis);
                    char prevState = game.Board[yAxis][xAxis];
                    ngen[yAxis][xAxis] = FindNextState(aroundCell);
                    if (prevState == ngen[yAxis][xAxis]) {
                        continue;
                    }
                    if (prevState == 'X') {
                        game.AliveCells--;
                    } else {
                        game.AliveCells++;
                    }
                }
            }
        }

        private void CreateArrayAroundCell(SavedGame game, char[][] aroundCell, int yAxis, int xAxis) {
            for (var acYAxis = 0; acYAxis <= 2; acYAxis++) {
                aroundCell[acYAxis] = new char[3];
                for (var acXAxis = 0; acXAxis <= 2; acXAxis++) {
                    bool isCrossingTopBorder = acYAxis + yAxis - 1 < 0;
                    bool isCorssingBottomBorder = acYAxis + yAxis > game.Board.Length;
                    bool isCrossingLeftBorder = acXAxis + xAxis - 1 < 0;
                    bool isCrossingRightBorder = acXAxis + xAxis > game.Board[0].Length;
                    bool isNotInBorders = isCrossingTopBorder || isCorssingBottomBorder || isCrossingLeftBorder ||
                                         isCrossingRightBorder;
                    if (isNotInBorders) {
                        aroundCell[acYAxis][acXAxis] = ' ';
                    } else {
                        aroundCell[acYAxis][acXAxis] = game.Board[acYAxis + yAxis - 1][acXAxis + xAxis - 1];
                    }
                }
            }
        }

        private char FindNextState(char[][] array) {
            int aliveCellsAround = FindCellState(array);
            aliveCellsAround = CountAliveNeighbors(array, aliveCellsAround);
            return DetermineNextState(array, aliveCellsAround);
        }

        private int FindCellState(char[][] array) {
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

        private char DetermineNextState(char[][] array, int aliveCellsAround) {
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