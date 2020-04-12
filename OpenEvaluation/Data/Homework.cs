using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEvaluation.Data
{
    public class Homework
    {
        public string HomeworkId { get; set; }
        public User Owner { get; set; }
        public HomeworkType Type { get; set; }
        public List<HomeworkScoreItem> ScoreItems { get; set; }
        public List<HomeworkSubmit> Submits { get; set; }
    }

    public class HomeworkSubmit
    {
        public string HomeworkSubmitId { get; set; }
        public HomeworkType SubmitType { get; set; }
        public HomeworkType ScoreType { get; set; }
        public User SubmitterUser { get; set; }
        public Group SubmitterGroup { get; set; }
        public HomeworkContent Content { get; set; }
        public List<HomeworkScore> Scores { get; set; }
        public Homework Homework { get; set; }
    }

    public class HomeworkContent
    {
        public string HomeworkContentId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }

    public class HomeworkScore
    {
        public string HomeworkScoreId { get; set; }
        public HomeworkType Type { get; set; }
        public User SubmitterUser { get; set; }
        public Group SubmitterGroup { get; set; }
        public HomeworkScoreItem ScoreItem { get; set; }
        public double Score { get; set; }
        public HomeworkSubmit HomeworkSubmit { get; set; }
    }

    public class HomeworkScoreItem
    {
        public string HomeworkScoreItemId { get; set; }
        public double MinScore { get; set; }
        public double MaxScore { get; set; }
        public string Description { get; set; }
        public Homework Homework { get; set; }
    }

    public enum HomeworkType
    {
        Single,
        Group
    }
}
