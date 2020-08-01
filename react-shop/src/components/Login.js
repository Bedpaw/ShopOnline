import React, { Component } from 'react'

export default class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            showLogin: false,
            email: "",
            password: "",
        }

    }

    checkLogin = (e) => {
        e.preventDefault();
        const loginData =
        {
            email: this.state.email,
            password: this.state.password,
        };
        this.props.checkLogin(loginData);
    }



    handleInput = (e) => {
        this.setState(
            {
                [e.target.email]: e.target.value,
            }
        )
    }


    render() {
        return (
            <div>
                <div>
                    <button className="button" onClick={() => { this.setState({ showLogin: true }) }}>Login</button>
                </div>
                {this.state.showLogin && (
                    <div className="loginForm">
                        <form onSubmit={this.loginUser}>
                            <ul className="form-container">
                                <li>
                                    <label>Email</label>
                                    <input name="email" type="text" required onChange={this.handleInput}></input>
                                </li>
                                <li>
                                    <label>Passowrd</label>
                                    <input name="password" type="text" required></input>
                                </li>
                                <li>
                                    <button type='submit'>Confirm</button>
                                </li>
                            </ul>
                        </form>
                    </div>
                )}
            </div>
        )
    }
}