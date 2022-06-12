using HFT.Infrastructure.IRepository;
using HFT.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT.BLL
{
    public class TimeConversionBL
    {
        ITimeConversion _timeConversion = null;  
      
        public string GetTimeInWords(int h, int m)
        {
            _timeConversion = new TimeConversion();
            return  _timeConversion.GetTimeInWords(h, m);
        }

    }
}
