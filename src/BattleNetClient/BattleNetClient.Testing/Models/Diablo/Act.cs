using System.Collections.Generic;

namespace BattleNetClient.Testing.Models.Diablo
{
    public class Act
    {
        public string Slug { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public List<Quest> Quests { get; set; } = new List<Quest>();
    }
}