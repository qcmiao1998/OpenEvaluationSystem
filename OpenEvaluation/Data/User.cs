using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEvaluation.Data
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public Group Group { get; set; }
    }

    public enum Role
    {
        Admin,
        Teacher,
        Student
    }
}
