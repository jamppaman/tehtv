using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2
{
    [Route("api/players")]
    [ApiController]
    [Authorize(Policy = "BaseClient")]
    public class PlayerController : Controller
    {
        PlayerProcessor processor;
        public PlayerController(PlayerProcessor proc){
            processor = proc;
        }
        [HttpGet("{id}")]

            public Task<Player> GetPlayer(Guid id){
            return processor.GetPlayer(id);
        }
        [HttpGet]
        public Task<Player[]> GetAllPlayers(int? minScore){

            if (minScore.HasValue){
                return processor.GetPlayersMinScore((int)minScore);
            }
            return processor.GetAllPlayers();
        }
        [HttpGet("{type}")]
        public Task<Player[]> GetAllPlayersWithItem([FromQuery] itemTypes itemType){

            return processor.GetAllPlayersWithItem(itemType);
        }
        [HttpPost]
        public Task<Player> CreatePlayer([FromBody]NewPlayer player){
            return processor.CreatePlayer(player);
        }
        [HttpPut("{id}")]
        public Task<Player> ModifyPlayer(Guid id, [FromBody]ModifiedPlayer player){
            return processor.ModifyPlayer(id,player);
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public Task<Player> DeletePlayer(Guid id){
            return processor.DeletePlayer(id);
        }
        [Route("alamitta")]
         [HttpGet]
        public Task<int> GetMostCommonLevel(){

            return processor.GetMostCommonLevel();
        }
        [HttpGet]
        public Task<int> IncrementPlayerScore([FromBody] Guid playerId,[FromBody] int added){
            return processor.IncrementPlayerScore(playerId, added);
        }
    }
}