using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BeMyTeacher.DB
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
