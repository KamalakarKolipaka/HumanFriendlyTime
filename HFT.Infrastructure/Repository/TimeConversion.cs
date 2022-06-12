using HFT.Infrastructure.IRepository;
using HFT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT.Infrastructure.Repository
{
    public class TimeConversion : ITimeConversion
    {
        /// <summary>
        /// This method returns friendly time in words based on hours and minutes parameters.
        /// </summary>
        /// <param name="h">hours</param>
        /// <param name="m">minutes</param>
        /// <returns></returns>
        public string GetTimeInWords(int h, int m)
        {

            string humanFriendtlyTime = string.Empty;
            

            if (h > 12)
                h = h - 12;

            if (m == 0)
                humanFriendtlyTime = Helper.FriendlyTimeWordsPascal[h] + " o' clock ";

            else if (m == 1)
                humanFriendtlyTime = "One past " + Helper.FriendlyTimeWordsCamel[h];

            else if (m == 59)
                humanFriendtlyTime = "One to " + Helper.FriendlyTimeWordsCamel[(h % 12) + 1];

            else if (m == 15)
                humanFriendtlyTime = "Quarter past " + Helper.FriendlyTimeWordsCamel[h];

            else if (m == 30)
                humanFriendtlyTime = "Half past " + Helper.FriendlyTimeWordsCamel[h];

            else if (m == 45)
                humanFriendtlyTime = "Quarter to " + Helper.FriendlyTimeWordsCamel[(h % 12) + 1];

            else if (m <= 30)
                humanFriendtlyTime = Helper.FriendlyTimeWordsPascal[m] + " past " + Helper.FriendlyTimeWordsCamel[h];

            else if (m > 30)
                humanFriendtlyTime = Helper.FriendlyTimeWordsPascal[60 - m] + " to " + Helper.FriendlyTimeWordsCamel[(h % 12) + 1];

            return humanFriendtlyTime;
        }
    }
}
