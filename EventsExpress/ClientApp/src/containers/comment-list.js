﻿import React, { Component } from 'react';
import { connect } from 'react-redux';
import CommentList from '../components/comment/comment-list';
import getComments from '../actions/comment/comment-list-action';



class CommentListWrapper extends Component {

    componentWillMount() {
        const { page } = this.props.match.params;
        this.props.getComments(this.props.eventId, page);
    }

    render() {

        const { data } = this.props.comments;

        return <CommentList
                evId={this.props.eventId}
                data_list={data.items}
                page={data.pageViewModel.pageNumber}
                totalPages={data.pageViewModel.totalPages}
                callback={this.props.getComments}
            />
    }
}

const mapStateToProps = state => ({
    comments: state.comments,
    eventId: state.event.data.id
});

const mapDispatchToProps = dispatch => ({
    getComments: (data, page) => dispatch(getComments(data, page))
});

export default connect(mapStateToProps, mapDispatchToProps)(CommentListWrapper);