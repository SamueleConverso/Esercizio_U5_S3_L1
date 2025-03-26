using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercizio_U5_S3_L1.Models {
    public class StudenteProfile {
        [Key]
        public int Id {
            get; set;
        }

        [Required]
        public required string FirstName {
            get; set;
        }

        [Required]
        public required string LastName {
            get; set;
        }

        [Required]
        public required string FiscalCode {
            get; set;
        }

        [Required]
        public required DateOnly BirthDate {
            get; set;
        }

        [Required]
        public Guid StudenteId {
            get; set;
        }

        [ForeignKey("StudenteId")]
        public Studente Studente {
            get; set;
        }
    }
}
