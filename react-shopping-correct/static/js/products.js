window.load = function () {

    function takeData() {
        fetch('/static/js/data.json')
            .then(response => response.json())
            .then((data) => showProducts(data));

        function showProducts(data) {
            let products = data.products;
            console.log(products.length);
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
                    <a href="#" data-name=${products[i]['name']} data-price=${products[i]['price']} data-id=${products[i]['id']} class="add-to-cart btn btn-primary">Add to
                        cart</a>
                </div>
                </div>`;
                console.log(products[i]['id'])
                list.appendChild(col);
            }
            container.appendChild(list);

        }

    }

    takeData();
};

window.load();
