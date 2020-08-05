import React from 'react';
//import data from "./data.json";
import Products from './components/Products';
import Filter from './components/Filter';
import Cart from './components/Cart';


class App extends React.Component {
  constructor() {
    super();
    this.state = {
      products: [],
      cartItems: [],
      sort: "",
      order: { UserId: "", OrderItems: { productId: "", quantity: "" } },
    };
    fetch('data/data.json')
      .then(response => response.json())
      .then(data => {
        this.setState({
          products: data.products
        })
      })

  }

  removeFromCart = (product) => {
    const cartItems = this.state.cartItems.slice();
    this.setState({
      cartItems: cartItems.filter(x => x.product_id !== product.product_id),
    });

  }

  addToCart = (product) => {
    const cartItems = this.state.cartItems.slice();
    let alreadyInCart = false;
    cartItems.forEach(item => {
      if (item.product_id === product.product_id) {
        item.count++;
        alreadyInCart = true;
      }
    });
    if (!alreadyInCart) {
      cartItems.push({ ...product, count: 1 });
    }
    this.setState({ cartItems });
  };


  sortProducts = (event) => {
    const sort = event.target.value;
    this.setState(state => ({
      sort: sort,
      products: this.state.products
        .slice()
        .sort((a, b) =>
          sort === "lowest"
            ? a.price < b.price
              ? 1
              : -1
            : sort === "highest"
              ? a.price > b.price
                ? 1
                : -1
              : a.product_id > b.product_id
                ? 1
                : -1
        ),
    }));
  };

  postCart = (cartItems) => {
    OrderItems = this.state.OrderItems;
    cartItems.forEach(item =>
      cartItems.)
    fetch("urldoPosta", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(cartItems),
    })
      .then(response => response.json())
      .then(data => {
        console.log('Success', data);
      })
      .catch((error) => {
        console.error('Error:', error);
      })
  }

  render() {
    return (
      <div className="grid-container">
        <header>
          <a href="/">Angry Banana Shop</a>
        </header>
        <main>
          <div className="content">
            <div className="main">
              <Filter
                count={this.state.products.length}
                sort={this.state.sort}
                sortProducts={this.sortProducts}
              ></Filter>
              <Products
                products={this.state.products}
                addToCart={this.addToCart}

              ></Products>
            </div>
            <div className="sidebar">
              <Cart cartItems={this.state.cartItems} removeFromCart={this.removeFromCart} postCart={this.postCart} />
            </div>
          </div>
        </main>
        <footer>PPAW</footer>
      </div>
    );
  }

}

export default App;
