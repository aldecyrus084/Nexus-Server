using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Interface.Helper
{
    public interface IPointCalculator
    {
        int TotalPoint(decimal point, bool isVip);
    }
}
