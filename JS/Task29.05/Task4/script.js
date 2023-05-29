const lights = document.querySelectorAll('.light');
const nextButton = document.getElementById('nextButton');
let currentLightIndex = 0;

nextButton.addEventListener('click', () => {
  // Turn off the current light
  lights[currentLightIndex].classList.remove('active');

  lights[currentLightIndex].classList.remove('inactive');

  // Move to the next light
  currentLightIndex = (currentLightIndex + 1) % lights.length;
  nextLightIndex = (currentLightIndex + 1) % lights.length;

  // Turn on the next light
  lights[currentLightIndex].classList.add('active');

  lights[currentLightIndex].classList.add('inactive');
  lights[nextLightIndex].classList.add('inactive');
});

// Initially turn on the first light
lights[currentLightIndex].classList.add('active');
