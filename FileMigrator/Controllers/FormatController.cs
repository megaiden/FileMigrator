namespace FileMigrator.Controllers
{
    public static class FormatController
    {
        private static string? selectedFormat;

        public static string GetSelectedFormat()
        {
            if (selectedFormat == string.Empty || selectedFormat is null)
            {
                SetSelectedFormat(","); // select by default ',' as the format if selected format is empty
                return selectedFormat;
            }
            return selectedFormat;
        }

        public static void SetSelectedFormat(string value)
        {
            selectedFormat = value;
        }

        public static void ChangeFormat()
        {
            Console.Clear();
            var predefinedFormats = new List<string>
            {
                ",",
                ";",
                "/",
                "|"
            };

            List<string> formatOptions = predefinedFormats.Select((format, index) => $"{index + 1}. Format {index + 1}: '{format}'").ToList();

            Console.WriteLine("Select a predefined format:");
            foreach (string option in formatOptions)
            {
                Console.WriteLine(option);
            }

            int selectedFormatIndex = SelectOption("Enter the index of the format: ", formatOptions.Count);
            SetSelectedFormat(predefinedFormats[selectedFormatIndex - 1]);
        }
        private static int SelectOption(string prompt, int maxIndex)
        {
            var selectedIndex = 0;

            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 1 && selectedIndex <= maxIndex)
            {
                return selectedIndex;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxIndex}.");
                return SelectOption(prompt, maxIndex);
            }
            
        }
    }
}
