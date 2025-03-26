using Esercizio_U5_S3_L1.DTOs.Student;
using Esercizio_U5_S3_L1.Models;
using Esercizio_U5_S3_L1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_U5_S3_L1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudenteController : ControllerBase {
        private readonly StudenteService _studenteService;

        public StudenteController(StudenteService studenteService) {
            _studenteService = studenteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudenti() {
            var studentiList = await _studenteService.GetAllStudentiAsync();

            if (studentiList == null) {
                return BadRequest(new {
                    message = "Errore nel recupero degli studenti"
                });
            }

            if (!studentiList.Any()) {
                return NoContent();
            }

            var studentiResponse = studentiList.Select(s => new StudenteDto() {
                Nome = s.Nome,
                Cognome = s.Cognome,
                Email = s.Email,
                StudenteProfileDto = s.StudenteProfile != null ? new StudenteProfileDto() {
                    FirstName = s.StudenteProfile.FirstName,
                    LastName = s.StudenteProfile.LastName,
                    FiscalCode = s.StudenteProfile.FiscalCode,
                    BirthDate = s.StudenteProfile.BirthDate
                } : null
            });

            return Ok(new {
                message = $"Numero studenti trovati: {studentiResponse.Count()}",
                studenti = studentiResponse
            });
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetStudenteByEmail(string email) {
            Studente studente = await _studenteService.GetStudenteByEmailAsync(email);

            if (studente == null) {
                return BadRequest(new {
                    message = "Errore nel recupero dello studente"
                });
            }
            var studenteDto = new StudenteDto() {
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                StudenteProfileDto = studente.StudenteProfile != null ? new StudenteProfileDto() {
                    FirstName = studente.StudenteProfile.FirstName,
                    LastName = studente.StudenteProfile.LastName,
                    FiscalCode = studente.StudenteProfile.FiscalCode,
                    BirthDate = studente.StudenteProfile.BirthDate
                } : null
            };

            //if (!studente.Any()) {
            //    return NoContent();
            //}

            return Ok(new {
                message = "Studente trovato",
                studenteFound = studenteDto
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudente([FromBody] CreateStudenteRequestDto createStudenteRequestDto) {
            var newStudente = new Studente {
                Nome = createStudenteRequestDto.Nome,
                Cognome = createStudenteRequestDto.Cognome,
                Email = createStudenteRequestDto.Email,
                StudenteProfile = new StudenteProfile() {
                    FirstName = createStudenteRequestDto.Nome,
                    LastName = createStudenteRequestDto.Cognome,
                    FiscalCode = createStudenteRequestDto.FiscalCode,
                    BirthDate = createStudenteRequestDto.BirthDate
                }
            };

            var result = await _studenteService.AddStudenteAsync(newStudente);

            if (!result) {
                return BadRequest(new CreateStudenteResponseDto {
                    Message = "Errore nell'aggiunta dello studente"
                });
            }

            return Ok(new CreateStudenteResponseDto {
                Message = "Studente aggiunto con successo"
            });
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteStudente(string email) {
            var result = await _studenteService.DeleteStudenteAsync(email);

            if (!result) {
                return BadRequest(new {
                    message = "Errore nella cancellazione dello studente"
                });
            }

            return Ok(new {
                message = "Studente cancellato con successo"
            });
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateStudente(string email, [FromBody] UpdateStudenteRequestDto updateStudenteRequestDto) {
            var result = await _studenteService.UpdateStudenteAsync(email, updateStudenteRequestDto);

            if (!result) {
                return BadRequest(new UpdateStudenteResponseDto {
                    Message = "Errore nella modifica"
                });
            }

            return Ok(new UpdateStudenteResponseDto {
                Message = "Studente aggiornato con successo"
            });
        }
    }
}
