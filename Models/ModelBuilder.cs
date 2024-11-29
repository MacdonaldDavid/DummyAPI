using DummyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DummyAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com" },
                new User { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com" }
            );

            // Seed Trips
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    Destination = "Paris",
                    StartDate = new DateTime(2024, 5, 1),
                    EndDate = new DateTime(2024, 5, 10),
                    UserId = 1 // FK to John Doe
                },
                new Trip
                {
                    Id = 2,
                    Destination = "New York",
                    StartDate = new DateTime(2024, 6, 15),
                    EndDate = new DateTime(2024, 6, 22),
                    UserId = 2 // FK to Jane Smith
                },
                new Trip
                {
                    Id = 3,
                    Destination = "Tokyo",
                    StartDate = new DateTime(2024, 7, 10),
                    EndDate = new DateTime(2024, 7, 20),
                    UserId = 1 // FK to John Doe
                }
            );

            // Seed Activities
            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    Id = 1,
                    Name = "Eiffel Tower Visit",
                    Description = "Visited the iconic Eiffel Tower",
                    TripId = 1 // FK to Paris Trip
                },
                new Activity
                {
                    Id = 2,
                    Name = "Museum Tour",
                    Description = "Tour of the Louvre Museum",
                    TripId = 1 // FK to Paris Trip
                },
                new Activity
                {
                    Id = 3,
                    Name = "Broadway Show",
                    Description = "Watched a Broadway musical",
                    TripId = 2 // FK to New York Trip
                },
                new Activity
                {
                    Id = 4,Name = "Central Park Walk",Description = "Relaxed walk in Central Park",TripId = 2 
                },
                new Activity
                {
                    Id = 5,Name = "Shibuya Crossing",Description = "Visited the famous Shibuya Crossing",TripId = 3 
                },
                new Activity
                {
                    Id = 6,Name = "Senso-ji Temple",Description = "Explored the historical Senso-ji Temple",TripId = 3}
            );
        }
    }
}
