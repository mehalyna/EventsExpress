import React, { Component } from 'react';
import cancel_all_occurenceEvent from '../actions/cancel-all-occurenceEvents';
import { connect } from 'react-redux';
import Dropdown from 'react-bootstrap/Dropdown'
import { reset } from 'redux-form';
import OccurenceEventModal from '../components/occurenceEvent/occurenceEvent-modal'
import {
    setCancelAllOccurenceEventsPending,
    setCancelAllOccurenceEventsError,
    setCancelAllOccurenceEventsSuccess
}
    from '../actions/cancel-all-occurenceEvents';

class CancelAllEventsWrapper extends Component {
    constructor() {
        super()
        this.state = {
            show: false,
        };
        this.cancelHandler = this.cancelHandler.bind(this);
        this.submitHandler = this.submitHandler.bind(this);
    }

    componentDidUpdate = () => {
        if (!this.props.cancel_all_occurenceEvent_status.cancelOccurenceEventsError &&
            this.props.cancel_all_occurenceEvent_status.isCancelOccurenceEventsSuccess) {
            this.props.resetEvent();
            this.props.reset();
        }
    }

    cancelHandler = () => {
        this.setState({
            redirect: false,
            show: false,
        });
    }

    handleClick = () => {
        this.setState({
            show: true
        });
    }

    submitHandler = () => {
        this.setState({
            show: false,
        });
        this.props.cancel_all_occurenceEvent(this.props.initialValues.id);
    }

    render() {

        return <>
            <Dropdown.Item onClick={this.handleClick}>Cancel</Dropdown.Item>
            <OccurenceEventModal
                cancelHandler={this.cancelHandler}
                message="Are you sure to cancel all events?"
                show={this.state.show}
                submitHandler={this.submitHandler} />
        </>
    }
}

const mapStateToProps = (state) => ({
    user_id: state.user.id,
    cancel_all_occurenceEvent_status: state.cancel_all_occurenceEvent,
    initialValues: state.event.data,
});

const mapDispatchToProps = (dispatch) => {
    return {
        cancel_all_occurenceEvent: (data) => dispatch(cancel_all_occurenceEvent(data)),
        resetEvent: () => dispatch(reset('event-form')),
        reset: () => {
            dispatch(setCancelAllOccurenceEventsPending(true));
            dispatch(setCancelAllOccurenceEventsSuccess(false));
            dispatch(setCancelAllOccurenceEventsError(null));
        }
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(CancelAllEventsWrapper);