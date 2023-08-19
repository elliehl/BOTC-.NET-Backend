using System;
namespace BOTC.Models.Entities
{
	public class GameEntity
	{
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Game_Won { get; set; }
        public bool Is_Evil { get; set; }
        public string Comments { get; set; }
        public string Starting_Role { get; set; }
        public string Final_Role { get; set; }
    }
}

