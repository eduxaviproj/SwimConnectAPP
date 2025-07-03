using SwimConnectApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimConnectApp.Models
{
    public class Race
    {
        public int Id { get; set; }
        public SwimStyle SwimStyle { get; set; }
        public int Distance { get; set; }

        public Race (int id, SwimStyle swimStyle, int distance) 
        {
            Id = id;
            SwimStyle = swimStyle;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"Race: {SwimStyle} {Distance}m";
        }

    }
}
