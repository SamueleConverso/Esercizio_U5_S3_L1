﻿using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S3_L1.DTOs.Student {
    public class UpdateStudenteResponseDto {
        [Required]
        public required string Message {
            get; set;
        }
    }
}
