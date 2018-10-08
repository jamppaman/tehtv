using System;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IRepository
    {
    Task<Player> GetPlayer(Guid id);
    Task<Player[]> GetAllPlayers();

    Task<Player[]> GetPlayersMinScore(int score);
    Task<Player[]> GetAllPlayersWithItem(itemTypes itemType);
    Task<Player> CreatePlayer(Player player);
    Task<Player> ModifyPlayer(Guid id, Player player);
    Task<Player> DeletePlayer(Guid id);
    
    Task<Item> GetItem(Guid playerId, Guid itemId);
    Task<Item[]> GetAllItems(Guid playerId);
    Task<Item> CreateItem(Guid playerId, Item item);
    Task<Item> ModifyItem(Guid playerId, Item item);
    Task<Item> DeleteItem(Guid playerId, Guid itemId);
    Task<int> GetMostCommonLevel();
    Task<Player> IncrementPlayerScore(Guid playerId, int Added);
    }
}