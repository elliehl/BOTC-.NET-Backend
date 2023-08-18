using System;
namespace BOTC.Models
{
	public class GameDto
	{
        public DateTime Date { get; set; }
        public bool Result { get; set; }
        public bool Alignment { get; set; }
        public string Comments { get; set; }
        public string StartingRole { get; set; }
        public string FinalRole { get; set; }
    }
}

