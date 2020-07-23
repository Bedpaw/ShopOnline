import React, { Component } from 'react'
import formatCurrency from './util';

export default class Cart extends Component {

    render() {
        const { cartItems } = this.props;
        return (
            <div>
                {cartItems.length === 0 ? <div className="cart cart-header"> Cart is empty </div>
                    :
                    <div className="cart cart-header">
                        You have {cartItems.length} in the cart {" "}
                    </div>
                }
                {cartItems.length !== 0 && (
                    <div>
                        <div className="cart">
                            <ul className="cart-items">
                                {cartItems.map(item => (
                                    <li key={item.product_id}>
                                        <div >
                                            <img src={item.image} alt={item.name}></img>
                                        </div>
                                        <div>
                                            <div>{item.name}</div>
                                            <div className="right">
                                                {formatCurrency(item.price)} x {item.count} {" "}
                                                <button className="button" onClick={() => this.props.removeFromCart(item)}>Remove</button>
                                            </div>

                                        </div>
                                    </li>
                                ))}
                            </ul>
                        </div>
                        <div className="cart">
                            <div className="total">
                                <div>
                                    Total:{" "}
                                    {formatCurrency(cartItems.reduce((a, c) => a + c.price * c.count, 0))}
                                </div>
                                <button className="btn-primary" onClick={() => this.props.postCart(cartItems)}>Proceed</button>
                            </div>
                        </div>
                    </div>
                )}

            </div>

        )
    }
}
