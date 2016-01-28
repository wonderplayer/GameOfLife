using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Game_of_Life {
    [DataContract]
    public class GameWorld {
        [DataMember]
        public List<SavedGame> Game { get; set; }
    }
}