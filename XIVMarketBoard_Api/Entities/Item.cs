﻿using System.ComponentModel.DataAnnotations;

namespace XIVMarketBoard_Api.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool? CanBeCrafted { get; set; }
        public bool? IsMarketable { get; set; }
    }
}
