using System.IO;
using System.Runtime.Serialization.Json;

namespace Game_of_Life {
    public class Files {
        public void SaveGame(Game game, string fileName) {
            var formatter = new DataContractJsonSerializer(typeof (Game));
            var stream = new FileStream(fileName + ".json", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.WriteObject(stream, game);
            stream.Close();
        }

        public Game LoadGame(string file) {
            var formatter = new DataContractJsonSerializer(typeof (Game));
            var stream = new FileStream(file + ".json", FileMode.Open);
            var savedGame = (Game) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }

        public SavedBoard LoadDefaultBoard() {
            var formatter = new DataContractJsonSerializer(typeof (SavedBoard));
            var stream = new FileStream("C:\\Users\\rolands.strakis\\Documents\\Visual Studio 2015\\Projects\\Game of Life\\GameOfLife\\Game of Life\\bin\\Debug\\GliderGun.json", FileMode.Open);
            var savedGame = (SavedBoard) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }
    }
}