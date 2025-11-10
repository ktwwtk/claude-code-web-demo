namespace MusicianScaleApp;

/// <summary>
/// Represents a musical note
/// </summary>
public class Note
{
    public string Name { get; }
    public int SemitoneIndex { get; }

    private static readonly string[] ChromaticScale =
    {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };

    // Alternative note names (flats)
    private static readonly Dictionary<string, string> EnharmonicEquivalents = new()
    {
        { "Db", "C#" },
        { "Eb", "D#" },
        { "Gb", "F#" },
        { "Ab", "G#" },
        { "Bb", "A#" }
    };

    public Note(string name)
    {
        // Normalize the note name (handle enharmonic equivalents)
        string normalizedName = EnharmonicEquivalents.ContainsKey(name)
            ? EnharmonicEquivalents[name]
            : name;

        int index = Array.IndexOf(ChromaticScale, normalizedName);
        if (index == -1)
        {
            throw new ArgumentException($"Invalid note name: {name}");
        }

        Name = normalizedName;
        SemitoneIndex = index;
    }

    /// <summary>
    /// Gets a note at a given interval (in semitones) from this note
    /// </summary>
    public Note Transpose(int semitones)
    {
        int newIndex = (SemitoneIndex + semitones) % 12;
        return new Note(ChromaticScale[newIndex]);
    }

    public override string ToString() => Name;

    /// <summary>
    /// Gets all valid note names
    /// </summary>
    public static string[] GetAllNoteNames()
    {
        return ChromaticScale.Concat(EnharmonicEquivalents.Keys).ToArray();
    }
}
