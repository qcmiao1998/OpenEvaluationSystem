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
        private EventsService EventsService { get; set; }

        public UserService(EvaluateContext context, EventsService eventsService)
        {
            Db = context;
            this.EventsService = eventsService;
        }
        public bool IsLogin { get; set; } = false;
        public User CurrentUser { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public void Login()
        {

            User[] lgu = Db.Users.Where(u => u.UserId == UserId && u.Password == Md5.GetMd5(UserId + Password)).ToArray();
            if (lgu.Length == 1)
            {
                CurrentUser = lgu.First();
                IsLogin = true;
                EventsService.TriggerRenderActions();
            }

        }
    }
}
