using FileMigrator.Models;
namespace FileMigrator.Controllers
{
    public class ItemsController
    {
        public static void SearchByItemName(List<ItemModel> items)
        {
            Console.Clear();
            Console.WriteLine("Type the name to search.");
            var nameToSearch = Console.ReadLine();

            var filteredItemsList = items.Where(p => p.ItemName.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine($"\nItems found with name: '{nameToSearch}':");
            if (filteredItemsList.Any())
            {
                foreach (var item in filteredItemsList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No items found with that name.");
            }

            Console.ReadLine();
        }
    }
}
