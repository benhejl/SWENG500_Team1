using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class DateRange
    {
        public DateTime StartTime { get; private set; }
        public DateTime FinishTime { get; private set; }

        public DateRange(DateTime start, DateTime finish)
        {
        }
    }
}
