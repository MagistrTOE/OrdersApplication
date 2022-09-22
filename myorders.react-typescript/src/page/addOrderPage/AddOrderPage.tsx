import React from 'react';
import Myinput from '../../components/input/Myinput';
import Mybutton from '../../components/button/Mybutton';
import axios from 'axios';
import { IAddedOrderId } from '../../types/IAddedOrderId';
import { IAddOrder } from '../../types/IAddOrder';
import { useNavigate } from 'react-router-dom';
import styleButton from '../../components/button/Mybutton.module.css'
import style from './AddOrderPage.module.css';

const AddOrderPage: React.FC = () => {
    
    const [order, setOrder] = React.useState<IAddOrder>({
        senderCity: '',
        senderAddress: '',
        recipientCity: '',
        recipientAddress: '',
        weight: '',
        recivedDate: '',
    })

    const onInputChange = (FieldName: string) => (e: React.ChangeEvent<HTMLInputElement>): void => {
        setOrder({...order, [FieldName]: e.currentTarget.value})}


    const clickHahdler  = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        let field = Object.values(order);
        let state = true;
        
        for (let i = 0; i < field.length; i++){
            if(field[i]=="")
            {
                window.alert("Заполните все поля");
                state = false;
                break;
            }           
        }

        if (state == true)
        {
            axios.post<IAddedOrderId>('http://localhost/myorders/', order)
            .then(response => {
                console.log(response.data)
                window.alert('Заказ успешно добавлен! \nID заказа: '+response.data.id)
                window.location.reload()
            }).catch(err => window.alert('Проблема с сервером! \n'+err))
        }             
    }              
    
    const navigate = useNavigate()
    const clickBackHandler = () => {navigate('/')}
     
    return (               
        <div>
            <div className={style.Shadow}> </div>
            <div className={style.Presentation}>
                <header className={style.Head}>Новый заказ</header>                    
                <form className={style.Form}>
                    <Myinput 
                        value={order?.senderCity}
                        onChange={onInputChange('senderCity')}
                        maxLength={20}
                        title={"Не больше 20 символов"}
                        placeholder={"Город отправителя"} />
                    <Myinput 
                        value={order?.senderAddress}
                        onChange={onInputChange('senderAddress')}
                        placeholder={"Адрес отправителя"} />
                    <Myinput 
                        value={order?.recipientCity}
                        maxLength={20}
                        title={"Не больше 20 символов"}
                        onChange={onInputChange('recipientCity')}
                        placeholder={"Город получателя"} />
                    <Myinput 
                        value={order?.recipientAddress}
                        onChange={onInputChange('recipientAddress')}
                        placeholder={"Адрес получателя"} />
                    <Myinput
                        value={order?.weight} 
                        type={"number"}
                        max={10000}
                        title={"Вес груза должен быть не больше 10000 КГ"}
                        placeholder={"Вес груза"}
                        onChange={onInputChange('weight')} />
                    <div className={style.Text}>Дата получения:</div>
                    <Myinput
                        value={order?.recivedDate}
                        type={"date"}
                        asp={"DateTime"}                
                        onChange={onInputChange('recivedDate')}
                        placeholder={"Дата получения"} />
                    <div className={style.ForButtonAdd}>
                        <Mybutton
                            className={styleButton.NavButton}             
                            type={"submit"}  
                            buttonOnClick={clickHahdler}>Добавить
                        </Mybutton>
                    </div>         
                </form>
                <div className={style.ForButtonBack}>
                    <Mybutton
                        className={styleButton.NavButton}                
                        type={"button"}  
                        buttonOnClick={clickBackHandler}>Назад
                    </Mybutton>
                </div>
            </div>                
        </div>    
    )
}

export default AddOrderPage;