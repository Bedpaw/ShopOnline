import React, { Component } from 'react';
import formatCurrency from "../components/util";

export default class Products extends Component {
    render() {
        return (
            <div>
                <ul className="products">
                    {this.props.products.map(product => (
                        <li key={product.product_id}>
                            <div className="product">
                                <a href={"#" + product.product_id}>
                                    <img src={product.image} alt={product.name} />
                                    <p>{product.name}</p>
                                </a>
                            </div>
                            <div className="product-price">
                                <div>
                                    {formatCurrency(product.price)}
                                </div>
                                <button onClick={() => this.props.addToCart(product)} className="btn-primary">Add to cart</button>
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        )
    }
}
