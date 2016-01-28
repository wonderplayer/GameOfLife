using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Game_of_Life {
    [DataContract]
    public class SavedGame {
        [DataMember]
        public List<SavedBoard> Boards { get; set; }
    }
}