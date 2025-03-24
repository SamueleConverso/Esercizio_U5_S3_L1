using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S3_L1.Models {
    public class Studente {
        [Key]
        public Guid Id {
            get; set;
        }

        [Required]
        public required string Nome {
            get; set;
        }

        [Required]
        public required string Cognome {
            get; set;
        }

        [Required]
        public required string Email {
            get; set;
        }
    }
}
