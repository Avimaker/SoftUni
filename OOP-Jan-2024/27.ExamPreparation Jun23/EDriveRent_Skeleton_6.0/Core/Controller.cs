using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            //търсим в списъка с настоящи
            IUser user = users.FindById(drivingLicenseNumber);
            //създаваме нов юзър който да проверим и да добавим 
            User newUser = new User(firstName, lastName, drivingLicenseNumber);

            if (user != null)// ако метода не върне null значи има такъв и показваме грешка
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }

            users.AddModel(newUser);

            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != nameof(PassengerCar) && vehicleType != nameof(CargoVan))
            {
                return $"{vehicleType} is not accessible in our platform.";
            }

            IVehicle existVehicle = vehicles.FindById(licensePlateNumber);

            if (existVehicle != null) //проверката трябва да е така
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            IVehicle newVehicle = null;

            if (vehicleType == nameof(PassengerCar))
            {
                newVehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else
            {
                newVehicle = new CargoVan(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(newVehicle);

            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }


        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int routeId = routes.GetAll().Count + 1;

            IRoute existingRoutes = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

            if (existingRoutes != null)//ако има път влизаме
            {
                if (existingRoutes.Length == length)//ако има с търсената дължина
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
                else if (existingRoutes.Length < length)//ако има с по-къса дължина
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint, length);
                }
                else if (existingRoutes.Length > length)//ако има с по-голяма дължина
                {
                    existingRoutes.LockRoute();
                }
            }

            IRoute newRoute = new Route(startPoint, endPoint, length, routeId);

            routes.AddModel(newRoute);

            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }



        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            //MakeTrip CDYHVSR68661 5UNM315  3   false
            //          driver      car     RID   accident

            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if (user.IsBlocked)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }
            if (vehicle.IsDamaged)
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }
            if (route.IsLocked)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }

            vehicle.Drive(route.Length);
            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }



        public string RepairVehicles(int count)
        {
            IEnumerable<IVehicle> damagedVehicles = vehicles.GetAll().Where(d => d.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model);


            int repairCount = 0;

            if (damagedVehicles.Count() < count)
            {
                repairCount = damagedVehicles.Count();
            }
            else
            {
                repairCount = count;
            }

            var selectedVehicles = damagedVehicles.ToArray().Take(repairCount);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return $"{repairCount} vehicles are successfully repaired!";
        }



        public string UsersReport()
        {
            IEnumerable<IUser> filteredUsers = users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in filteredUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();

        }
    }
}

