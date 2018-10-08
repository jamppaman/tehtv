using System;
using System.Threading.Tasks;

namespace Assignment2
{
    public class PlayerProcessor
    {
        IRepository repository;

        public PlayerProcessor (IRepository rep){
            repository = rep;
        }

        public Task<Player> GetPlayer(Guid id){
            return repository.GetPlayer(id);
        }
        public Task<Player[]> GetAllPlayers(){
            return repository.GetAllPlayers();
        }
        public Task<Player[]> GetPlayersMinScore(int score){
            return repository.GetPlayersMinScore(score);
        }
        public Task<Player[]> GetAllPlayersWithItem(itemTypes itemType){
            return repository.GetAllPlayersWithItem(itemType);
        }
        public Task<Player> CreatePlayer(NewPlayer player){
            Player forward = new Player();
            forward.Name = player.Name;
            forward.CreationTime = DateTime.Now;
            forward.IsBanned = false;
            forward.Score = 0;
            forward.Level = 1;
            forward.Id = Guid.NewGuid();
            return repository.CreatePlayer(forward);
        }
        public Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player){
            Player replacePlayer = GetPlayer(id).Result;
            replacePlayer.Score = player.Score;
            return repository.ModifyPlayer(id, replacePlayer);
        }
        public Task<Player> DeletePlayer(Guid id){
            return repository.DeletePlayer(id);
        }

        public Task<int> GetMostCommonLevel()
        {
           return repository.GetMostCommonLevel();
        }
        public Task<Player> IncrementPlayerScore(Guid playerId, int added)
        {
            return repository.IncrementPlayerScore(playerId, added);
        }
    }
}