using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAppBackend.Entities
{
    [Table("editorials")]
    public class Editorial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Column("address")]
        [MaxLength(100)]
        [Required(ErrorMessage = "La dirección de correspondencia requerida")]
        public string Address { get; set; }

        [Column("telephone")]
        [MaxLength(20)]
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telephone { get; set; }

        [Column("email")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        public string Email { get; set; }

        [Column("maximum_books_register")]
        [Required(ErrorMessage = "El número maximo de libros a registrar es requerido")]
        public int MaximumBooksRegister  { get; set; }
    }
}
