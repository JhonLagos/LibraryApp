using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAppBackend.Entities
{
    [Table("authors")]
    public class Author
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Column("surname")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string Surname { get; set; }

        [Column("date_birth")]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime? DateBirth { get; set; }

        [Column("city")]
        [Required(ErrorMessage = "La ciudad de procedencia es requerida")]
        [MaxLength(100)]
        public string City { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "El correo electrónico requerido")]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
