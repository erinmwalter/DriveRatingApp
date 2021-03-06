using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    //Repository of Team Members
    public static class TeamMemberRepo
    {
        public static List<TeamMember> teamList = GetTeamMembers();

        public static List<TeamMember> GetTeamMembers()
        {
            List<TeamMember> teamMembers = new List<TeamMember>
            {
                new TeamMember("Joe", "Spacito", "t1234", DriveRating.Rockstar),
                new TeamMember("Jane", "Carrie", "t1235", DriveRating.ExceedExpectations),
                new TeamMember("Praj", "Nahim", "t1236", DriveRating.Rockstar),
                new Leader("Fitz", "Caldwell", "l2239", DriveRating.Rockstar),
                new Leader("Leslie", "Wrightfield", "l3239", DriveRating.ExceedExpectations),
                new Director("Charlie", "Georgina", "d5538", DriveRating.AchievingExpectations),
            };

            return teamMembers;
        }
    }
}
