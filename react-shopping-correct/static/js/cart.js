window.load = function () {
    function takeData() {
        fetch('https://localhost:44335/api/Product')
            .then(response => response.json())
            .then((data) => showProducts(data));

        function showProducts(data) {
            let products = data;
            console.log(products);
            let container = document.querySelector(".container");
            let list = document.querySelector('.row');
            console.log(list);
            for (let i = 0; i < products.length; i++) {
                let col = document.createElement('div');
                col.classList.add('col');
                col.innerHTML = `
                <div class="card" style="width: 20rem;">
                <img class="card-img-top" src=${products[i]['image']} alt="Card image cap">
                <div class="card-block">
                    <h4 class="card-title">${products[i]['name']}</h4>
                    <p class="card-text">Price: $${products[i]['price']} </p>
                    <a href="#" onclick='addItemToCart(event);' data-name=${products[i]['name']} data-price=${products[i]['price']} data-id = ${products[i]['id']}   class="add-to-cart btn btn-primary">Add to
                        cart</a>
                </div>
                </div>`;
                list.appendChild(col);
            }
            container.appendChild(list);

        }

    }

    takeData();

    var shoppingCart = (function () {

        cart = [];


        // Constructor
        function Item(name, price, id, count) {
            this.name = name;
            this.price = price;
            this.count = count;
            this.id = id;
        }

        // Save cart
        function saveCart() {
            sessionStorage.setItem('shoppingCart', JSON.stringify(cart));
        }

        // Load cart
        function loadCart() {
            cart = JSON.parse(sessionStorage.getItem('shoppingCart'));
        }
        if (sessionStorage.getItem("shoppingCart") != null) {
            loadCart();
        }


        let obj = {};

        // Add to cart
        obj.addItemToCart = function (name, price, id, count) {
            for (let item in cart) {
                if (cart[item].name === name) {
                    cart[item].count++;
                    saveCart();
                    return;
                }
            }
            let item = new Item(name, price, id, count);
            cart.push(item);
            saveCart();
        }
        // Set count from item
        obj.setCountForItem = function (name, count) {
            for (let i in cart) {
                if (cart[i].name === name) {
                    cart[i].count = count;
                    break;
                }
            }
        };
        // Remove item from cart
        obj.removeItemFromCart = function (name) {
            for (let item in cart) {
                if (cart[item].name === name) {
                    cart[item].count--;
                    if (cart[item].count === 0) {
                        cart.splice(item, 1);
                    }
                    break;
                }
            }
            saveCart();
        }

        // Remove all items from cart
        obj.removeItemFromCartAll = function (name) {
            for (let item in cart) {
                if (cart[item].name === name) {
                    cart.splice(item, 1);
                    break;
                }
            }
            saveCart();
        }

        // Clear cart
        obj.clearCart = function () {
            cart = [];
            saveCart();
        }

        // Count cart 
        obj.totalCount = function () {
            var totalCount = 0;
            for (var item in cart) {
                totalCount += cart[item].count;
            }
            return totalCount;
        }

        // Total cart
        obj.totalCart = function () {
            var totalCart = 0;
            for (var item in cart) {
                totalCart += cart[item].price * cart[item].count;
            }
            return Number(totalCart.toFixed(2));
        }

        // List cart
        obj.listCart = function () {
            var cartCopy = [];
            for (i in cart) {
                item = cart[i];
                itemCopy = {};
                for (p in item) {
                    itemCopy[p] = item[p];

                }
                itemCopy.total = Number(item.price * item.count).toFixed(2);
                cartCopy.push(itemCopy)
            }
            return cartCopy;
        }

        return obj;
    })();


    addItemToCart = function (event) {
        console.log('click');
        event.preventDefault();
        const button = event.target;
        let name = button.dataset.name;
        let price = Number(button.dataset.price);
        let id = Number(button.dataset.id);
        shoppingCart.addItemToCart(name, price, id, 1);
        displayCart();
    };



    // Clear items
    $('.clear-cart').click(function () {
        shoppingCart.clearCart();
        displayCart();
    });

    //Prepare order
    function prepareProducts() {
        let cartOrder = shoppingCart.listCart();
        let order = [];
        for (let i = 0; i < cartOrder.length; i++) {
            let id = cartOrder[i].id;
            console.log(id);
            let count = cartOrder[i].count;
            order.push(
                {
                    "productId": id,
                    "quantity": count,
                }
            )
        }
        return order;
        console.log(order);
    }

    function prepareOrder() {
        let orderProducts = prepareProducts();
        let order = {
            "customerId": 2,
            "orderItems": orderProducts,
        }
        console.log(order);
        return order;
    }

    //send order
    $(".order").click(function () {
        const order = prepareOrder();
        fetch("https://localhost:44335/api/Order", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(order),
        })
            .then(response => response.json())
            .then(data => {
                data ? console.log('Success') : console.log('Something went wrong');
            })
            .catch((error) => {

                console.error('Error:', error);
            })
    }
    )

    function displayCart() {
        var cartArray = shoppingCart.listCart();
        var output = "";
        for (var i in cartArray) {
            output += "<tr>"
                + "<td>" + cartArray[i].name + "</td>"
                + "<td>(" + cartArray[i].price + ")</td>"
                + "<td><div class='input-group'><button class='minus-item input-group-addon btn btn-primary' data-name=" + cartArray[i].name + ">-</button>"
                + "<input type='number' class='item-count form-control' data-name='" + cartArray[i].name + "' value='" + cartArray[i].count + "'>"
                + "<button class='plus-item btn btn-primary input-group-addon' data-name=" + cartArray[i].name + ">+</button></div></td>"
                + "<td><button class='delete-item btn btn-danger' data-name=" + cartArray[i].name + ">X</button></td>"
                + " = "
                + "<td>" + cartArray[i].total + "</td>"
                + "</tr>";
        }
        $('.show-cart').html(output);
        $('.total-cart').html(shoppingCart.totalCart());
        $('.total-count').html(shoppingCart.totalCount());
    }

    // Delete item button

    $('.show-cart').on("click", ".delete-item", function (event) {
        var name = $(this).data('name')
        shoppingCart.removeItemFromCartAll(name);
        displayCart();
    })


    // -1
    $('.show-cart').on("click", ".minus-item", function (event) {
        var name = $(this).data('name')
        shoppingCart.removeItemFromCart(name);
        displayCart();
    })
    // +1
    $('.show-cart').on("click", ".plus-item", function (event) {
        var name = $(this).data('name')
        shoppingCart.addItemToCart(name);
        displayCart();
    })

    // Item count input
    $('.show-cart').on("change", ".item-count", function (event) {
        var name = $(this).data('name');
        var count = Number($(this).val());
        shoppingCart.setCountForItem(name, count);
        displayCart();
    });

    displayCart();


};
window.load();