using Esercizio_U5_S3_L1.Data;
using Esercizio_U5_S3_L1.DTOs.Student;
using Esercizio_U5_S3_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S3_L1.Services {
    public class StudenteService {
        private ApplicationDbContext _context;

        public StudenteService(ApplicationDbContext context) {
            _context = context;
        }

        private async Task<bool> SaveAsync() {
            try {
                var rows = await _context.SaveChangesAsync();

                if (rows > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Studente>> GetAllStudentiAsync() {
            var studenti = new List<Studente>();

            try {
                studenti = await _context.Studenti.Include(s => s.StudenteProfile).ToListAsync();
                return studenti;
            } catch (Exception ex) {
                studenti = new List<Studente>();
                Console.WriteLine(ex.Message);
            }

            return studenti;
        }

        public async Task<Studente> GetStudenteByEmailAsync(string email) {
            Studente studente = null;

            try {
                studente = await _context.Studenti.FirstOrDefaultAsync(s => s.Email == email);
                return studente;
            } catch (Exception ex) {
                studente = null;
                Console.WriteLine(ex.Message);
            }

            return studente;
        }

        public async Task<bool> AddStudenteAsync(Studente studente) {
            try {
                _context.Studenti.Add(studente);
                return await SaveAsync();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteStudenteAsync(string email) {
            try {
                var studente = await GetStudenteByEmailAsync(email);
                if (studente == null) {
                    return false;
                }
                _context.Studenti.Remove(studente);
                return await SaveAsync();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateStudenteAsync(string email, UpdateStudenteRequestDto updateStudenteRequestDto) {
            Studente studenteTrovato = await GetStudenteByEmailAsync(email);

            studenteTrovato.Nome = updateStudenteRequestDto.Nome;
            studenteTrovato.Cognome = updateStudenteRequestDto.Cognome;
            studenteTrovato.Email = updateStudenteRequestDto.Email;

            return await SaveAsync();
        }
    }
}
