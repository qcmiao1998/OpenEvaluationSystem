using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenEvaluation.Data;
using OpenEvaluation.Helpers;

namespace OpenEvaluation.Service
{
    public class UserService
    {
        private EvaluateContext Db { get; set; }

        public UserService(EvaluateContext context)
        {
            Db = context;
        }
        public bool IsLogin { get; set; } = false;
        public User CurrentUser { get; set; }

        string _userId;
        public string UserId
        {
            get => _userId;
            set
            {
                Regex regex = new Regex(@"^[A-Za-z0-9]+$");
                if (regex.IsMatch(value))
                {
                    _userId = value;
                }
            }
        }

        public string Password { get; set; }

        public void Login()
        {

            User[] lgu = Db.Users.Where(u => u.UserId == UserId && u.Password == Md5.GetMd5(_userId + Password)).ToArray();
            if (lgu.Length == 1)
            {
                CurrentUser = lgu.First();
                IsLogin = true;
            }

        }
    }
}
