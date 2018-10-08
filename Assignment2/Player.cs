using System;
using System.Collections.Generic;

namespace Assignment2
{
    public class Player
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level {get; set;}
    public int Score { get; set; }
    public bool IsBanned { get; set; }
    public DateTime CreationTime { get; set; }
    public List<Item> itemList = new List<Item>();
    }
}