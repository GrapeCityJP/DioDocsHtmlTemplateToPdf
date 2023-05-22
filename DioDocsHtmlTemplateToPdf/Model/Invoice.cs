using System;

namespace DioDocsHtmlTemplateToPdf.Model
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }

        public decimal SubTotal
        {
            get
            {
                return Items.Sum(x => x.TotalPrice);
            }
        }

        public float Tax
        {
            get
            {
                return (float)SubTotal * 0.1f;
            }
        }

        public float GrandTotal
        {
            get
            {
                return (float)SubTotal + Tax;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProjectName { get; set; }
    }
}
