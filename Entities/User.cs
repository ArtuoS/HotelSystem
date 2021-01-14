using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public DateTime Date_Of_Birthday { get; set; }
        [Required]
        public Biological_Gender Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public double Weigth { get; set; }
        [Required]
        public double Heigth { get; set; }
        [Required]
        public double BodyFat { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Restriction> Restrictions { get; set; }

    }
}
