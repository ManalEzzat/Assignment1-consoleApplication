using System;
using System.Collections.Generic;
using System.Text;

namespace Mangment_System
{
    internal class Course
    {
        public static int Count = 1;
        public int Id;
        public string Name ;
        public float Score {  set; get; }
        public int Hour;
       
        public Course(string name, int hours)
        {
            this.Id = Count;
            this.Name = name;
            this.Hour = hours;
            Count++;    
        }
        public void AddScore(float score)
        {
            this.Score = score;

        }
        

    }
}
