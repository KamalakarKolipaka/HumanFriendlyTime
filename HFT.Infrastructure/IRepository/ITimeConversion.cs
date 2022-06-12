using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT.Infrastructure.IRepository
{
    public interface ITimeConversion
    {
        string GetTimeInWords(int h, int m);
    }
}
