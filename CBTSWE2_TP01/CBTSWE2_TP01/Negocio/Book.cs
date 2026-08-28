/*
 * Integrantes:
 * 
 * Luiz Gustavo Verissimo Monteiro - CB3030326
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTSWE2_TP01.Negocio
{
    internal class Book
    {
        private int id;
        private string name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public Book(int id, string name, Author[] authors, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Authors = authors;
            this.Price = price;
        }
        public Book(int id, string name, Author[] authors, double price, int qty)
        {
            this.Id = id;
            this.Name = name;
            this.Authors = authors;
            this.Price = price;
            this.Qty = qty;
        }
        public Book(string name, Author[] authors, double price)
        {
            this.Name = name;
            this.Authors = authors;
            this.Price = price;
        }
        public Book(string name, Author[] authors, double price, int qty)
        {
            this.Name = name;
            this.Authors = authors;
            this.Price = price;
            this.Qty = qty;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }
        internal Author[] Authors { get => authors; set => authors = value; }

        public int getId() { return id; }
        public int setId(int id) { this.id = id; return id; }
        public string getName() { return name; }
        public Author[] getAuthors() { return authors; }
        public double getPrice() { return price; }
        public void setPrice(double price) { this.price = price; }
        public int getQty() { return qty; }
        public void setQty(int qty) { this.qty = qty; }
        public override string ToString()
        {
            StringBuilder authorNamesBuilder = new StringBuilder();

            foreach (Author author in authors)
            {
                authorNamesBuilder.Append(author.ToString());
                authorNamesBuilder.Append(", ");
            }

            if (authorNamesBuilder.Length > 0)
            {
                authorNamesBuilder.Length -= 2;
            }

            return $"Book [id={Id}, name={Name}, authors={{{authorNamesBuilder}}}, price={Price}, qty={Qty}]";
        }
        public string GetAuthorNames()
        {
            string authorNames = "";
            foreach (Author author in authors)
            {
                authorNames += author.Name + ", ";
            }
            return authorNames.TrimEnd(',', ' ');
        }
    }
}
