# Musical Scale Explorer

A .NET console application designed to help musicians explore musical scales and understand their composition.

## Features

- **Root Note Selection**: Choose from all 12 chromatic notes (including enharmonic equivalents)
- **Numbered Menu System**: Select notes and scales by entering a number or typing the full name
- **Multiple Scale Types**: Support for major, minor, pentatonic, blues, and modal scales
- **Interactive Interface**: User-friendly command-line interface
- **Scale Degree Information**: Shows both the notes and their positions in the scale
- **Comprehensive Unit Tests**: Full test coverage for music theory logic

## Supported Scales

- Major
- Natural Minor
- Harmonic Minor
- Melodic Minor
- Pentatonic Major
- Pentatonic Minor
- Blues
- Dorian
- Phrygian
- Lydian
- Mixolydian
- Locrian

## Supported Notes

- All chromatic notes: C, C#, D, D#, E, F, F#, G, G#, A, A#, B
- Enharmonic equivalents: Db, Eb, Gb, Ab, Bb

## How to Run

If you have .NET SDK installed:

```bash
# Run the application
dotnet run

# Run unit tests
dotnet test
```

## Project Structure

- `Program.cs` - Main entry point and user interface with numbered menus
- `Note.cs` - Musical note representation and chromatic scale logic
- `Scale.cs` - Scale definitions with interval patterns
- `MusicianScaleApp.csproj` - .NET project configuration
- `MusicianScaleApp.Tests/` - Unit tests for Note and Scale classes
  - `NoteTests.cs` - Comprehensive tests for Note class
  - `ScaleTests.cs` - Comprehensive tests for Scale class

## How It Works

The application uses interval patterns (in semitones) to generate scales:
- **Major scale**: 2-2-1-2-2-2-1 (W-W-H-W-W-W-H)
- **Natural minor**: 2-1-2-2-1-2-2 (W-H-W-W-H-W-W)
- **Pentatonic major**: 2-2-3-2-3
- And more...

Where W = Whole step (2 semitones) and H = Half step (1 semitone)

## Example Usage

```
Available notes:
  1. C            2. C#           3. D            4. D#
  5. E            6. F            7. F#           8. G
  9. G#           10. A           11. A#          12. B
  13. Db          14. Eb          15. Gb          16. Ab
  17. Bb

Enter note number or name (or 'exit' to quit): 1

Available scales:
  1. major                    2. minor
  3. natural minor            4. harmonic minor
  5. melodic minor            6. pentatonic major
  7. pentatonic minor         8. blues
  9. dorian                   10. phrygian
  11. lydian                  12. mixolydian
  13. locrian

Enter scale number or name (or 'exit' to quit): 1

═══════════════════════════════════════
  C major Scale
═══════════════════════════════════════

Notes in scale:
  C - D - E - F - G - A - B - C

Scale degrees:
  Root (1st)      - C
  2nd             - D
  3rd             - E
  4th             - F
  5th             - G
  6th             - A
  7th             - B
  Octave (8th)    - C
═══════════════════════════════════════
```

## Requirements

- .NET 8.0 or later

## License

Open source - feel free to use and modify for your musical needs!
