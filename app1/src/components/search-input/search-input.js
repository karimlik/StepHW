import React, {Component} from 'react';

import './search-input.css'

class SearchInput extends Component {
    render() {
        return(
            <input
                className="form-control search-input"
                type="text" placeholder={this.props.placeText}
            />
        )
    }
}

export default SearchInput;
