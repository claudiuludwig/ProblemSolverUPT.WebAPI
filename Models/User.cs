using System;
using System.Collections.Generic;

namespace ProblemSolverUPT.WebAPI.Models
{
    public partial class User
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Faculty { get; set; }
        public string Role { get; set; }
    }
}
