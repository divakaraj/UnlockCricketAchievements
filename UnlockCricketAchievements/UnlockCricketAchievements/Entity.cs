using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlockCricketAchievements
{
    class Entity
    {
        public int target { get; set; }
        public int currentScore { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int remainingScore { get; set; }
        public bool aFirstPreference { get; set; }
        public bool aOperation { get; set; }
        public int remainingRunsSecondary { get; set; }
        public int NextAvailableMilestoneSecondary { get; set; }
        public int aRunsToGet { get; set; }
        public int bRunsToGet { get; set; }
        public int aNextMilestone { get; set; }
        public int bNextMilestone { get; set; }
        public int aShare { get; set; }
        public int bShare { get; set; }
    }
}
