using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedLemon_ITI.Models
{
    public class ExtraInformation
    {
        public int Id { get; set; }
        public int ExtraTypeInformationId { get; set; }
        public ExtraTypeInformation ExtraTypeInformation { get; set; }
        public int ActivityId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool HasChildren { get; set; }
        public ICollection<ExtraInformation> Children { get; set; }
    }
}