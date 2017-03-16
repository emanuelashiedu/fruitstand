using System;


namespace FruitStand.Data.Models
{
    public class FruitStandModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string FruitType { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Price { get; set; }
    }

    public class Key
    {
        public int Id { get; set; }
    }
}
