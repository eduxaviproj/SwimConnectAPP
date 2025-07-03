namespace SwimConnectApp.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Athlete Athlete { get; set; }
        public Race Race { get; set; }

        public Enrollment(int id, Athlete athlete, Race race)
        {
            Id = id;
            Athlete = athlete;
            Race = race;
        }

        public override string ToString()
        {
            return $"ID [{Id}]  |  {Athlete.Name} is enrolled at {Race}";
        }

    }
}
