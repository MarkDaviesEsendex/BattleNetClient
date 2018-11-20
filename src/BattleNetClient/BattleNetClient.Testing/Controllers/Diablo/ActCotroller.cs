using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BattleNetClient.Testing.Controllers.Diablo
{
    [Route("d3/data")]
    public class ActController : ControllerBase
    {
        private readonly Dictionary<int, string> _acts = 
            new Dictionary<int, string>
            {
                {1,"{\"slug\":\"act-i\",\"number\":1,\"name\":\"Act I\",\"quests\":[{\"id\":87700,\"name\":\"The Fallen Star\",\"slug\":\"the-fallen-star\"},{\"id\":72095,\"name\":\"The Legacy of Cain\",\"slug\":\"the-legacy-of-cain\"},{\"id\":72221,\"name\":\"A Shattered Crown\",\"slug\":\"a-shattered-crown\"},{\"id\":72061,\"name\":\"Reign of the Black King\",\"slug\":\"reign-of-the-black-king\"},{\"id\":117779,\"name\":\"Sword of the Stranger\",\"slug\":\"sword-of-the-stranger\"},{\"id\":72738,\"name\":\"The Broken Blade\",\"slug\":\"the-broken-blade\"},{\"id\":73236,\"name\":\"The Doom in Wortham\",\"slug\":\"the-doom-in-wortham\"},{\"id\":72546,\"name\":\"Trailing the Coven\",\"slug\":\"trailing-the-coven\"},{\"id\":72801,\"name\":\"The Imprisoned Angel\",\"slug\":\"the-imprisoned-angel\"},{\"id\":136656,\"name\":\"Return to New Tristram\",\"slug\":\"return-to-new-tristram\"}]}" },
                {2, "{\"slug\":\"act-ii\",\"number\":2,\"name\":\"Act II\",\"quests\":[{\"id\":80322,\"name\":\"Shadows in the Desert\",\"slug\":\"shadows-in-the-desert\"},{\"id\":93396,\"name\":\"The Road to Alcarnus\",\"slug\":\"the-road-to-alcarnus\"},{\"id\":74128,\"name\":\"City of Blood\",\"slug\":\"city-of-blood\"},{\"id\":57331,\"name\":\"A Royal Audience\",\"slug\":\"a-royal-audience\"},{\"id\":78264,\"name\":\"Unexpected Allies\",\"slug\":\"unexpected-allies\"},{\"id\":78266,\"name\":\"Betrayer of the Horadrim\",\"slug\":\"betrayer-of-the-horadrim\"},{\"id\":57335,\"name\":\"Blood and Sand\",\"slug\":\"blood-and-sand\"},{\"id\":57337,\"name\":\"The Black Soulstone\",\"slug\":\"the-black-soulstone\"},{\"id\":121792,\"name\":\"The Scouring of Caldeum\",\"slug\":\"the-scouring-of-caldeum\"},{\"id\":57339,\"name\":\"Lord of Lies\",\"slug\":\"lord-of-lies\"}]}"}
            };
        
        [HttpGet("act/{actId}")]
        public ActionResult<Act> GetActById(int actId)
        {
            if (!_acts.ContainsKey(actId))
                return NotFound();
            return Ok(JsonConvert.DeserializeObject<Act>(_acts[actId]));
        }
    }
    
    public class Act
    {
        public string Slug { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public List<Quest> Quests { get; set; } = new List<Quest>();
    }
    
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}