using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 3 : Conseil de classe");
            Console.WriteLine("------------------------");

            //PhoneBook pb = new PhoneBook();

            //try
            //{
            //    pb.AddPhoneNumber("0745851245", "jessica");
            //    pb.AddPhoneNumber("0644626215", "eric");
            //    pb.AddPhoneNumber("0757137494", "jessa");
            //    pb.AddPhoneNumber("0745891245", "pierre");
            //    pb.AddPhoneNumber("0775713093", "Romane");
            //    pb.AddPhoneNumber("0745854345", "Victor");

            //    pb.DisplayPhoneBook();
            //    pb.PhoneContact("0757137494");
            //    pb.PhoneContact("0757997494");
            //    pb.DeletePhoneNumber("0745854345");

            //    pb.DisplayPhoneBook();


            //}
            //catch (KeyNotFoundException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 4 : Emploi du temps professionnel");
            Console.WriteLine("------------------------");

            BusinessSchedule schedule = new BusinessSchedule();
            DateTime date = DateTime.Now;
            TimeSpan ts = new TimeSpan(1, 0, 0);
            for (int i = 0; i < 5; i++)
            {
                schedule.AddBusinessMeeting(date, ts);
                date += ts;
            }
            //schedule.AddBusinessMeeting(date, ts);
            //schedule.AddBusinessMeeting(date + ts, ts);
            //schedule.AddBusinessMeeting(date + ts + ts, ts);
            //schedule.AddBusinessMeeting(date, ts);
            //schedule.AddBusinessMeeting(date, ts);
            schedule.DisplayMeetings();
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
