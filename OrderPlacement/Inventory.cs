using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPlacement
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable(int quant)
        {
             return Quantity >= quant; 
        }
    }
}
