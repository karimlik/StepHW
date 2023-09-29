import './task-input.css'

import React, { Component } from 'react';

class TaskInput extends Component {
  state = {
    newTaskText: ''
  };

  handleInputChange = (event) => {
    this.setState({ newTaskText: event.target.value });
  };

  handleAddTask = () => {
    const { newTaskText } = this.state;
    if (newTaskText.trim() !== '') {
      this.props.onAddTask(newTaskText);
      this.setState({ newTaskText: '' });
    }
  };

  render() {
    const { newTaskText } = this.state;

    return (
      <div className='top-panel d-flex'>
        <input 
        className="form-control task-input"
          type="text"
          placeholder="Enter a new task"
          value={newTaskText}
          onChange={this.handleInputChange}
        />
        <button type="button" className="btn btn-outline-secondary" onClick={this.handleAddTask}>Add Task</button>
      </div>
    );
  }
}

export default TaskInput;
