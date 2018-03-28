using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedLemon_ITI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Item()
        {

        }

        public Item(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}