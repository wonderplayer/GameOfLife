namespace Game_of_Life {
    public class SavedGame {
        public int AliveCells { get; set; }

        public char[][] Board { get; set; }

        public int Generation { get; set; }
    }
}