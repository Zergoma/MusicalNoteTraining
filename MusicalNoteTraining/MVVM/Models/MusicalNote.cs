using MusicalNoteTraining.Utilities;

namespace MusicalNoteTraining.MVVM.Models
{
    public class MusicalNote
    {
        public required Notes MyNote{ get; init; }
        public required string path { get; init; }
        public required string color { get; init; }
    }
}
