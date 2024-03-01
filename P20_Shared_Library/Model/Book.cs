using System;

namespace P20_Shared_Library.Model
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Author { get; set; } 
        public int Year { get; set; } 
        public string Publisher { get; set; } 
        public string Genre { get; set; } 
        public string Description { get; set; } 

  
        public bool IsAvailable { get; set; } 
        public DateTime DueDate { get; set; } 
        public string Borrower { get; set; } 
    }

}
