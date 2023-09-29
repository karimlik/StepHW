import TaskListItem from "../task-list-item";
import './task-list.css'

import React, {Component} from 'react';

class TaskList extends Component {
    render() {
        const {onDeleted, tasks} = this.props;

        const elements = tasks.map((item)=>{
            const {id, ...itemProps} = item
            return <li key={id} className="list-group-item">
                <TaskListItem {...itemProps}
                    onDeleted={()=>{onDeleted(id)}}
                />
            </li>
        })

        return(
            <ul className="list-group list-todo">
                {elements}
            </ul>
        )
    }
}

export default TaskList