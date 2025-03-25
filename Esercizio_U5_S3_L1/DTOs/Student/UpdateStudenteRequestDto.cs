using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S3_L1.DTOs.Student {
    public class UpdateStudenteRequestDto {
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
