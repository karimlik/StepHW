// Задача 1
const car = {};

car.manufacturer = prompt("Make:");
car.model = prompt("MOdel:");
car.year = Number(prompt("Production year:"));
car.averageSpeed = Number(prompt("Avg speed:"));

function displayCarInfo(car) {
	const info = `Make: ${car.manufacturer}\nModel: ${car.model}\nYear: ${car.year}\nAvg Speed: ${car.averageSpeed} km/h`;
	alert(info);
}

function calculateTravelTime(car, distance) {
	const travelTime = distance / car.averageSpeed + Math.floor(distance / (4 * car.averageSpeed));
	return travelTime.toFixed(2);
}

displayCarInfo(car);

const distance = Number(prompt("Distance:"));
const travelTime = calculateTravelTime(car, distance);
alert(`Для преодоления расстояния ${distance} км потребуется ${travelTime} часов`);

// Задача 2

function Fraction(numerator, denominator) {
	this.numerator = numerator;
	this.denominator = denominator;
}

Fraction.prototype.add = function(fraction) {
	const resultNumerator = this.numerator * fraction.denominator + fraction.numerator * this.denominator;
	const resultDenominator = this.denominator * fraction.denominator;
	return new Fraction(resultNumerator, resultDenominator);
};

Fraction.prototype.subtract = function(fraction) {
	const resultNumerator = this.numerator * fraction.denominator - fraction.numerator * this.denominator;
	const resultDenominator = this.denominator * fraction.denominator;
	return new Fraction(resultNumerator, resultDenominator);
};

Fraction.prototype.multiply = function(fraction) {
	const resultNumerator = this.numerator * fraction.numerator;
	const resultDenominator = this.denominator * fraction.denominator;
	return new Fraction(resultNumerator, resultDenominator);
};

Fraction.prototype.divide = function(fraction) {
	const resultNumerator = this.numerator * fraction.denominator;
	const resultDenominator = this.denominator * fraction.numerator;
	return new Fraction(resultNumerator, resultDenominator);
};

Fraction.prototype.reduce = function() {
	const gcd = (a, b) => (b === 0 ? a : gcd(b, a % b));
	const divisor = gcd(this.numerator, this.denominator);
	const reducedNumerator = this.numerator / divisor;
	const reducedDenominator = this.denominator / divisor;
	return new Fraction(reducedNumerator, reducedDenominator);
};

const numerator1 = Number(prompt("Numerator 1:"));
const denominator1 = Number(prompt("Denominator 1:"));
const numerator2 = Number(prompt("Numerator 2:"));
const denominator2 = Number(prompt("Denominator 2:"));

const fraction1 = new Fraction(numerator1, denominator1);
const fraction2 = new Fraction(numerator2, denominator2);

const addition = fraction1.add(fraction2);
console.log("Addition:", addition.reduce());

const subtraction = fraction1.subtract(fraction2);
console.log("Subtraction:", subtraction.reduce());

const multiplication = fraction1.multiply(fraction2);
console.log("Multiplication:", multiplication.reduce());

const division = fraction1.divide(fraction2);
console.log("Division:", division.reduce());

// Задача 3

function Time(hours, minutes, seconds) {
	this.hours = hours;
	this.minutes = minutes;
	this.seconds = seconds;
}

Time.prototype.displayTime = function() {
	const formattedHours = this.hours < 10 ? "0" + this.hours : this.hours;
	const formattedMinutes = this.minutes < 10 ? "0" + this.minutes : this.minutes;
	const formattedSeconds = this.seconds < 10 ? "0" + this.seconds : this.seconds;
	const timeString = `${formattedHours}:${formattedMinutes}:${formattedSeconds}`;
	alert(timeString);
};

Time.prototype.addSeconds = function(seconds) {
	const totalSeconds = this.hours * 3600 + this.minutes * 60 + this.seconds + seconds;
	this.hours = Math.floor(totalSeconds / 3600);
	this.minutes = Math.floor((totalSeconds % 3600) / 60);
	this.seconds = totalSeconds % 60;
};

Time.prototype.addMinutes = function(minutes) {
	this.addSeconds(minutes * 60);
};

Time.prototype.addHours = function(hours) {
	this.addSeconds(hours * 3600);
};

const hours = Number(prompt("Hours:"));
const minutes = Number(prompt("Minutes:"));
const seconds = Number(prompt("Seconds:"));

const time = new Time(hours, minutes, seconds);

time.displayTime();

const secondsToAdd = Number(prompt("Seconds to add:"));
time.addSeconds(secondsToAdd);

time.displayTime();

const minutesToAdd = Number(prompt("Minutes to add:"));
time.addMinutes(minutesToAdd);

time.displayTime();

const hoursToAdd = Number(prompt("Hours to add:"));
time.addHours(hoursToAdd);

time.displayTime();

