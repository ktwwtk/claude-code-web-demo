namespace MusicianScaleApp.Tests;

public class ScaleTests
{
    [Fact]
    public void Constructor_ValidScale_CreatesScale()
    {
        // Arrange & Act
        var scale = new Scale("major");

        // Assert
        Assert.Equal("major", scale.Name);
        Assert.NotNull(scale.IntervalPattern);
    }

    [Fact]
    public void Constructor_InvalidScale_ThrowsArgumentException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() => new Scale("invalid"));
        Assert.Throws<ArgumentException>(() => new Scale("xyz"));
    }

    [Fact]
    public void Constructor_CaseInsensitive_CreatesScale()
    {
        // Arrange & Act
        var scale1 = new Scale("MAJOR");
        var scale2 = new Scale("Major");
        var scale3 = new Scale("major");

        // Assert
        Assert.NotNull(scale1);
        Assert.NotNull(scale2);
        Assert.NotNull(scale3);
    }

    [Theory]
    [InlineData("major")]
    [InlineData("minor")]
    [InlineData("natural minor")]
    [InlineData("harmonic minor")]
    [InlineData("melodic minor")]
    [InlineData("pentatonic major")]
    [InlineData("pentatonic minor")]
    [InlineData("blues")]
    [InlineData("dorian")]
    [InlineData("phrygian")]
    [InlineData("lydian")]
    [InlineData("mixolydian")]
    [InlineData("locrian")]
    public void Constructor_AllSupportedScales_DoNotThrow(string scaleName)
    {
        // Act & Assert
        var exception = Record.Exception(() => new Scale(scaleName));
        Assert.Null(exception);
    }

    [Fact]
    public void GenerateNotes_CMajor_ReturnsCorrectNotes()
    {
        // Arrange
        var scale = new Scale("major");
        var rootNote = new Note("C");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(8, notes.Count); // 7 notes + octave
        Assert.Equal("C", notes[0].Name);
        Assert.Equal("D", notes[1].Name);
        Assert.Equal("E", notes[2].Name);
        Assert.Equal("F", notes[3].Name);
        Assert.Equal("G", notes[4].Name);
        Assert.Equal("A", notes[5].Name);
        Assert.Equal("B", notes[6].Name);
        Assert.Equal("C", notes[7].Name); // Octave
    }

    [Fact]
    public void GenerateNotes_AMinor_ReturnsCorrectNotes()
    {
        // Arrange
        var scale = new Scale("minor");
        var rootNote = new Note("A");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(8, notes.Count);
        Assert.Equal("A", notes[0].Name);
        Assert.Equal("B", notes[1].Name);
        Assert.Equal("C", notes[2].Name);
        Assert.Equal("D", notes[3].Name);
        Assert.Equal("E", notes[4].Name);
        Assert.Equal("F", notes[5].Name);
        Assert.Equal("G", notes[6].Name);
        Assert.Equal("A", notes[7].Name); // Octave
    }

    [Fact]
    public void GenerateNotes_GMajor_ReturnsCorrectNotes()
    {
        // Arrange
        var scale = new Scale("major");
        var rootNote = new Note("G");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(8, notes.Count);
        Assert.Equal("G", notes[0].Name);
        Assert.Equal("A", notes[1].Name);
        Assert.Equal("B", notes[2].Name);
        Assert.Equal("C", notes[3].Name);
        Assert.Equal("D", notes[4].Name);
        Assert.Equal("E", notes[5].Name);
        Assert.Equal("F#", notes[6].Name);
        Assert.Equal("G", notes[7].Name); // Octave
    }

    [Fact]
    public void GenerateNotes_PentatonicMajor_ReturnsCorrectNumberOfNotes()
    {
        // Arrange
        var scale = new Scale("pentatonic major");
        var rootNote = new Note("C");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(6, notes.Count); // 5 notes + octave
        Assert.Equal("C", notes[0].Name);
        Assert.Equal("D", notes[1].Name);
        Assert.Equal("E", notes[2].Name);
        Assert.Equal("G", notes[3].Name);
        Assert.Equal("A", notes[4].Name);
        Assert.Equal("C", notes[5].Name); // Octave
    }

    [Fact]
    public void GenerateNotes_BluesScale_ReturnsCorrectNotes()
    {
        // Arrange
        var scale = new Scale("blues");
        var rootNote = new Note("C");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(7, notes.Count); // 6 notes + octave
        Assert.Equal("C", notes[0].Name);
        Assert.Equal("D#", notes[1].Name);
        Assert.Equal("F", notes[2].Name);
        Assert.Equal("F#", notes[3].Name);
        Assert.Equal("G", notes[4].Name);
        Assert.Equal("A#", notes[5].Name);
        Assert.Equal("C", notes[6].Name); // Octave
    }

    [Fact]
    public void GenerateNotes_FirstNoteIsRoot()
    {
        // Arrange
        var scale = new Scale("major");
        var rootNote = new Note("D#");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(rootNote.Name, notes[0].Name);
    }

    [Fact]
    public void GenerateNotes_LastNoteIsOctave()
    {
        // Arrange
        var scale = new Scale("major");
        var rootNote = new Note("F");

        // Act
        var notes = scale.GenerateNotes(rootNote);

        // Assert
        Assert.Equal(rootNote.Name, notes[^1].Name); // Last note should be same as root (octave)
    }

    [Fact]
    public void GetAllScaleNames_ReturnsAllScales()
    {
        // Act
        var scaleNames = Scale.GetAllScaleNames();

        // Assert
        Assert.NotEmpty(scaleNames);
        Assert.Contains("major", scaleNames);
        Assert.Contains("minor", scaleNames);
        Assert.Contains("blues", scaleNames);
        Assert.Contains("dorian", scaleNames);
        Assert.True(scaleNames.Length >= 12); // At least 12 different scales
    }

    [Fact]
    public void ToString_ReturnsScaleName()
    {
        // Arrange
        var scale = new Scale("harmonic minor");

        // Act
        var result = scale.ToString();

        // Assert
        Assert.Equal("harmonic minor", result);
    }

    [Fact]
    public void IntervalPattern_MajorScale_HasCorrectPattern()
    {
        // Arrange
        var scale = new Scale("major");

        // Act
        var pattern = scale.IntervalPattern;

        // Assert
        Assert.Equal(new[] { 2, 2, 1, 2, 2, 2, 1 }, pattern);
    }

    [Fact]
    public void IntervalPattern_MinorScale_HasCorrectPattern()
    {
        // Arrange
        var scale = new Scale("minor");

        // Act
        var pattern = scale.IntervalPattern;

        // Assert
        Assert.Equal(new[] { 2, 1, 2, 2, 1, 2, 2 }, pattern);
    }

    [Fact]
    public void GenerateNotes_DifferentRoots_SameRelativeStructure()
    {
        // Arrange
        var scale = new Scale("major");
        var c = new Note("C");
        var g = new Note("G");

        // Act
        var cMajorNotes = scale.GenerateNotes(c);
        var gMajorNotes = scale.GenerateNotes(g);

        // Assert
        // Both should have same number of notes
        Assert.Equal(cMajorNotes.Count, gMajorNotes.Count);

        // Calculate intervals between consecutive notes
        for (int i = 0; i < cMajorNotes.Count - 1; i++)
        {
            int cInterval = (cMajorNotes[i + 1].SemitoneIndex - cMajorNotes[i].SemitoneIndex + 12) % 12;
            int gInterval = (gMajorNotes[i + 1].SemitoneIndex - gMajorNotes[i].SemitoneIndex + 12) % 12;
            Assert.Equal(cInterval, gInterval);
        }
    }

    [Theory]
    [InlineData("dorian", new[] { 2, 1, 2, 2, 2, 1, 2 })]
    [InlineData("phrygian", new[] { 1, 2, 2, 2, 1, 2, 2 })]
    [InlineData("lydian", new[] { 2, 2, 2, 1, 2, 2, 1 })]
    [InlineData("mixolydian", new[] { 2, 2, 1, 2, 2, 1, 2 })]
    [InlineData("locrian", new[] { 1, 2, 2, 1, 2, 2, 2 })]
    public void IntervalPattern_Modes_HaveCorrectPatterns(string modeName, int[] expectedPattern)
    {
        // Arrange
        var scale = new Scale(modeName);

        // Act
        var pattern = scale.IntervalPattern;

        // Assert
        Assert.Equal(expectedPattern, pattern);
    }
}
