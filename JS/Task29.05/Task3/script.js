const container = document.getElementById('container');
const ball = document.getElementById('ball');

container.addEventListener('click', (event) => {
  const posX = event.clientX - container.offsetWidth / 2;
  const posY = event.clientY - container.offsetHeight / 2;

  ball.style.transform = `translate(${posX}px, ${posY}px)`;
});
