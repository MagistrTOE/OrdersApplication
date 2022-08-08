import React from "react";
import {IOrder} from "../../types/IOrder";
import classes from "./OrderItem.module.css"

interface OrderItemProps {
    order: IOrder;
}

const OrderItem: React.FC<OrderItemProps> = ({order}) => {
   
    return (
        <table className={classes.myTable}>
            <tr>
                <td>
                ID заказа: 
                </td>
                <td>
                {order.id} 
                </td>
            </tr>
            <tr>
                <td>
                Город отправителя: 
                </td>
                <td>
                {order.senderCity} 
                </td>
            </tr>
            <tr>
                <td>
                Адрес отправителя: 
                </td>
                <td>
                {order.senderAddress} 
                </td>
            </tr>
            <tr>
                <td>
                Город получателя: 
                </td>
                <td>
                {order.recipientCity} 
                </td>
            </tr>
            <tr>
                <td>
                Адрес получателя: 
                </td>
                <td>
                {order.recipientAddress} 
                </td>
            </tr>
            <tr>
                <td>
                Вес груза (кг): 
                </td>
                <td>
                {order.weight} 
                </td>
            </tr>
            <tr>
                <td>
                Дата забора груза: 
                </td>
                <td>
                {order.recivedDate} 
                </td>
            </tr>
        </table>       
    )
}

export default OrderItem;