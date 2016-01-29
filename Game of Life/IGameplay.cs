namespace Game_of_Life {
    public interface IGameplay {
        void Play(Game game, bool isNeededToShowBoard);

        void SaveGame(Game game);

        Game LoadGame();

        Game NewGame();
    }
}