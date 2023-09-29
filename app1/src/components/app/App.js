import React, { Component } from 'react';
import AppHeader from "../app-header";
import SearchInput from "../search-input";
import TaskList from "../task-list";
import './app.css'
import StatusFilter from "../status-filter";
import TaskInput from "../task-input";

class App extends Component {
    state = {
        tasks: [
            { id: 1, text: 'Buy bread', isComplete: false },
            { id: 2, text: 'Buy notebook', isComplete: false },
            { id: 3, text: 'Send homework nakonec to', isComplete: true },
            { id: 4, text: 'Do homework', isComplete: false },
        ],
        filter: "All"
    }

    handleAddTask = (newTaskText) => {
        const { tasks } = this.state;
        const newTask = {
            id: tasks.length + 1,
            text: newTaskText
        };
        this.setState({ tasks: [...tasks, newTask] });
    };

    setFilter = (filter) => {
        this.setState({ filter });
    };
    
    deleteItem = (id) => {
        this.setState(({ tasks }) => {
            const index = tasks.findIndex((e) => e.id === id)
            const newList = [...tasks.slice(0, index),
            ...tasks.slice(index + 1)]
            return {
                tasks: newList
            }
        })
    }

    render() {
        return (
            <>
                <div className='app-todo'>
                    <AppHeader />

                    <div className='top-panel d-flex'>
                        <SearchInput placeText={"Search"} />
                        <StatusFilter text="All" active={this.state.filter === "All"} onClick={() => this.setFilter("All")} />
                        <StatusFilter text="Active" active={this.state.filter === "Active"} onClick={() => this.setFilter("Active")} />
                        <StatusFilter text="Done" active={this.state.filter === "Done"} onClick={() => this.setFilter("Done")} />
                    </div>


                    <TaskInput onAddTask={this.handleAddTask} />

                    <TaskList
                        tasks={this.state.tasks.filter((task) => {
                            if (this.state.filter === "All") {
                                return true;
                            } else if (this.state.filter === "Active") {
                                return !task.isComplete;
                            } else if (this.state.filter === "Done") {
                                return task.isComplete;
                            }
                            return false;
                        })}
                        onDeleted={this.deleteItem}
                    />

                </div>

            </>
        )
    }
}

export default App
