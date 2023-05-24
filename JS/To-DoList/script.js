const taskInput = document.getElementById('taskInput');
const taskList = document.getElementById('taskList');

function addTask() {
  const taskText = taskInput.value.trim();
  if (taskText !== '') {
    const taskItem = document.createElement('li');
    taskItem.textContent = taskText;

    const removeButton = document.createElement('button');
    removeButton.textContent = 'Remove';
    removeButton.addEventListener('click', removeTask);

    taskList.appendChild(taskItem);
    taskItem.appendChild(removeButton);
    taskInput.value = '';
  }
}

function removeTask(event) {
  event.stopPropagation();
  event.target.parentNode.remove();
}

taskInput.addEventListener('keypress', function(event) {
  if (event.key === 'Enter') {
    addTask();
  }
});
