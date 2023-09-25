using code_wizards_api.Data;
using code_wizards_api.Models;
using code_wizards_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace code_wizards_api.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesSystemDbContext _dbContext;

        public NoteRepository(NotesSystemDbContext notesSystemDbContext)
        {
            _dbContext = notesSystemDbContext;
        }

        public async Task<List<NoteModel>> GetAllNotes()
        {
            return await _dbContext.Notes
            .Include(x => x.User)
            .ToListAsync();
        }

        public async Task<NoteModel> GetById(int id)
        {
            return await _dbContext.Notes
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NoteModel> Add(NoteModel note)
        {
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();

            return note;
        }

        public async Task<NoteModel> Update(NoteModel note, int id)
        {
           NoteModel targetNote = await GetById(id);

           if(targetNote == null)
           {
                throw new Exception($"ID Error: Não foi encontrado anotação com o ID especificado ({id}).");
           }
           
           targetNote.Title = note.Title;
           targetNote.Description = note.Description;
           targetNote.UserId = note.UserId;

           _dbContext.Notes.Update(targetNote);
           await _dbContext.SaveChangesAsync();

           return targetNote;
        }

        public async Task<bool> Delete(int id)
        {
            NoteModel targetNote = await GetById(id);

           if(targetNote == null)
           {
                throw new Exception($"ID Error: Não foi encontrado anotação com o ID especificado ({id}).");
           }

            _dbContext.Notes.Remove(targetNote);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}