using System.Collections.Generic;

namespace BattleNetClient.Diablo.Models
{
    public class NullAct : Act
    {
        public override string Slug => "";
        public override int Number => -1;
        public override string Name => "";

        public override List<Quest> Quests => new List<Quest>();
    }
}