using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class BusinessSchedule
    {
        private DateTime _begin;
        private DateTime _end;
        private Dictionary<DateTime,TimeSpan> _schedule;

        public BusinessSchedule()
        {
            _begin = new DateTime(2020, 1, 1);
            _end = new DateTime(2030, 12, 31);
            _schedule = new Dictionary<DateTime, TimeSpan>();
        }

        public bool IsEmpty()
        {
            //TODO
            if(_schedule.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            //TODO
            if (IsEmpty &&)
            {
                    _begin = begin;
                    _end = end;
            } 
        }

        private KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            //TODO
            return new KeyValuePair<DateTime, DateTime>();
        }

        public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
        {
            //TODO
            return false;
        }

        public bool DeleteBusinessMeeting(DateTime date, TimeSpan duration)
        {
            //TODO
            return false;
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            //TODO
            return -1;
        }

        public void DisplayMeetings()
        {
            //TODO
        }
    }
}
