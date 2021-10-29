using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    class TeamManager
    {
        public List<TeamMember> teamList = TeamMemberRepo.GetTeamMembers();

        //gets index of TM if found.
        public int GetTMIndex(string userID)
        {
            foreach (TeamMember tm in teamList)
            {
                if (tm.CommonId.Contains(userID))
                {
                    return teamList.IndexOf(tm);
                }
            }
            return -1;
        }

        public void DisplayTM(int index)
        {
            Console.WriteLine(teamList[index]);
        }

        //displays menu for management
        public void ManagementMenu(TeamMember manager)
        {
            bool goOn = true;
            Console.WriteLine($"Hello, {manager.FirstName}");
            while (goOn)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Update Team Member's Drive Rating");
                Console.WriteLine("2. View Bonus Report.");
                Console.WriteLine("3. Return to Main Menu.");
                string choice = Program.GetInput("Enter your Selection: ");
                switch (choice)
                {
                    case "1":
                        UpdateDrive(manager);
                        break;
                    case "2":
                        DisplayTeam(manager);
                        break;
                    case "3":
                        //exit to main menu
                        goOn = false;
                        break;
                    default:
                        Console.WriteLine("I'm sorry, invalid selection, try again.");
                        break;
                }
            }
        }

        //allows leader/director to update TM drive rating
        //FIXME IF TIME: There has to be a simpler logic to make this distinction bet director and leader happen...
        private void UpdateDrive(TeamMember manager)
        {
            string accessLevel = manager.CommonId.Substring(0, 1);

            Console.WriteLine("Drive Rating Update selected.");
            string userId = Program.GetInput("Enter Common ID for Drive Rating Update: ");
            switch (accessLevel)
            {
                case "l":
                    if (userId.StartsWith("t"))
                    {
                        foreach (TeamMember tm in teamList)
                        {
                            if (tm.CommonId == userId)
                            {
                                Console.WriteLine($"{tm.FirstName} {tm.LastName} selected.");
                                tm.DriveRating = GetValidDriveRating();
                                Console.WriteLine($"Successfully updated to {tm.DriveRating}");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not authorized to update this TM's drive rating.");
                    }
                    break;
                case "d":
                    foreach (TeamMember tm in teamList)
                    {
                        if (tm.CommonId == userId)
                        {
                            Console.WriteLine($"{tm.FirstName} {tm.LastName} selected.");
                            tm.DriveRating = GetValidDriveRating();
                            Console.WriteLine($"Successfully updated to {tm.DriveRating}");
                            break;
                        }
                    }
                    break;
            }
        }

        //displays teams, only displays  based on "access level" of the manager
        //FIXME IF TIME: figure out other logic to do this if possible? seems like the code is redundant
        private void DisplayTeam(TeamMember manager)
        {
            string accessLevel = manager.CommonId.Substring(0, 1);
            Console.WriteLine("\nBonus Report:");
            switch (accessLevel)
            {
                case "l":
                    {
                        Console.WriteLine(manager);
                        foreach (TeamMember tm in teamList)
                        {
                            if (tm.CommonId.StartsWith("t"))
                            {
                                Console.WriteLine(tm);
                            }
                        }
                    }
                    break;
                case "d":
                    {
                        foreach (TeamMember tm in teamList)
                        {
                            Console.WriteLine(tm);
                        }
                    }
                    break;
            }

        }

        private DriveRating GetValidDriveRating()
        {
            string choice = Program.GetInput("Enter [0]Needs Improvement, [1]Achieving Expectations, [2]Exceed Expectations, [3]Rockstar:  ");
            switch(choice)
            {
                case "0":
                    return DriveRating.NeedsImprovement;
                case "1":
                    return DriveRating.AchievingExpectations;
                case "2":
                    return DriveRating.ExceedExpectations;
                case "3":
                    return DriveRating.Rockstar;
                default:
                    Console.WriteLine("Invalid Selection. Try again.");
                    return GetValidDriveRating();
            }
           
        }
    }
}

