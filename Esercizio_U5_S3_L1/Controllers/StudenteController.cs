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

            return Ok(new {
                message = $"Numero studenti trovati: {studentiList.Count}",
                studenti = studentiList
            });
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetStudenteByEmail([FromQuery] string email) {
            Studente studente = await _studenteService.GetStudenteByEmailAsync(email);

            if (studente == null) {
                return BadRequest(new {
                    message = "Errore nel recupero dello studente"
                });
            }

            //if (!studente.Any()) {
            //    return NoContent();
            //}

            return Ok(new {
                message = "Studente trovato",
                studenteFound = studente
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddStudente([FromBody] Studente studente) {
            var result = await _studenteService.AddStudenteAsync(studente);

            if (!result) {
                return BadRequest(new {
                    message = "Errore nell'aggiunta dello studente"
                });
            }

            return Ok(new {
                message = "Studente aggiunto con successo"
            });
        }

        [HttpDelete("DeleteByEmail")]
        public async Task<IActionResult> DeleteStudente([FromQuery] string email) {
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


    }
}
