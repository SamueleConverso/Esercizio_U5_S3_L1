using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S3_L1.DTOs.Student {
    public class StudenteProfileDto {
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

    }
}
