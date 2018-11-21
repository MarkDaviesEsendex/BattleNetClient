using System.Collections.Generic;

namespace BattleNetClient.Diablo.Models
{
    public class NullActCollection : ActCollection
    {
        public override List<Act> Acts => new List<Act>();
    }
}