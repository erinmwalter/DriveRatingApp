using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveRatingApp
{
    class Leader : TeamMember
    {
        public Leader(string FirstName, string LastName, string CommonId, DriveRating DriveRating) :base(FirstName, LastName, CommonId, DriveRating)
        {

        }

        public override double GetBonus()
        {
            //bonus amount is DOUBLED for leaders, so just using base * 2. 
            return base.GetBonus() * 2; 
        }
    }
}
