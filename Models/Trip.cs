﻿namespace DummyAPI.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
