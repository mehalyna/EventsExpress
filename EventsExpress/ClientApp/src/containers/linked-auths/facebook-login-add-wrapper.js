import React, { Component } from 'react';
import FacebookLogin from 'react-facebook-login';
import { connect } from 'react-redux';
import { facebookLoginAdd } from '../../actions/editProfile/linked-auths-add-action';
import config from '../../config';
import { setErrorAllert } from '../../actions/alert-action';
import '../css/Auth.css';

class LoginFacebook extends Component {
    facebookResponseHandler = response => {
        if (typeof response === 'undefined'|| typeof response.email === 'undefined') {
            this.props.setErrorAllert("Please add email to your google account!")
            return;
        }
        this.props.facebookLoginAdd(response.email);
    }
    render() {
        return (
            <div>
                <FacebookLogin
                    appId={config.FACEBOOK_CLIENT_ID}
                    autoLoad={false}
                    fields="email"
                    callback={this.facebookResponseHandler}
                    cssClass="btnFacebook"
                    icon={<i className="fab fa-facebook fa-lg"></i>}
                    textButton="&nbsp;&nbsp;Log in"
                    version="3.1"
                />
            </div>
        );
    }
};

const mapDispatchToProps = dispatch => ({
    facebookLoginAdd: email => dispatch(facebookLoginAdd(email)),
        setErrorAllert: msg => dispatch(setErrorAllert(msg))
});

export default connect(null, mapDispatchToProps)(LoginFacebook);
