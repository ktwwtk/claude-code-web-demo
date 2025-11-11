namespace MusicianScaleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   Musical Scale Explorer               ║");
        Console.WriteLine("║   For Musicians                        ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();

        while (true)
        {
            try
            {
                // Get root note from user
                Note? rootNote = GetRootNoteFromUser();
                if (rootNote == null)
                {
                    break; // User wants to exit
                }

                // Get scale from user
                Scale? scale = GetScaleFromUser();
                if (scale == null)
                {
                    break; // User wants to exit
                }

                // Generate and display the scale
                DisplayScale(rootNote, scale);

                Console.WriteLine();
                Console.Write("Would you like to explore another scale? (y/n): ");
                string? response = Console.ReadLine()?.ToLower().Trim();

                if (response != "y" && response != "yes")
                {
                    break;
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using Musical Scale Explorer!");
    }

    static Note? GetRootNoteFromUser()
    {
        Console.WriteLine("Available notes:");
        var noteNames = Note.GetAllNoteNames();

        // Display notes with numbers in columns
        int columnWidth = 15;
        int columns = 4;
        for (int i = 0; i < noteNames.Length; i++)
        {
            string display = $"{i + 1}. {noteNames[i]}";
            Console.Write($"  {display.PadRight(columnWidth)}");
            if ((i + 1) % columns == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Enter note number or name (or 'exit' to quit): ");

        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
        {
            return null;
        }

        // Try to parse as number first
        if (int.TryParse(input, out int noteNumber) && noteNumber >= 1 && noteNumber <= noteNames.Length)
        {
            return new Note(noteNames[noteNumber - 1]);
        }

        // Otherwise try as note name
        try
        {
            return new Note(input);
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"Invalid note: {input}. Please try again.");
            Console.WriteLine();
            return GetRootNoteFromUser();
        }
    }

    static Scale? GetScaleFromUser()
    {
        Console.WriteLine();
        Console.WriteLine("Available scales:");
        var scaleNames = Scale.GetAllScaleNames();

        // Display scales with numbers in columns
        int columnWidth = 25;
        int columns = 2;
        for (int i = 0; i < scaleNames.Length; i++)
        {
            string display = $"{i + 1}. {scaleNames[i]}";
            Console.Write($"  {display.PadRight(columnWidth)}");
            if ((i + 1) % columns == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Enter scale number or name (or 'exit' to quit): ");

        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
        {
            return null;
        }

        // Try to parse as number first
        if (int.TryParse(input, out int scaleNumber) && scaleNumber >= 1 && scaleNumber <= scaleNames.Length)
        {
            return new Scale(scaleNames[scaleNumber - 1]);
        }

        // Otherwise try as scale name
        try
        {
            return new Scale(input);
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"Invalid scale: {input}. Please try again.");
            Console.WriteLine();
            return GetScaleFromUser();
        }
    }

    static void DisplayScale(Note rootNote, Scale scale)
    {
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine($"  {rootNote} {scale.Name} Scale");
        Console.WriteLine("═══════════════════════════════════════");

        var notes = scale.GenerateNotes(rootNote);

        Console.WriteLine();
        Console.WriteLine("Notes in scale:");
        Console.Write("  ");
        for (int i = 0; i < notes.Count; i++)
        {
            Console.Write(notes[i]);
            if (i < notes.Count - 1)
            {
                Console.Write(" - ");
            }
        }
        Console.WriteLine();

        // Display with degree numbers
        Console.WriteLine();
        Console.WriteLine("Scale degrees:");
        for (int i = 0; i < notes.Count; i++)
        {
            string degree = i switch
            {
                0 => "Root (1st)",
                1 => "2nd",
                2 => "3rd",
                3 => "4th",
                4 => "5th",
                5 => "6th",
                6 => "7th",
                7 => "Octave (8th)",
                _ => $"{i + 1}th"
            };
            Console.WriteLine($"  {degree.PadRight(15)} - {notes[i]}");
        }
        Console.WriteLine("═══════════════════════════════════════");
    }
}
