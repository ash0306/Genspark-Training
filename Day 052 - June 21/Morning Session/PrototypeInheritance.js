// Constructor function for creating Vehicle objects
function Vehicle(type, model) {
    this.type = type;
    this.model = model;
}

Vehicle.prototype.displayDetails = function() {
    return `Vehicle type is ${this.type} and model is ${this.model}`;
};

function Car(type, model, brand) {
    Vehicle.call(this, type, model);
    this.brand = brand;
}

// Inherit the prototype methods from Vehicle
Car.prototype = Object.create(Vehicle.prototype);

Car.prototype.constructor = Car;

Car.prototype.displayDetails = function() {
    return `${Vehicle.prototype.displayDetails.call(this)}, and brand is ${this.brand}`;
};

Car.prototype.honk = function() {
    return `${this.brand} ${this.model} says beep beep!`;
};

const genericVehicle = new Vehicle('Truck', 'Model X');
const myCar = new Car('Car', 'Model S', 'Tesla');

console.log(genericVehicle.displayDetails());
console.log(myCar.displayDetails());
console.log(myCar.honk());
