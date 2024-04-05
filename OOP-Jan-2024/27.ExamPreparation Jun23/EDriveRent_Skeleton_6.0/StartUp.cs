﻿namespace EDriveRent
{
    using EDriveRent.Core;
    using EDriveRent.Core.Contracts;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}


/*
RegisterUser Tisha Reenie 7246506
RegisterUser Bernard Remy CDYHVSR68661
RegisterUser Mack Cindi 7246506
UploadVehicle PassengerCar Chevrolet Volt CWP8032
UploadVehicle PassengerCar Volkswagen e-Up! COUN199728
UploadVehicle PassengerCar Mercedes-Benz EQS 5UNM315
UploadVehicle CargoVan Ford e-Transit 726QOA
UploadVehicle CargoVan BrightDrop Zevo400 SC39690
UploadVehicle EcoTruck Mercedes-Benz eActros SC39690
UploadVehicle PassengerCar Tesla CyberTruck 726QOA
AllowRoute SOF PLD 144
AllowRoute BUR VAR 87
AllowRoute BUR VAR 87
AllowRoute SOF PLD 184
AllowRoute BUR VAR 86.999
MakeTrip CDYHVSR68661 5UNM315 3 false
MakeTrip 7246506 CWP8032 1 true
MakeTrip 7246506 COUN199728 1 false
MakeTrip CDYHVSR68661 CWP8032 3 false
MakeTrip CDYHVSR68661 5UNM315 2 false
RepairVehicles 2
UsersReport
 
 */