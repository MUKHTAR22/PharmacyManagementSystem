using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyonu
{
    public class CartItem
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Keep using Price
        public decimal TotalPrice => Quantity * Price; // Calculate the total price
    }
}
