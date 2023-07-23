using StreamCasa.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Entities
{
    public class Users : IEntity
    {
        public Users()
        {
            DateRegistry = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DateRegistry { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }
        public void SetBirthDate(DateTime birthDate)
        {
            ValidateAge(birthDate);
            BirthDate = birthDate;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetPassWord(string password)
        {
            Password = password;
        }
        private void ValidateAge(DateTime date)
        {
            var local = DateTime.Now;
            int age = 0;
            age = local.Year - date.Year;
            if (local.DayOfYear < date.DayOfYear)
            {
                age--;
            }
            if (age < 16)
            {
                throw new Exception("Edad no permitida para registro en los cursos");
            }
        }
    }
}
