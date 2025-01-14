class Vehicle {
    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts = {
            engine: parts.engine,
            power: parts.power,
            quality: parts.engine * parts.power // quality is calculated as engine * power
        };
        this.fuel = fuel;
    }

    drive(fuelLoss) {
        this.fuel -= fuelLoss; // Reduces fuel by the specified amount
    }
}


// Example 1:
let parts1 = { engine: 6, power: 100 };
let vehicle1 = new Vehicle('a', 'b', parts1, 200);
vehicle1.drive(100);
console.log(vehicle1.fuel); // Output: 100
console.log(vehicle1.parts.quality); // Output: 600

// Example 2:
let parts2 = { engine: 9, power: 500 };
let vehicle2 = new Vehicle('l', 'k', parts2, 840);
vehicle2.drive(20);
console.log(vehicle2.fuel); // Output: 820