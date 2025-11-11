namespace MusicianScaleApp.Tests;

public class NoteTests
{
    [Fact]
    public void Constructor_ValidSharpNote_CreatesNote()
    {
        // Arrange & Act
        var note = new Note("C#");

        // Assert
        Assert.Equal("C#", note.Name);
        Assert.Equal(1, note.SemitoneIndex);
    }

    [Fact]
    public void Constructor_ValidNaturalNote_CreatesNote()
    {
        // Arrange & Act
        var note = new Note("A");

        // Assert
        Assert.Equal("A", note.Name);
        Assert.Equal(9, note.SemitoneIndex);
    }

    [Fact]
    public void Constructor_ValidFlatNote_NormalizesToSharp()
    {
        // Arrange & Act
        var note = new Note("Bb");

        // Assert
        Assert.Equal("A#", note.Name);
        Assert.Equal(10, note.SemitoneIndex);
    }

    [Fact]
    public void Constructor_InvalidNote_ThrowsArgumentException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() => new Note("H"));
        Assert.Throws<ArgumentException>(() => new Note("X"));
        Assert.Throws<ArgumentException>(() => new Note("C##"));
    }

    [Theory]
    [InlineData("C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B")]
    public void Constructor_AllValidNotes_DoNotThrow(params string[] noteNames)
    {
        // Act & Assert
        foreach (var noteName in noteNames)
        {
            var exception = Record.Exception(() => new Note(noteName));
            Assert.Null(exception);
        }
    }

    [Fact]
    public void Transpose_UpOneSemitone_ReturnsCorrectNote()
    {
        // Arrange
        var c = new Note("C");

        // Act
        var cSharp = c.Transpose(1);

        // Assert
        Assert.Equal("C#", cSharp.Name);
        Assert.Equal(1, cSharp.SemitoneIndex);
    }

    [Fact]
    public void Transpose_UpMajorThird_ReturnsCorrectNote()
    {
        // Arrange
        var c = new Note("C");

        // Act
        var e = c.Transpose(4);

        // Assert
        Assert.Equal("E", e.Name);
        Assert.Equal(4, e.SemitoneIndex);
    }

    [Fact]
    public void Transpose_UpOctave_ReturnsRootNote()
    {
        // Arrange
        var c = new Note("C");

        // Act
        var cOctave = c.Transpose(12);

        // Assert
        Assert.Equal("C", cOctave.Name);
        Assert.Equal(0, cOctave.SemitoneIndex);
    }

    [Fact]
    public void Transpose_WrapAround_ReturnsCorrectNote()
    {
        // Arrange
        var a = new Note("A");

        // Act
        var c = a.Transpose(3); // A + 3 semitones = C

        // Assert
        Assert.Equal("C", c.Name);
        Assert.Equal(0, c.SemitoneIndex);
    }

    [Fact]
    public void Transpose_LargeInterval_ReturnsCorrectNote()
    {
        // Arrange
        var c = new Note("C");

        // Act
        var e = c.Transpose(16); // C + 16 semitones = E (1 octave + major third)

        // Assert
        Assert.Equal("E", e.Name);
        Assert.Equal(4, e.SemitoneIndex);
    }

    [Fact]
    public void ToString_ReturnsNoteName()
    {
        // Arrange
        var note = new Note("F#");

        // Act
        var result = note.ToString();

        // Assert
        Assert.Equal("F#", result);
    }

    [Fact]
    public void GetAllNoteNames_ReturnsAllValidNotes()
    {
        // Act
        var allNotes = Note.GetAllNoteNames();

        // Assert
        Assert.NotEmpty(allNotes);
        Assert.Contains("C", allNotes);
        Assert.Contains("C#", allNotes);
        Assert.Contains("Bb", allNotes);
        Assert.Contains("Db", allNotes);
        Assert.Equal(17, allNotes.Length); // 12 chromatic + 5 enharmonic equivalents
    }

    [Fact]
    public void EnharmonicEquivalents_AreNormalized()
    {
        // Arrange & Act
        var db = new Note("Db");
        var cSharp = new Note("C#");

        // Assert
        Assert.Equal(cSharp.Name, db.Name);
        Assert.Equal(cSharp.SemitoneIndex, db.SemitoneIndex);
    }

    [Theory]
    [InlineData("C", 0)]
    [InlineData("C#", 1)]
    [InlineData("D", 2)]
    [InlineData("D#", 3)]
    [InlineData("E", 4)]
    [InlineData("F", 5)]
    [InlineData("F#", 6)]
    [InlineData("G", 7)]
    [InlineData("G#", 8)]
    [InlineData("A", 9)]
    [InlineData("A#", 10)]
    [InlineData("B", 11)]
    public void Constructor_ChromaticNotes_HaveCorrectSemitoneIndex(string noteName, int expectedIndex)
    {
        // Act
        var note = new Note(noteName);

        // Assert
        Assert.Equal(expectedIndex, note.SemitoneIndex);
    }
}
