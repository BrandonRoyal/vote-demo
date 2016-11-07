using System;

namespace Vote.Worker.Models
{
    public class Candidate
    {
        public String Name { get; set; }
        public Guid Id { get; set; }
        public String ImgPath { get; set; }
    }
}