using System;
namespace Vehicles.Models.Interface;

public interface IDrive
{
    public string Drive(double distance);

    public string DriveEmpty(double distance);
}

