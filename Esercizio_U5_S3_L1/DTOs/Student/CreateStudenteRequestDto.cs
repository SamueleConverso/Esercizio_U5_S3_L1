using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S3_L1.DTOs.Student {
    public class CreateStudenteRequestDto {

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

        [Required]
        public required string FiscalCode {
            get; set;
        }

        [Required]
        public required DateOnly BirthDate {
            get; set;
        }
    }
}
