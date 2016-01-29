using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Game_of_Life {
    public class Files {
        public void SaveToFile(Game game, string fileName) {
            string json = JsonConvert.SerializeObject(game);
            using (FileStream fs = File.Create(fileName + ".json")) {
                byte[] info = new UTF8Encoding(true).GetBytes(json);
                fs.Write(info, 0, info.Length);
            }
        }

        public string LoadGameFromFile(string fileName) {
            string jsonString;
            var stream = new FileStream(fileName, FileMode.Open);

            using (var fileStreamReader = new StreamReader(stream)) {
                jsonString = fileStreamReader.ReadToEnd();
            }
            return jsonString;
        }
    }
}