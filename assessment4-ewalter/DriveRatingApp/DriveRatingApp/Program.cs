using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamManager myTeam = new TeamManager();
            bool goOn = true;

            Console.WriteLine("Welcome to the Drive Review App!");
            while (goOn)
            {
                string userID = GetInput("Enter Your Common ID: ");
                int tmIndex = myTeam.GetTMIndex(userID);
                if (tmIndex < 0)
                {
                    Console.WriteLine("TM not found in list, invalid ID. Try again.");
                    continue;
                }
                else if (userID.StartsWith("l") || userID.StartsWith("d"))
                {
                    //leader case and director case
                    myTeam.ManagementMenu(TeamMemberRepo.teamList[tmIndex]);
                }
                else
                {
                    //tm case will also be default case. 
                    Console.WriteLine(TeamMemberRepo.teamList[tmIndex]);
                }
                goOn = Continue("Return to Title Screen to enter another common ID? (y/n): ");
            }

            Console.WriteLine("Program Exited. Goodbye!");
        }

        //returns string of user input
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim().ToLower();
        }


        public static bool Continue(string prompt)
        {

            string answer = GetInput(prompt);
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid response, type y or n. Try again. ");
                return Continue(prompt);
            }
        }


    }

}