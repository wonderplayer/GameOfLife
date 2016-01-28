namespace Game_of_Life {
    public class SavedBoard {
        public int AliveCells { get; set; }

        public char[][] Layout { get; set; }

        public int Generation { get; set; }
    }
}