using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Game_of_Life {
    [DataContract]
    public class Game {
        [DataMember]
        public List<SavedBoard> Boards { get; set; }
    }
}