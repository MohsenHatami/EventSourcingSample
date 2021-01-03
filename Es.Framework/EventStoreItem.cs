using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Es.Framework
{
   public class EventStoreItem
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        [Description("ignore")]
        public int Sequence { get; set; }
        public string Name { get; set; }
        public string Aggergate { get; set; }
        public string AggregateId { get; set; }
    }
}
