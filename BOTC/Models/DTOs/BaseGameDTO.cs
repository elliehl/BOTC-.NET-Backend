﻿using System;
namespace BOTC.Models
{
	public class BaseGameDTO
	{
        public DateTime Date { get; set; }
        public bool Game_Won { get; set; }
        public bool Is_Evil { get; set; }
        public string Comments { get; set; }
    }
}

