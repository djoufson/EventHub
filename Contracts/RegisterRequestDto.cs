using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Contracts
{
    public class RegisterRequestDto
    {
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}