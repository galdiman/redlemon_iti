using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedLemon_ITI.Models
{
    public class AnswerType : Item
    {
        public AnswerType():base()
        {

        }

        public AnswerType(int id, string description):base(id, description)
        {
           
        }
    }
}