using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    //This is the DriveRating Enum
    public enum DriveRating
    {
        NeedsImprovement,
        AchievingExpectations,
        ExceedExpectations,
        Rockstar
    }
    //Team Member class
    public class TeamMember
    {
        //This is an auto-implemented property for the DriveRating Enum
        public DriveRating DriveRating { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonId { get; set; }

        //constructor
        public TeamMember(string FirstName, string LastName, string CommonId, DriveRating DriveRating)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CommonId = CommonId;
            this.DriveRating = DriveRating;
        }

        //virtual TM method to return bonus amount based on DriveRating
        public virtual double GetBonus()
        {
            switch(DriveRating)
            {
                case (DriveRating.NeedsImprovement):
                    return 0.00;
                case (DriveRating.AchievingExpectations):
                    return 1000.00;
                case (DriveRating.ExceedExpectations):
                    return 5000.00;
                case (DriveRating.Rockstar):
                    return 10000.00;
                default:
                    return -1.00;

            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}. Drive rating is {DriveRating} and bonus is ${GetBonus()} ";
        }


    }

}
