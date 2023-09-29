import React, { Component } from "react";
import "./status-filter.css";

class StatusFilter extends Component {
    render() {
        const clazz = this.props.active
            ? "btn btn-info btn-outline-secondary"
            : "btn  btn-outline-secondary";
        return (
            <button
                type="button"
                className={clazz}
                onClick={this.props.onClick}
            >
                {this.props.text}
            </button>
        );
    }
}

export default StatusFilter;
