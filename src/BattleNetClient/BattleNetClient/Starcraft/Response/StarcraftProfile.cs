namespace BattleNetClient.Starcraft.Response
{
    public interface IStarcraftProfile
    {
        int Id { get; }
        int Realm { get; }
        string DisplayName { get; }
        string ClanName { get; }
        string ClanTag { get; }
        string ProfilePath { get; }
    }

    public class StarcraftProfile : IStarcraftProfile
    {
        public int Id { get; set; }
        public int Realm { get; set; }
        public string DisplayName { get; set; }
        public string ClanName { get; set; }
        public string ClanTag { get; set; }
        public string ProfilePath { get; set; }
    }
}