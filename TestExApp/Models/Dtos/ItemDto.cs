using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExApp.Models.Dtos
{
    public class ItemDto
    {
        public List<Item> Items { get; set; }
        public int ItemsCount { get; set; }
    }
}
