﻿namespace Play.Catalog.Entities
{
    public class Item : IEntity
    {
        public Guid Id { get; set; }


        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;


        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

    }
}
