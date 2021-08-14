using System;
using System.Collections.Generic;

namespace iLearn.Models
{
    public partial class Degreelist
    {
        public Degreelist()
        {
            Candidatedetails = new HashSet<Candidatedetails>();
            Coursemain = new HashSet<Coursemain>();
            Streamlist = new HashSet<Streamlist>();
        }

        public int Degreeid { get; set; }
        public int? Courseid { get; set; }
        public string Degreename { get; set; }

        public Coursemain Course { get; set; }
        public ICollection<Candidatedetails> Candidatedetails { get; set; }
        public ICollection<Coursemain> Coursemain { get; set; }
        public ICollection<Streamlist> Streamlist { get; set; }
    }
}
