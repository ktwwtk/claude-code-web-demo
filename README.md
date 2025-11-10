# Musical Scale Explorer

A .NET console application designed to help musicians explore musical scales and understand their composition.

## Features

- **Root Note Selection**: Choose from all 12 chromatic notes (including enharmonic equivalents)
- **Multiple Scale Types**: Support for major, minor, pentatonic, blues, and modal scales
- **Interactive Interface**: User-friendly command-line interface
- **Scale Degree Information**: Shows both the notes and their positions in the scale

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
dotnet run
```

## Project Structure

- `Program.cs` - Main entry point and user interface
- `Note.cs` - Musical note representation and chromatic scale logic
- `Scale.cs` - Scale definitions with interval patterns
- `MusicianScaleApp.csproj` - .NET project configuration

## How It Works

The application uses interval patterns (in semitones) to generate scales:
- **Major scale**: 2-2-1-2-2-2-1 (W-W-H-W-W-W-H)
- **Natural minor**: 2-1-2-2-1-2-2 (W-H-W-W-H-W-W)
- **Pentatonic major**: 2-2-3-2-3
- And more...

Where W = Whole step (2 semitones) and H = Half step (1 semitone)

## Example Usage

```
Enter the root note: C
Enter the scale name: major

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
