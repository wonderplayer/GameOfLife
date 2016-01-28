using System.IO;
using System.Runtime.Serialization.Json;

namespace Game_of_Life {
    public class Files {
        public void SaveGame(SavedGame savedGame, string fileName) {
            var formatter = new DataContractJsonSerializer(typeof (SavedGame));
            var stream = new FileStream(fileName + ".json", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.WriteObject(stream, savedGame);
            stream.Close();
        }

        public SavedGame LoadGame(string file) {
            var formatter = new DataContractJsonSerializer(typeof (SavedGame));
            var stream = new FileStream(file + ".json", FileMode.Open);
            var savedGame = (SavedGame) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }

        public SavedBoard LoadDefaultBoard() {
            var formatter = new DataContractJsonSerializer(typeof (SavedBoard));
            var stream = new FileStream("GliderGun.json", FileMode.Open);
            var savedGame = (SavedBoard) formatter.ReadObject(stream);
            stream.Close();
            return savedGame;
        }
    }
}