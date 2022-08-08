import React from 'react';
import style from './HomePage.module.css';
import { useNavigate } from 'react-router-dom';
import styleButton from '../../components/button/Mybutton.module.css';
import Mybutton from '../../components/button/Mybutton';

const HomePage: React.FC = () =>
{
    const navigate = useNavigate()
    const clickCreateHandler = () => {navigate('/create')}
    const clickOrdersHandler = () => {navigate('/orders')}
    
    return (
        <div>
            <div className={style.Shadow}> </div>
            <div className={style.Presentation}>
                <header className={style.Head}>Заказы</header>
                <div className={style.ForButtonCreate}>
                    <Mybutton
                    className={styleButton.NavButton}                
                    type={"button"}  
                    buttonOnClick={clickCreateHandler}>Новый заказ</Mybutton> 
                </div>
                <div className={style.ForButtonOrders}>
                    <Mybutton
                    className={styleButton.NavButton}                
                    type={"button"}  
                    buttonOnClick={clickOrdersHandler}>Все заказы</Mybutton> 
                </div>
                <div className={style.Sign}>MagistrTOE</div>                                        
            </div>
        </div>
    )
}

export default HomePage;