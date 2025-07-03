using SwimConnectApp.Enums;
using SwimConnectApp.Models;
using SwimConnectApp.Services;
using System;

namespace SwimConnectApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Athlete athlete = new Athlete(1, "Eduardo", 26, "Lousada XXI");
            //Race race = new Race(1, SwimStyle.Backstroke, 200);
            //Enrollment enrollment = new Enrollment(athlete, race);

            //Console.WriteLine(athlete);
            //Console.WriteLine(race);
            //Console.WriteLine(enrollment);

            //CreateAthlete(manager);
            //Console.ReadLine();
            //CreateRace(manager);
            //Console.ReadLine();
            //CreateEnroll(manager);
            //Console.ReadLine();
            //ReadEnrollsByRace(manager);
            //Console.ReadLine();

            var manager = new EnrollManager();

            while (true)
            {
                Console.WriteLine("\n------- Manager of SwimConnect -------\n");
                Console.WriteLine("[1] Enroll Athlete");
                Console.WriteLine("[2] Enroll Race");
                Console.WriteLine("[3] Enroll Athlete in Race");
                Console.WriteLine("[4] List of Athletes");
                Console.WriteLine("[5] List of Races");
                Console.WriteLine("[6] List of Enrolls");
                Console.WriteLine("[7] Delete Enroll");
                Console.WriteLine("[0] Quit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        {
                            CreateAthlete(manager);
                            break;
                        }
                    case "2":
                        {
                            CreateRace(manager);
                            break;
                        }
                    case "3":
                        {
                            CreateEnroll(manager);
                            break;
                        }
                    case "4":
                        {
                            ReadAthletes(manager);
                            break;
                        }
                    case "5":
                        {
                            ReadRaces(manager);
                            break;
                        }
                    case "6":
                        {
                            ReadEnrolls(manager);
                            break;
                        }
                    case "7":
                        {
                            DeleteEnroll(manager);
                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine("Quitting..");
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }

        }




        static void CreateAthlete(EnrollManager manager)
        {
            Console.Write("Write the name of the athlete you want to enroll: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Club: ");
            string club = Console.ReadLine();

            Athlete athlete = manager.CreateAthlete(name, age, club);
            Console.WriteLine($"The athlete {athlete.Name} is enrolled with success!");
        }


        static void CreateRace(EnrollManager manager)
        {
            Console.WriteLine("Race you want the athlete to perform: ");
            foreach (var estilo in Enum.GetValues(typeof(SwimStyle)))
            {
                Console.WriteLine($"{(int)estilo} - {estilo}");
            }
            Console.Write($"Swimming style (number): ");
            int styleNum = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine($"Distance (meters)");
            int distance = int.Parse(Console.ReadLine() ?? string.Empty);

            Race race = manager.CreateRace((SwimStyle)styleNum, distance);
            Console.WriteLine($"Race sucessfully enrolled: {race}");
        }


        static void CreateEnroll(EnrollManager manager)
        {
            //ATHLETE
            Console.WriteLine("------------ Athletes List -------------");

            var athletes = manager.ReadAthletes();
            if (athletes.Count == 0 || athletes == null)
            {
                Console.WriteLine("No athlete is enrolled yet, please enroll one!");
                return;
            }
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"ID [{athlete.Id}]  -  Name: {athlete.Name} | Age: {athlete.Age} | Club: {athlete.Club}");
            }

            Console.Write("Type the ID of the athlete you want to enroll: ");
            int athleteId = int.Parse(Console.ReadLine() ?? "0");


            //RACE
            Console.WriteLine("------------ Races List -------------");

            var races = manager.ReadRaces();
            if (races.Count == 0 || races == null)
            {
                Console.WriteLine("No race is enrolled yet, please enroll one!");
                return;
            }
            foreach (var race in races)
            {
                Console.WriteLine($"ID [{race.Id}]  -  Race: {race.Distance}m {race.SwimStyle}");
            }

            Console.Write("Type the ID of the race you want to enroll: ");
            int raceId = int.Parse(Console.ReadLine() ?? "0");


            //ENROLL
            bool success = manager.CreateEnroll(athleteId, raceId);
            if (success)
            {
                Console.WriteLine("✅ Enroll successfully created");
            }
            else
            {
                Console.WriteLine("⚠️ Error at trying to enroll. Please try again!");
            }
        }


        //ATHLETE
        static void ReadAthletes(EnrollManager manager)
        {
            var athletes = manager.ReadAthletes();
            if (athletes.Count == 0)
            {
                Console.WriteLine("No athlete is registered yet!");
                return;
            }

            Console.WriteLine("------------ Registered Athletes --------------");
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"{athlete}");
            }
        }

        //RACE
        static void ReadRaces(EnrollManager manager)
        {
            var races = manager.ReadRaces();
            if (races.Count == 0)
            {
                Console.WriteLine("No race is registed yet!");
            }

            Console.WriteLine("------------ Registed Races --------------");
            foreach (var race in races)
            {
                Console.WriteLine(race);
            }
        }

        //ENROLL
        //static void ReadEnrollsByRace(EnrollManager manager)
        //{
        //    Console.WriteLine("---------- Races List -----------");
        //    var races = manager.ReadRaces();
        //    if (races.Count == 0)
        //    {
        //        Console.WriteLine("No races are yet registered!");
        //        return;
        //    }
        //    foreach (var race in races)
        //    {
        //        Console.WriteLine($"ID [{race.Id}] {race}");
        //    }

        //    Console.Write("Type Race ID to list registered athletes in this race: ");
        //    int raceId = int.Parse(Console.ReadLine() ?? "0");

        //    var enrolled = manager.ReadEnrollsByRace(raceId);
        //    if (enrolled.Count == 0)
        //    {
        //        Console.WriteLine("No athlete is registered in this race!");
        //    }
        //    Console.WriteLine("Registered athletes in this race: ");
        //    foreach (var enroll in enrolled)
        //    {
        //        Console.WriteLine($"{enroll}");
        //    }
        //}

        static void ReadEnrolls(EnrollManager gestor)
        {
            var provas = gestor.ReadEnrolls();
            if (provas.Count == 0)
            { Console.WriteLine("No enroll registered yet"); return; }
            Console.WriteLine("----------- Enrolls ----------");
            foreach (var prova in provas)
            { Console.WriteLine(prova); }
        }

        static void DeleteEnroll(EnrollManager manager)
        {
            Console.WriteLine("------------ List of Enrolls ------------");
            var enrolls = manager.ReadEnrolls();
            foreach (var enroll in enrolls)
            {
                Console.WriteLine(enroll);
            }
            Console.WriteLine("Type the enroll ID you want to delete: ");
            int enrollId = int.Parse(Console.ReadLine() ?? string.Empty);

            bool removed = manager.DeleteEnroll(enrollId);
            if (!removed)
            { Console.WriteLine("Something went wrong!"); }
            else
            {
                Console.WriteLine("Enroll deleted successfully!");
            }
        }
    }
}
