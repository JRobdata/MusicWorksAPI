
using MusicWorksAPI.Models;
using MusicWorksAPI.Data;

namespace MusicWorksAPI.Data
{
    public class SeedData
    {
        public static readonly Category[] SeedCategories =
        [
                    new Category { Name = "Solo" },
                    new Category { Name = "Chamber" },
                    new Category { Name = "Orchestral" },
                    new Category { Name = "Choral" }

        ];



        public static readonly Work[] SeedWorks =
        [
            new Work
            {
                Title = "2 Little Inventions",
                CategoryId = 1,
                Instrumentation = "Piano",
                Price = 5.99m,
                PublicationYear = 2013
            },
            new Work
            {
                Title = "5 Early Pieces",
                CategoryId = 1,
                Instrumentation = "Piano",
                Price = 11.99m,
                PublicationYear = 2015
            },
            new Work
            {
                Title = "Through the Glen",
                CategoryId = 2,
                Instrumentation = "Piano, and 2 Violins",
                Price = 7.99m,
                PublicationYear = 2016
            },
                  new Work
            {
                Title = "Nocturnal Suite",
                CategoryId = 2,
                Instrumentation = "Piano, and violin",
                Price = 11.99m,
                PublicationYear = 2017
            },
            new Work
            {
                Title = "Feast of St. Columba",
                CategoryId = 4,
                Instrumentation = "Choir and 5 instrument ensemble",
                Price = 14.99m,
                PublicationYear = 2018
            },
                  
                        new Work
            {
                Title = "Traveller's Sketch",
                CategoryId = 1,
                Instrumentation = "Piano",
                Price = 8.99m,
                PublicationYear = 2021
            },
                        new Work
            {
                Title = "Sonatina",
                CategoryId = 1,
                Instrumentation = "Piano",
                Price = 9.99m,
                PublicationYear = 2026
            },
        ];


    }
}
