using System.Collections.Generic;
using System;

namespace DriveRatingApp
{
    class Director : TeamMember
    {
        public Director(string FirstName, string LastName, string CommonId, DriveRating DriveRating) : base(FirstName, LastName, CommonId, DriveRating)
        {

        }

        public override double GetBonus()
        {
            //FIXME: need to connect this set director rating to bonus.
            //SetDirectorRating();
            //bonus amount is TRIPLED for directors, so just using base * 3. 
            return base.GetBonus() * 3;
        }

        //method to set the director's drive rating depending on TM's ratings.
        public void SetDirectorRating(List<TeamMember> teamList)
        {
            int numRockstar = 0;
            int numExceeds = 0;
            int numAchieving = 0;
            int numNeedsImprovement = 0;

            //iterate through TM list
            foreach (TeamMember tm in teamList)
            {
                if (!tm.CommonId.Contains("d"))
                {
                    Console.WriteLine(tm);
                    switch (tm.DriveRating)
                    {
                        case DriveRating.NeedsImprovement:
                            numNeedsImprovement++;
                            break;
                        case DriveRating.AchievingExpectations:
                            numAchieving++;
                            break;
                        case DriveRating.ExceedExpectations:
                            numExceeds++;
                            break;
                        case DriveRating.Rockstar:
                            numRockstar++;
                            break;
                    }
                }
            }

            //setting the Drive Rating
            if (numAchieving == 0 && numNeedsImprovement == 0)
            {
                DriveRating = DriveRating.Rockstar;
            }
            else if (numNeedsImprovement == 0 && (numRockstar + numExceeds) >= 3)
            {
                DriveRating = DriveRating.ExceedExpectations;
            }
            else if (numNeedsImprovement >= 2)
            {
                DriveRating = DriveRating.NeedsImprovement;
            }
            else
            {
                DriveRating = DriveRating.AchievingExpectations;
            }
        }
    }
}
