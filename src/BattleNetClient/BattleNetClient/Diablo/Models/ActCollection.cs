using System.Collections.Generic;

namespace BattleNetClient.Diablo.Models
{
    public class ActCollection
    {
        public static ActCollection Empty => new NullActCollection();
        public virtual List<Act> Acts { get; } = new List<Act>();
    }
}