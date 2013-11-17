using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Common
{
    public class UserExercise
    {
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public int Repetitons { get; set; }
        public int Sets { get; set; }
        public int Duration { get; set; }
        public double Distance { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Instruction> Instructions { get; set; }
        public virtual List<Image> Images { get; set; }
        public string Type { get; set; }
    }
    public class Instruction
    {
        public string Content { get; set; }
        public int Number { get; set; }
    }
    public class Image
    {
        public byte[] Picture { get; set; }
        public string Description { get; set; }
    }
}
