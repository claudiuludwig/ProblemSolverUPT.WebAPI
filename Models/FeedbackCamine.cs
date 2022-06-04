using System;
using System.Collections.Generic;

#nullable disable

namespace ProblemSolverUPT.WebAPI.Models
{
    public partial class FeedbackCamine
    {
        public int Id { get; set; }
        public int? Upvotes { get; set; }
        public int? Downvotes { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? DataPostare { get; set; }
        public string Camin { get; set; }
        public string Camera { get; set; }
        public string ContentProblema { get; set; }
        public string Imagine { get; set; }
        public string EmailAddress { get; set; }
    }
}
