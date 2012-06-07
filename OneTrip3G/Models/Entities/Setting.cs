using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.Models.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
