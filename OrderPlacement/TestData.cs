using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPlacement
{
    public static class TestData
    {
        public static IList<Product> GetProducts()
        {
            var availableProducts = new List<Product>();
            var knife = new Product
            {
                Id = 1,
                Name = "Knife",
                Cost = 2.5m
            };
            availableProducts.Add(knife);

            var tv = new Product
            {
                Id = 2,
                Name = "Tv",
                Cost = 150.0m
            };
            availableProducts.Add(tv);

            var bottle = new Product
            {
                Id = 3,
                Name = "bottle",
                Cost = 5.5m
            };
            availableProducts.Add(bottle);

            var screw = new Product
            {
                Id = 4,
                Name = "screw",
                Cost = 6.5m
            };
            availableProducts.Add(screw);
            return availableProducts;
        }
        public static IList<Inventory> GetInventory()
        {
            var availableInventory = new List<Inventory>();
            var knifeInventory = new Inventory
            {
                ProductId = 1,
                Quantity = 11
            };
            availableInventory.Add(knifeInventory);

            var tvInventory = new Inventory
            {
                ProductId = 2,
                Quantity = 5
            };
            availableInventory.Add(tvInventory);

            var bottleInventory = new Inventory
            {
                ProductId = 3,
                Quantity = 6
            };
            availableInventory.Add(bottleInventory);

            var screwInventory = new Inventory
            {
                ProductId = 4,
                Quantity = 0
            };
            availableInventory.Add(screwInventory);
            return availableInventory;
        }
    }
}
