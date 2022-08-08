import React from "react";
import {IOrder} from "../types/IOrder";
import OrderItem from "./orderItem/OrderItem";

interface OrderListProps {
    orders: IOrder[]
}

const OrderList: React.FC<OrderListProps> = ({orders}) => {
    return (
        <div>
            {orders.map(order =>
                <OrderItem key={order.id} order={order}/>
            )}
        </div>
    )
}

export default OrderList;