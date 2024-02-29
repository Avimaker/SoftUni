using System;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IId
    {
        private string model;

        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}

