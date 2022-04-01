using System;
using System.Collections.Generic;
using System.Text;

namespace BookMenuTask.Modals
{
    internal class Book : Product
    {
        public string genre;


        public void ShowInfo()
        {
            Console.WriteLine($" no : {no}\n name : {name}\n price : {price}\n count : {count}\n genre : {genre}");
        }
        public Book(int no, string name, double price, int count,string genre) : base(no, name, price, count)
        {
            this.genre = genre;
        }
    }
}
