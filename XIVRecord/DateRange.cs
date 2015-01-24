using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord
{
    public class DateRange : IRange<DateTime>
    {
        public DateRange(DateTime start, DateTime end)
        {
            if (end < start)
                throw new Exception("Inconsistent Argument! 'end' is earlier than 'start'.");
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool Includes(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }

        public bool Includes(IRange<DateTime> range)
        {
            return (Start <= range.Start) && (range.End <= End);
        }

        public bool Intersects(IRange<DateTime> range)
        {
            return this.Includes(range) ||
                (this.Start <= range.Start && range.Start <= this.End) || // start is in range
                (this.Start <= range.End && range.End <= this.End); // end is in range
        }

        public static DateRange Create(DateTime start, TimeSpan span)
        {
            if (span.Ticks < 0) // negative span
                return new DateRange(start + span, start);
            else
                return new DateRange(start, start + span);
        }
    }
}
