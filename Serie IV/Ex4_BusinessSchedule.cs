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
        private Dictionary<DateTime, TimeSpan> _schedule;

        public BusinessSchedule()
        {
            _begin = new DateTime(2020, 1, 1);
            _end = new DateTime(2030, 12, 31);
            _schedule = new Dictionary<DateTime, TimeSpan>();
        }

        public bool IsEmpty()
        {
            if (_schedule.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            if (IsEmpty() && begin < end)
            {
                _begin = begin;
                _end = end;
            }
            else
            {
                throw new Exception();
            }
        }

        private KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            DateTime debut = new DateTime();
            DateTime fin = new DateTime();

            foreach (KeyValuePair<DateTime, TimeSpan> date in _schedule)
            {
                if (date.Key <= beginMeeting)
                {
                    debut = date.Key;
                }
                else if (date.Key > beginMeeting)
                {
                    fin = date.Key;
                    break;
                }

            }
            KeyValuePair<DateTime, DateTime> keyValuePair = new KeyValuePair<DateTime, DateTime>(debut, fin);
            return keyValuePair;
        }

        public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
        {
            if (date >= _begin && date+duration <= _end)
            {
                KeyValuePair<DateTime, DateTime> closestsElements = ClosestElements(date);
                DateTime lowerDt = closestsElements.Key;
                DateTime upperDt = closestsElements.Value;

                if ((lowerDt == DateTime.MinValue || date >= lowerDt + _schedule[lowerDt])
                    &&
                  (upperDt == DateTime.MaxValue || date + duration <= upperDt))
                  {
                    _schedule.Add(date, duration);
                    return true;
                  }
            }
            return false;
           
        }

        public bool DeleteBusinessMeeting(DateTime date, TimeSpan duration)
        {
            if (!IsEmpty() && _schedule.ContainsKey(date) &&_schedule[date] ==duration)
            {
                return _schedule.Remove(date);
            }
            return false;
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            //TODO
            int meetingsDeleted = 0;
            if(begin < _begin || end > _end)
            {
                throw new ArgumentOutOfRangeException("");
            }

            foreach(var meeting in _schedule.Keys)
            {
                if(meeting > begin && meeting + _schedule[meeting] <end)
                {
                    _schedule.Remove(meeting);
                    meetingsDeleted++;
                }
            }
            return meetingsDeleted;
        }

        public void DisplayMeetings()
        {
            //TODO
            Console.WriteLine($"Emploi du temps :{_begin} - {_end}");
            if (_schedule.Count == 0)
            {
                Console.WriteLine("Pas de réunion programmées");
            }

            int i = 1;
            foreach (KeyValuePair<DateTime, TimeSpan> reunion in _schedule)
            {
                Console.WriteLine($"Reunion {i}           : {reunion.Key} - {reunion.Key + reunion.Value}");
                i++;
            }
        }
    }
}
