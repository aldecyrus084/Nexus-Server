using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class Rates
    {
        public Guid RateId { get; private set; }
        public int Credit { get; private set; }
        public  int Time { get; private set; }
        public decimal Point { get; private set; }
        public bool IsVip { get; private set; } = false;

        protected Rates() { }

        public Rates(int credit, int time, decimal point, bool isVip)
        {
            RateId = Guid.NewGuid();
            Credit = credit;
            Time = time;
            Point = point;
            IsVip = isVip;
        }

    }
}
