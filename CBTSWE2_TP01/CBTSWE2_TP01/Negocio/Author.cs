using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTSWE2_TP01.Negocio
{
    internal class Author
    {
        private string name;
        private string email;
        private char gender;

        public Author(string name, string email, char gender)
        {
            this.Name = name;
            this.Email = email;
            this.Gender = gender;
        }
        public Author(string name)
        {
            this.Name = name;
        }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public char Gender { get => gender; set => gender = value; }
        public override string ToString()
        {
            return $"Author[name={Name}, email={Email}, gender={Gender}]";
        }
    }
}
