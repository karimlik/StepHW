const searchInput = document.querySelector('#search-input');
const searchBtn = document.querySelector('#search-btn');
const burgerMenu = document.querySelector('.burger-menu i');
const navSlider = document.querySelector('.nav-slider');
const menuIcon = document.getElementById("burger-ico");

let searchToggler = false;
let menuToggler = false;


function slide() {
    if (!searchToggler) {
        searchInput.style.left = '-100%';
        searchToggler = true;
        searchInput.style.zIndex = '1';
    } else {
        searchInput.style.left = '0';
        searchToggler = false;
    }
    return searchToggler;
}

burgerMenu.addEventListener('click', () => {


    if (!menuToggler) {
        burgerMenu.style.rotate = '90deg';
        navSlider.style = ` top: 150px;position: absolute;display: flex;`
        navSlider.querySelector('.nav-slider-inner').style = `display: flex;flex-direction: row;flex-wrap: wrap;`
        menuToggler = true;
        menuIcon.classList.remove("fa-bars");
        menuIcon.classList.add("fa-xmark");
    } else {
        burgerMenu.style.rotate = '0deg';
        navSlider.style = ` top: 0px;position: absolute;display: none;`
        navSlider.querySelector('.nav-slider-inner').style = `display: none;`
        menuToggler = false;

        menuIcon.classList.add("fa-bars");
        menuIcon.classList.remove("fa-xmark");
    }
    burgerMenu.style.opacity = '1';
});

searchBtn.addEventListener('click', () => {
    let res = slide();
});







