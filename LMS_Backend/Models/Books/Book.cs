﻿namespace LMS_Backend.Models.Books
{
    public class Book
    {
        public  Guid Id { get; set; }

        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
    }
}