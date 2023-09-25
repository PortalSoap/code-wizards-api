using code_wizards_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace code_wizards_api.Models
{
    [Route("NotesAPI/[Controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteModel>>> GetAllNotes()
        {
            List<NoteModel> notes = await _noteRepository.GetAllNotes();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> GetById(int id)
        {
            NoteModel note = await _noteRepository.GetById(id);
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<NoteModel>> Add([FromBody] NoteModel newNote)
        {
            NoteModel note = await _noteRepository.Add(newNote);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NoteModel>> Update([FromBody] NoteModel newNote, int id)
        {
            newNote.Id = id;
            NoteModel note = await _noteRepository.Update(newNote, id);
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _noteRepository.Delete(id);
            return Ok(deleted);
        }
    }
}