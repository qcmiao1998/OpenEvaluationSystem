using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEvaluation.Data
{
    public class Group
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public List<User> Users { get; set; }
    }
}
