namespace MusicianScaleApp;

/// <summary>
/// Represents a musical scale with its interval pattern
/// </summary>
public class Scale
{
    public string Name { get; }
    public int[] IntervalPattern { get; }

    private static readonly Dictionary<string, int[]> ScalePatterns = new()
    {
        // Major scale: W-W-H-W-W-W-H (W=whole step=2 semitones, H=half step=1 semitone)
        { "major", new[] { 2, 2, 1, 2, 2, 2, 1 } },

        // Natural minor scale: W-H-W-W-H-W-W
        { "minor", new[] { 2, 1, 2, 2, 1, 2, 2 } },
        { "natural minor", new[] { 2, 1, 2, 2, 1, 2, 2 } },

        // Harmonic minor: W-H-W-W-H-W+H-H
        { "harmonic minor", new[] { 2, 1, 2, 2, 1, 3, 1 } },

        // Melodic minor: W-H-W-W-W-W-H
        { "melodic minor", new[] { 2, 1, 2, 2, 2, 2, 1 } },

        // Pentatonic major: W-W-W+H-W-W+H
        { "pentatonic major", new[] { 2, 2, 3, 2, 3 } },

        // Pentatonic minor: W+H-W-W-W+H-W
        { "pentatonic minor", new[] { 3, 2, 2, 3, 2 } },

        // Blues scale
        { "blues", new[] { 3, 2, 1, 1, 3, 2 } },

        // Dorian mode: W-H-W-W-W-H-W
        { "dorian", new[] { 2, 1, 2, 2, 2, 1, 2 } },

        // Phrygian mode: H-W-W-W-H-W-W
        { "phrygian", new[] { 1, 2, 2, 2, 1, 2, 2 } },

        // Lydian mode: W-W-W-H-W-W-H
        { "lydian", new[] { 2, 2, 2, 1, 2, 2, 1 } },

        // Mixolydian mode: W-W-H-W-W-H-W
        { "mixolydian", new[] { 2, 2, 1, 2, 2, 1, 2 } },

        // Locrian mode: H-W-W-H-W-W-W
        { "locrian", new[] { 1, 2, 2, 1, 2, 2, 2 } }
    };

    public Scale(string scaleName)
    {
        string normalizedName = scaleName.ToLower().Trim();

        if (!ScalePatterns.ContainsKey(normalizedName))
        {
            throw new ArgumentException($"Unknown scale: {scaleName}");
        }

        Name = scaleName;
        IntervalPattern = ScalePatterns[normalizedName];
    }

    /// <summary>
    /// Generates all notes in this scale starting from the given root note
    /// </summary>
    public List<Note> GenerateNotes(Note rootNote)
    {
        var notes = new List<Note> { rootNote };
        int currentSemitone = 0;

        foreach (int interval in IntervalPattern)
        {
            currentSemitone += interval;
            notes.Add(rootNote.Transpose(currentSemitone));
        }

        return notes;
    }

    /// <summary>
    /// Gets all available scale names
    /// </summary>
    public static string[] GetAllScaleNames()
    {
        return ScalePatterns.Keys.ToArray();
    }

    public override string ToString() => Name;
}
