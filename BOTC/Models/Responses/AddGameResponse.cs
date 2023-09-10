using System;
namespace BOTC.Models
{
	public class AddGameResponse: BaseGameDTO
	{
        public int Id { get; set; }
        public string Starting_Role { get; set; }
        public string Final_Role { get; set; }
    }
}

