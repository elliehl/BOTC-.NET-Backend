using System;
namespace BOTC.Models
{
	public class AddGameEntity
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public bool Game_Won { get; set; }
		public bool Is_Evil { get; set; }
        public string Comments { get; set; }
        public int Starting_Role_Id { get; set; }
        public int Final_Role_Id { get; set; }
    }
}

