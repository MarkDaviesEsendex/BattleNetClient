using System.Collections.Generic;

namespace BattleNetClient.Diablo.Models
{
    public class Act
    {
        public static Act Empty => new NullAct();
        
        public virtual string Slug { get; }
        public virtual int Number { get; }
        public virtual string Name { get; }

        public virtual List<Quest> Quests { get; } = new List<Quest>();
    }
}