using code_wizards_api.Models;

namespace code_wizards_api.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<NoteModel>> GetAllNotes();
        Task<NoteModel> GetById(int id);
        Task<NoteModel> Add(NoteModel note);
        Task<NoteModel> Update(NoteModel note, int id);
        Task<bool> Delete(int id);
    }
}