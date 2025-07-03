using SwimConnectApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimConnectApp.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Club { get; set; }

        public Category Category { get; set; }
        public Athlete(int id, string name, int age, string club) 
        {
            Id = id;
            Name = name;
            Age = age;
            Club = club;
            Category = DefineCategory(age);
        }

        private Category DefineCategory(int age)
        {
            if (age < 16) return Category.Junior;
            else if (age < 18) return Category.Senior;
            else return Category.Master;
        }

        public override string ToString() 
        {
            return $"{Name} - {Age} years old - {Club} - {Category}";
        }
    }
}
