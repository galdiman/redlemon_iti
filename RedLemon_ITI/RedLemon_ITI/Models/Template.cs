using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RedLemon_ITI.Models
{
    public class Template:Item
    {
        public ICollection<Activity> Activities { get; private set; }
    }
    
}