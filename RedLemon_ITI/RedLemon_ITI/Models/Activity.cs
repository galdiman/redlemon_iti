using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedLemon_ITI.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal TimeToResolve { get; set; }
        public string Purpose { get; set; }
        public string Instructions { get; set; }
        public int AnswerTypeId { get; set; }
        public AnswerType AnswerType { get; set; }
        public bool HasPrompt { get { return ActivityExtras.Any(x => x.ExtraTypeInformationId == 4); } }
        public string Prompt { get { return HasPrompt ? ActivityExtras.FirstOrDefault(x => x.ExtraTypeInformationId == 4).Value : ""; } }
        public ICollection<ExtraInformation> ActivityExtras { get; set; }
    }
}