// Задача 1
alert(`Task 1`);
function compareNumbers(num1, num2) {
	if (num1 < num2) {
		return -1;
	} else if (num1 > num2) {
		return 1;
	} else {
		return 0;
	}
}

let task11 = compareNumbers(1, 2);
let task12 = compareNumbers(2, 1);
let task13 = compareNumbers(1, 1);

alert(task11);
alert(task12);
alert(task13);

// Задача 2
alert(`Task 2`);
function factorial(n) {
	if (n === 0 || n === 1) {
		return 1;
	} else {
		return n * factorial(n - 1);
	}
}

let task2 = factorial(5);

alert(`Факториал заданного числа: ${task2}`);

// Задача 3
alert(`Task 3`);
let digit1 = prompt(`Input 1st digit: `);
let digit2 = prompt(`Input 2nd digit: `);
let digit3 = prompt(`Input 3rd digit: `);

function combineDigits(digit1, digit2, digit3) {
	return Number(`${digit1}${digit2}${digit3}`);
}

let combineResult = combineDigits(digit1, digit2, digit3);
alert(`Result of combining digits: ${combineResult}`);

// Задача 4
alert(`Task 4`);
function calculateArea(length, width) {
	if (width === undefined || width === '' || isNaN(width)) {
		width = length;
	}
	return length * width;
}

let lengthInput = prompt(`Input length: `);
let widthInput = prompt(`Input width (Leave empty if calculating rectangle): `);

alert(widthInput);

if (isNaN(lengthInput)) {
	alert(`Invalid input of length`);
} else {
	let area = calculateArea(lengthInput, widthInput);
	alert(`Area is ${area}`);
}

// Задача 5
alert(`Task 5`);
let perfectInput = prompt(`Input number: `);

function isPerfectNumber(number) {
	let sum = 0;
	for (let i = 1; i < number; i++) {
		if (number % i === 0) {
			sum += i;
		}
	}
	return sum === number;
}

let perfectResult = isPerfectNumber(perfectInput);

alert(`is Perfect number? ${perfectResult}`);

// Задача 6
alert(`Task 6`);
let minInput = prompt(`Min input: `);
let maxInput = prompt(`Max input: `);

function printPerfectNumbers(min, max) {
	for (let i = min; i <= max; i++) {
		if (isPerfectNumber(i)) {
			console.log(i);
		}
	}
}

let smthRes = printPerfectNumbers(minInput, maxInput);

// Задача 7
alert(`Task 7`);
function formatTime(hours, minutes, seconds) {
	let formattedHours = hours < 10 ? `0${hours}` : hours;
	let formattedMinutes = minutes < 10 ? `0${minutes}` : minutes;
	let formattedSeconds = seconds < 10 ? `0${seconds}` : seconds;
	return `${formattedHours}:${formattedMinutes}:${formattedSeconds}`;
}

let hoursInput = prompt("Введите часы");
let minutesInput = prompt("Введите минуты (если оставить пустым, будет выведено 00)");
let secondsInput = prompt("Введите секунды (если оставить пустым, будет выведено 00)");

let hours = parseInt(hoursInput);
let minutes = parseInt(minutesInput);
let seconds = parseInt(secondsInput);

if (isNaN(hours)) {
	alert("Некорректное значение для часов");
} else {
	let formattedTime = formatTime(hours, minutes || 0, seconds || 0);
	alert(`Время: ${formattedTime}`);
}

// Задача 8
alert(`Task 8`);
function timeToSeconds(hours, minutes, seconds) {
	return hours * 3600 + minutes * 60 + seconds;
}

let timeToSecondsRes = timeToSeconds(hours, minutes || 0, seconds || 0);
alert(`Time in Seconds: ${timeToSecondsRes}`);

// Задача 9
alert(`Task 9`);
let secondsIn = prompt(`Input seconds: `);
let secondsInt = parseInt(secondsIn);

function secondsToTime(seconds) {
	const hours = Math.floor(seconds / 3600);
	const minutes = Math.floor((seconds % 3600) / 60);
	const remainingSeconds = seconds % 60;
	return formatTime(hours, minutes, remainingSeconds);
}

let secRes = secondsToTime(secondsInt);

alert(`Seconds to Time: ${secRes}`);

// Задача 10
alert(`Task 10`);
function timeDifference(hours1, minutes1, seconds1, hours2, minutes2, seconds2) {
	const time1 = timeToSeconds(hours1, minutes1, seconds1);
	const time2 = timeToSeconds(hours2, minutes2, seconds2);
	const difference = Math.abs(time1 - time2);
	return secondsToTime(difference);
}

let hours1Input = prompt("Enter the hours of the first time");
let minutes1Input = prompt("Enter the minutes of the first time");
let seconds1Input = prompt("Enter the seconds of the first time");
let hours2Input = prompt("Enter the hours of the second time");
let minutes2Input = prompt("Enter the minutes of the second time");
let seconds2Input = prompt("Enter the seconds of the second time");

let hours1 = parseInt(hours1Input);
let minutes1 = parseInt(minutes1Input);
let seconds1 = parseInt(seconds1Input);
let hours2 = parseInt(hours2Input);
let minutes2 = parseInt(minutes2Input);
let seconds2 = parseInt(seconds2Input);

if (isNaN(hours1) || isNaN(minutes1) || isNaN(seconds1) || isNaN(hours2) || isNaN(minutes2) || isNaN(seconds2)) {
	alert("Invalid input. Please enter valid integer numbers for the times.");
} else {
	let difference = timeDifference(hours1, minutes1, seconds1, hours2, minutes2, seconds2);
	alert(`The difference between the times is: ${difference}`);
}