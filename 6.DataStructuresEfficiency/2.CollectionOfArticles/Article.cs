using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfProducts
{
    public class Article
    {
        public string Barcode { get; private set; }
        public string Vendor { get; private set; }
        public string Title { get; private set; }
        public double Price { get; private set; }
        
        public Article(string barcode, string vendor, string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0}, by: {1}, code: {2}, price: {3} ",
                this.Title, this.Vendor, this.Barcode, this.Price);
        }
    }
}
