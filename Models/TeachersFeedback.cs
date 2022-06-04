using System;
using System.Collections.Generic;


namespace ProblemSolverUPT.WebAPI.Models
{
    public partial class TeachersFeedback
    {
        public int Id { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime DataPostare { get; set; }
        public string Facultate { get; set; }
        public string Sectie { get; set; }
        public string AnStudiu { get; set; }
        public string CadrulDidactic { get; set; }
        public string Materia { get; set; }
        public string ContentProblema { get; set; }
        public string RezolvareProblema { get; set; }
        public string EmailAddress { get; set; }
    }
}
