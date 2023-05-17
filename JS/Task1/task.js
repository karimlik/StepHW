// Задача 1
let name = prompt("Введите свое имя");
alert(`Привет, ${name}!`);

// Задача 2
const currentYear = 2023;
let yearOfBirth = prompt("Введите год своего рождения");
let age = currentYear - yearOfBirth;
alert(`Вам ${age} лет`);

// Задача 3
let squareSide = prompt("Введите длину стороны квадрата");
let perimeter = squareSide * 4;
alert(`Периметр квадрата равен ${perimeter}`);

// Задача 4
let radius = prompt("Введите радиус окружности");
let area = Math.PI * radius ** 2;
alert(`Площадь окружности равна ${area}`);

// Задача 5
let distance = prompt("Введите расстояние между городами в км");
let time = prompt("За сколько часов вы хотите добраться?");
let speed = distance / time;
alert(`Необходимо двигаться со скоростью ${speed} км/ч`);

// Задача 6
const exchangeRate = 0.85;
let dollars = prompt("Введите количество долларов");
let euros = dollars * exchangeRate;
alert(`Вы получите ${euros} евро`);

// Задача 7
let flashDriveCapacity = prompt("Введите объем флешки в Гб");
let filesCount = Math.floor(flashDriveCapacity * 1024 / 820);
alert(`На флешку поместится ${filesCount} файлов`);

// Задача 8
let walletAmount = prompt("Введите сумму денег в кошельке");
let chocolatePrice = prompt("Введите цену одной шоколадки");
let chocolatesCount = Math.floor(walletAmount / chocolatePrice);
let change = walletAmount % chocolatePrice;
alert(`Вы можете купить ${chocolatesCount} шоколадок, и у вас останется ${change} денег`);

// Задача 9
let number = prompt("Введите трехзначное число");
let reversedNumber = (number % 10) * 100 + Math.floor(number / 10) % 10 * 10 + Math.floor(number / 100);
alert(`Число задом наперед: ${reversedNumber}`);

// Задача 10
let userNumber = prompt("Введите целое число");
let isEven = userNumber % 2 === 0;
alert(`Введенное число ${isEven ? "четное" : "нечетное"}`);
