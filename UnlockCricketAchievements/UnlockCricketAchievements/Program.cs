using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlockCricketAchievements
{
    class Program
    {
        static void Main(string[] args)
        {
            Entity instance = new Entity();
            instance.target = Convert.ToInt32(Console.ReadLine());
            instance.currentScore = Convert.ToInt32(Console.ReadLine());
            instance.a = Convert.ToInt32(Console.ReadLine());
            instance.b = Convert.ToInt32(Console.ReadLine());
            instance.remainingScore = instance.target - instance.currentScore;

            List<int> landmarks = new List<int>();
            for (int i = 50; i < 500; i += 50)
            {
                landmarks.Add(i);
            }
            MainLogic(instance, landmarks);
            Console.WriteLine(instance.a);
            Console.WriteLine(instance.b);
            Console.ReadLine();
        }
        public static void NextMileStoneData(Entity instance, int scorer, List<int> landmarks)
        {
            instance.NextAvailableMilestoneSecondary = landmarks.FirstOrDefault(x => x > scorer);
            instance.remainingRunsSecondary = instance.NextAvailableMilestoneSecondary - scorer;
        }
        private static void Tally(Entity instance)
        {
            if (instance.aOperation)
            {
                instance.a += instance.aRunsToGet;
                instance.remainingScore -= instance.aRunsToGet;
            }
            else
            {
                instance.b += instance.bRunsToGet;
                instance.remainingScore -= instance.bRunsToGet;
            }
        }
        private static void CalculateShares(Entity instance)
        {
            if (instance.remainingScore % 2 == 0)
            {
                instance.aOperation = true;
                ShareSeparation(instance);
            }
            else
            {
                if (instance.a >= instance.b)
                {
                    instance.aOperation = true;
                    ShareSeparation(instance);
                }
                else
                {
                    instance.aOperation = false;
                    ShareSeparation(instance);
                }
            }
        }
        private static void ShareSeparation(Entity instance)
        {
            if (instance.aOperation)
            {
                instance.aShare = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(instance.remainingScore / 2.0)));
                instance.bShare = Convert.ToInt32(Math.Floor(Convert.ToDecimal(instance.remainingScore / 2.0)));
            }
            else
            {
                instance.bShare = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(instance.remainingScore / 2.0)));
                instance.aShare = Convert.ToInt32(Math.Floor(Convert.ToDecimal(instance.remainingScore / 2.0)));
            }
            instance.a += instance.aShare;
            instance.b += instance.bShare;
            instance.remainingScore = 0;
        }
        private static void MainLogic(Entity instance, List<int> landmarks)
        {
            instance.aNextMilestone = landmarks.FirstOrDefault(x => x > instance.a);
            instance.bNextMilestone = landmarks.FirstOrDefault(x => x > instance.b);
            instance.aRunsToGet = instance.aNextMilestone - instance.a;
            instance.bRunsToGet = instance.bNextMilestone - instance.b;

            if (instance.remainingScore < instance.aRunsToGet && instance.remainingScore < instance.bRunsToGet)
            {
                CalculateShares(instance);
            }
            if (instance.remainingScore > 0)
            {
                if (instance.aRunsToGet < instance.bRunsToGet)
                {
                    instance.aOperation = true;
                    Tally(instance);
                    instance.aFirstPreference = true;
                }
                else if (instance.aRunsToGet > instance.bRunsToGet)
                {
                    instance.aOperation = false;
                    Tally(instance);
                }
                else
                {
                    if (instance.a >= instance.b)
                    {
                        instance.aOperation = true;
                        Tally(instance);
                        instance.aFirstPreference = true;
                    }
                    else
                    {
                        instance.aOperation = false;
                        Tally(instance);
                    }
                }
            }
            if (instance.remainingScore > 0)
            {
                if (instance.aFirstPreference)
                {
                    NextMileStoneData(instance, instance.b, landmarks);
                }
                else
                {
                    NextMileStoneData(instance, instance.a, landmarks);
                }

                if (instance.remainingRunsSecondary <= instance.remainingScore)
                {
                    if (!instance.aFirstPreference)
                    {
                        instance.aOperation = true;
                    }
                    else
                    {
                        instance.aOperation = false;
                    }
                    Tally(instance);
                }

                else
                {
                    CalculateShares(instance);
                }
            }
            if (instance.remainingScore > 0)
            {
                if (instance.remainingScore < 50)
                {
                    CalculateShares(instance);
                }
                else
                {
                    MainLogic(instance, landmarks);
                }
            }
        }
    }
}
