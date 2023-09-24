namespace code_wizards_api.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}