using System;
namespace BOTC.Models.DTOs
{
	public class GameDTO: BaseGameDTO
	{
		public int Starting_Role_Id { get; set; }
        public int Final_Role_Id { get; set; }
    }
}

