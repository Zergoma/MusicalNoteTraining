using MusicalNoteTraining.Utilities;

namespace MusicalNoteTraining.DTO
{
    public class MusicalNoteDTO
    {
        public required Notes MyNote { get; init; }
        public required string SoundFilePath { get; init; }
        public required string Color { get; init; }
    }
}
