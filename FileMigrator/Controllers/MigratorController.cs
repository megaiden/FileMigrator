using FileMigrator.Models;

namespace FileMigrator.Controllers
{
    public static class MigratorController
    {
        public static List<ItemModel> MigrateFile(string fileDirectory, string selectedFormat)
        {
            Console.Clear();
            var items = ParseItemsFromFile(fileDirectory, selectedFormat);

            if (items == null || items.Count == 0)
            {

                Console.WriteLine($"No items found to be parsed with format: {selectedFormat}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine("\nAll Items:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i+1} - {items[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return items;

        }

        private static List<ItemModel> ParseItemsFromFile(string fileDirectory, string selectedFormat)
        {
            try
            {
                var items = new List<ItemModel>();
                var lines = File.ReadAllLines(fileDirectory);
                foreach (string line in lines)
                {
                    var parts = line.Split(new string[] { selectedFormat }, StringSplitOptions.None);
                    if (parts.Length == 4)
                    {
                        var item = new ItemModel
                        {
                            ItemName = parts[0].Trim(),
                            ItemType = (Enums.ItemTypesEnum)int.Parse(parts[1]),
                            ItemDescription = parts[2].Trim(),
                            IsAvailable = bool.Parse(parts[3])
                        };
                        items.Add(item);
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing file: {ex.Message}");
                return null;
            }
        }
    }
}
