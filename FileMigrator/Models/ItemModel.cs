using FileMigrator.Enums;

namespace FileMigrator.Models
{
    public class ItemModel
    {
        public string ItemName { get; set; }
        public ItemTypesEnum ItemType { get; set; }
        public string ItemDescription { get; set; }
        public bool IsAvailable { get; set; }


        public override string ToString()
        {
            return $"{ItemName} {ItemType} {ItemDescription} {IsAvailable}";
        }
    }
}
