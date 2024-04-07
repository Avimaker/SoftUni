using System;
using System.Xml.Linq;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Models
{
    public class User : IUser
    {

        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;//to put in ctor? 
        private bool isBlocked;//to put in ctor?

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            Rating = 0;
            IsBlocked = false;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName cannot be null or whitespace!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LastName cannot be null or whitespace!");
                }
                lastName = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Driving license number is required!");
                }
                drivingLicenseNumber = value;
            }
        }

        public double Rating
        {
            get { return this.rating; }
            private set { this.rating = value; }
        }

        public bool IsBlocked
        {
            get { return this.isBlocked; }
            private set { this.isBlocked = value; }
        }

        public void IncreaseRating()
        {
            rating += 0.5;
            if (rating > 10)
            {
                rating = 10;
            }
        }

        public void DecreaseRating()
        {
            rating -= 2.0;
            if (rating < 0)
            {
                rating = 0;
                IsBlocked = true;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {drivingLicenseNumber} Rating: {rating}";
        }
    }
}

