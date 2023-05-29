const usernameInput = document.getElementById('username');
const errorMessage = document.getElementById('errorMessage');

usernameInput.addEventListener('input', () => {
  const inputText = usernameInput.value;
  let filteredText = '';

  for (let i = 0; i < inputText.length; i++) {
    if (isNaN(inputText[i])) {
      filteredText += inputText[i];
    }
  }

  usernameInput.value = filteredText;
});

usernameInput.addEventListener('blur', () => {
  const inputText = usernameInput.value;
  
  if (inputText.trim().length === 0) {
    errorMessage.textContent = 'Username cannot be empty.';
  } else {
    errorMessage.textContent = '';
  }
});
