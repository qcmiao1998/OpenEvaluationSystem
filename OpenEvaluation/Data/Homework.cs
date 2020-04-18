using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEvaluation.Data
{
    public class Homework
    {
        public string HomeworkId { get; set; }
        public string HomeworkName { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public HomeworkType Type { get; set; }
        public DateTime Deadline { get; set; }
        public List<HomeworkScoreItem> ScoreItems { get; set; } = new List<HomeworkScoreItem>();
        public List<HomeworkSubmission> Submits { get; set; } = new List<HomeworkSubmission>();
    }

    public class HomeworkSubmission
    {
        public string HomeworkSubmissionId { get; set; }
        public User SubmitUser { get; set; }
        public Group SubmitGroup { get; set; }
        public HomeworkSubmissionType Type { get; set; }
        public string Content { get; set; }
        public DateTime SubmitTime { get; set; }
        public List<HomeworkScore> Scores { get; set; } = new List<HomeworkScore>();
        public Homework Homework { get; set; }
    }

    public enum HomeworkSubmissionType
    {
        Other,
        bilibili
    }

    public class HomeworkScore
    {
        public string HomeworkScoreId { get; set; }
        public User EvaluateUser { get; set; }
        public List<SubScore> Scores { get; set; } = new List<SubScore>();
        public Homework Homework { get; set; }
        public HomeworkSubmission HomeworkSubmission { get; set; }

        public class SubScore
        {
            public string SubScoreId { get; set; }
            public HomeworkScoreItem ScoreItem { get; set; }
            public double Score { get; set; }
            public HomeworkScore HomeworkScore { get; set; }
        }
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
