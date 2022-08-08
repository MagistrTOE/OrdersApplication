import React, { useEffect, useState } from 'react';
import { IOrder } from '../../types/IOrder';
import axios from 'axios';
import OrderList from '../../components/OrderList';
import usePagination from '../../components/usePagination';
import style from './OrdersPage.module.css';
import Mybutton from '../../components/button/Mybutton';
import { useNavigate } from 'react-router-dom';
import styleButton from '../../components/button/Mybutton.module.css'

const OrdersPage: React.FC = () => {
const [orders, setOrders] = useState<IOrder[]>([])

useEffect(() => {getOrders()},[])   

async function getOrders() {
    try {
        const response = await axios.get<IOrder[]>('http://localhost/myorders/list')
        setOrders(response.data)
        }
    catch (e) {
        alert(e)
        } 
    }
    
const {
    firstContentIndex,
    lastContentIndex,
    nextPage,
    prevPage,
    page,
    setPage,
    totalPages,
    } = usePagination({contentPerPage: 2,count: orders.length,});

const navigate = useNavigate()
const clickBackHandler = () => {navigate('/')}

return (
        <div>
            <div className={style.Shadow}> </div>
            <div className={style.Presentation}>
                <header className={style.Head}>Список заказов</header>
                <div className={style.Pages}>{page}/{totalPages}</div>
                <div className={style.Orders}>
                    <OrderList orders={orders.slice(firstContentIndex, lastContentIndex)}/>
                </div>
                <div className={style.ForButtonBack}>
                    <Mybutton
                        className={styleButton.NavButton}                
                        type={"button"}  
                        buttonOnClick={clickBackHandler}>Назад
                    </Mybutton>
                </div>
                <div className={style.Pagination}>   
                    <button onClick={prevPage} className={styleButton.PageButton}>
                        &larr;
                    </button>
                    {/* @ts-ignore */}
                    {[...Array(totalPages).keys()].map((el) => (
                        <button onClick={() => setPage(el + 1)} key={el} className={styleButton.PageButton}>
                        {el + 1}</button>))}
                    <button onClick={nextPage} className={styleButton.PageButton}>
                        &rarr;
                    </button>
                </div>
            </div>                  
        </div>
    )
}

export default OrdersPage;