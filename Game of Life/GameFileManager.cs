using System.IO;
using System.Runtime.Serialization.Json;

namespace Game_of_Life {
    public class GameFileManager {
        public void SaveGame(GameWorld savedGame, string fileName) {
            var formatter = new DataContractJsonSerializer(typeof (GameWorld));
            var stream = new FileStream(fileName + ".json", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.WriteObject(stream, savedGame);
            stream.Close();
        }

        public GameWorld LoadGame(string file) {
            var formatter = new DataContractJsonSerializer(typeof (GameWorld));
            var stream = new FileStream(file + ".json", FileMode.Open);
            var savedGame = (GameWorld) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }

        public SavedGame LoadNewGame(string file) {
            var formatter = new DataContractJsonSerializer(typeof (SavedGame));
            var stream = new FileStream(file + ".json", FileMode.Open);
            var savedGame = (SavedGame) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }

        //public MenuText SaveText() {
        //    var formatter = new DataContractJsonSerializer(typeof(MenuText));
        
        //}
    }
}