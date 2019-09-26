var ordersListBlock; //orders list element
var orderInfoTable; //table containing order summary data
var orderName; //element containing order name
var orderDate; //element containing order date
var orderStatus; //status element
var orderTotal; //total...
var selectedOrder; //cache for selected order element on orderslistBlock
var orderDetails; //details table
var orderTotals;//total table

function displayWebApiError(jxqr, error, status) {
    alert(status == 404 ? 'Данные не найдены.' : 'Произошла ошибка. ' + jxqr.responseText);
}

//starts our app
function go() {
    ordersListBlock = document.getElementById('ordersList');
    orderInfoBlock = document.getElementById('orderInfo');
    orderInfoTable = document.getElementById('orderInfoTable');
    orderName = document.getElementById('orderName');
    orderDate = document.getElementById('orderDate');
    orderStatus = document.getElementById('orderStatus');
    orderTotal = document.getElementById('orderTotal');
    orderDetails = document.getElementById('orderDetailsList');
    orderTotals = document.getElementById('orderTotalList');

    loadOrders();
}

function loadOrders() {
    ordersListBlock.innerHTML = '';

    $.ajax({
        url: '/api/order',
        type: 'GET',
        contentType: "application/json",
        success: function (orders) {
            $.each(orders, function (index, order) {
                renderOrder(order);
            })
        },
        error: displayWebApiError
    });
}

function renderOrder(order) {
    var color = '';
    var createDate = new Date(order.createDate);

    if (order.status == 'InProgress') {
        color = 'purple';
    }

    if (order.status == 'Complete') {
        color = 'green';
    }

    ordersListBlock.innerHTML += '<div class="orderRow" title="Click to view details" onclick="selectOrder(this, ' + order.id + ');"><div class="square ' + color + '"></div>' + order.orderName + ' ' + createDate.toLocaleString() + '</div>';
}

function selectOrder(orderElement, orderId) {
    if (selectedOrder) {
        selectedOrder.classList.remove('selectedOrder');
    }

    selectedOrder = orderElement;
    orderElement.classList.add('selectedOrder');

    loadOrderInfo(orderId);
    loadOrderDetails(orderId);
    loadOrderTotal(orderId);
}

function renderOrderInfo(order) {
    var color = '';
    var createDate = new Date(order.createDate);

    orderInfoTable.style.display = 'table';

    if (order.status == 'InProgress') {
        color = 'purple';
    }

    if (order.status == 'Complete') {
        color = 'green';
    }

    orderName.innerText = order.orderName;
    orderDate.innerText = createDate.toLocaleString();
    orderStatus.innerHTML = '<div class="square ' + color + '"></div>' + order.status;
}

function loadOrderInfo(orderId) {
    $.ajax({
        url: '/api/order/' + orderId,
        type: 'GET',
        contentType: "application/json",
        success: function (order) {
            renderOrderInfo(order);
        },
        error: displayWebApiError
    });
}

function loadOrderDetails(orderId) {
    orderDetails.style.display = 'table';
    orderDetails.innerHTML = '<tr><th>Product Name</th><th>Quantity</th><th>Price</th><th>Total</th></tr>';

    $.ajax({
        url: '/api/orderDetails/' + orderId,
        type: 'GET',
        contentType: "application/json",
        success: function (details) {
            $.each(details, function (index, detail) {
                renderOrderRow(orderDetails, detail.product, detail.quantity, detail.price, detail.total)
            })
        },
        error: displayWebApiError
    });
}

function loadOrderTotal(orderId) {
    orderTotals.style.display = 'table';
    orderTotals.innerHTML = '';

    $.ajax({
        url: '/api/orderTotal/' + orderId,
        type: 'GET',
        contentType: "application/json",
        success: function (total) {
            renderOrderRow(orderTotals, 'Total', total.totalQuantity, '', total.totalValue);
            orderTotal.innerText = total.totalValue; //do not forget to set total in order info panel
        },
        error: displayWebApiError
    });
}

function renderOrderRow(parentTable, product, quantity, price, total) {
    parentTable.innerHTML += '<tr><td class="productColumn">' + product + '</td><td class="quantityColumn">' + quantity + '</td><td class="priceColumn">' + price + '</td><td class="totalColumn">' + total + '</td></tr>';
}
