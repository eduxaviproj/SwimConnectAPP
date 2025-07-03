using SwimConnectApp.Enums;
using SwimConnectApp.Models;
using System.Collections.Generic;

namespace SwimConnectApp.Services
{
    public class EnrollManager
    {
        private List<Athlete> athletes = new List<Athlete>();
        private List<Race> races = new List<Race>();
        private List<Enrollment> enrollments = new List<Enrollment>();

        private int nextAthleteId = 1;
        private int nextRaceId = 1;
        private int nextEnrollmentId = 1;

        //Athlete
        public Athlete CreateAthlete(string name, int age, string club)
        {
            var athlete = new Athlete(nextAthleteId++, name, age, club);
            athletes.Add(athlete);
            return athlete;
        }

        public List<Athlete> ReadAthletes() { return athletes; }


        //Race
        public Race CreateRace(SwimStyle swimStyle, int distance)
        {
            var race = new Race(nextRaceId++, swimStyle, distance);
            races.Add(race);
            return race;
        }

        public List<Race> ReadRaces() { return races; }


        //Enroll
        public bool CreateEnroll(int athleteId, int raceId)
        {
            Athlete athlete = null; //search athlete and assign it
            foreach (var a in athletes)
            {
                if (a.Id == athleteId)
                {
                    athlete = a;
                    break;
                }
            }

            Race race = null; //search race an assign it
            foreach (var r in races)
            {
                if (r.Id == raceId)
                {
                    race = r;
                    break;
                }
            }

            if (athlete == null || race == null) //verify if either one of the objects is null
            {
                return false;
            }

            foreach (var e in enrollments) //verify if athlete is already enrolled on a specific race
            {
                if (e.Athlete.Id == athleteId && e.Race.Id == raceId)
                {
                    return false;
                }
            }

            enrollments.Add(new Enrollment(nextEnrollmentId++, athlete, race)); //if all the requirements above are validated, then create an Enroll
            return true;
        }

        public List<Enrollment> ReadEnrolls() { return enrollments; }

        public List<Enrollment> ReadEnrollsByRace(int raceId) //list enrolls by a race type
        {
            List<Enrollment> result = new List<Enrollment>();
            foreach (var e in enrollments)
            {
                if (e.Race.Id == raceId)
                {
                    result.Add(e);
                }
            }
            return result;
        }


        //DeleteEnroll
        public bool DeleteEnroll(int enrollmentId)
        {
            Enrollment enrollmentToRemove = null;
            foreach (var e in enrollments)
            {
                if (e.Id == enrollmentId)
                {
                    enrollmentToRemove = e;
                    break;
                }
            }
            if (enrollmentToRemove == null)
            { return false; }

            enrollments.Remove(enrollmentToRemove);
            return true;

        }

    }
}
