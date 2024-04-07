using System;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double lenght;
        private bool isLocked = false;//ctr? работи и така

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
        }

        public string StartPoint
        {
            get => startPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("StartPoint cannot be null or whitespace!");
                }
                startPoint = value;
            }
        }

        public string EndPoint
        {
            get => endPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("EndPoint cannot be null or whitespace!");
                }
                endPoint = value;
            }
        }

        public double Length
        {
            get { return this.lenght; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Length cannot be less than 1 kilometer.");
                }
                this.lenght = value;
            }
        }

        public int RouteId { get; set; }

        public bool IsLocked
        {
            get { return this.isLocked; }
            private set { this.isLocked = value; }
        }

        public void LockRoute()
        {
            IsLocked = true;
        }
    }
}

