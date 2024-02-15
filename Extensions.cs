using Play.Catalog.Entities;
using Play.Catalog.Dtos;

namespace Play.Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);

        }
    }
}
