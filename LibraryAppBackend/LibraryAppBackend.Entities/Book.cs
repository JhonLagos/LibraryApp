using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAppBackend.Entities
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        [MaxLength(100)]
        [Required(ErrorMessage = "El titulo es requerido")]
        public string Title { get; set; }

        [Column("year")]
        [Required(ErrorMessage = "El año es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El año es requerido")]
        public int Year { get; set; }

        [Column("genre")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El genero es requerido")]
        public string Genre { get; set; }

        [Column("number_pages")]
        [Required(ErrorMessage = "El número de paginas es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de paginas es requerido")]
        public int NumberPages { get; set; }

        [Column("author_id")]
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El id del autor es requerido")]
        public long AuthorId { get; set; }

        [Column("editorial_id")]
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El id de la editorial es requerido")]
        public long EditorialId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }
    }
}
