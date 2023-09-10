namespace BOTC.Models.DTOs
{
    public class AddGameDTO: BaseGameDTO
	{
        public int Id { get; set; }
        public string Starting_Role { get; set; }
        public string Final_Role { get; set; }
    }
}

