import {BrowserRouter, Routes, Route} from 'react-router-dom'
import OrdersPage from './page/ordersPage/OrdersPage';
import HomePage from './page/homePage/HomePage';
import AddOrderPage from './page/addOrderPage/AddOrderPage';

const App = () => {

  return (
      <div>
        <BrowserRouter>
          <Routes>
            <Route path={'/orders'} element={<OrdersPage/>} />
            <Route path={'/'} element={<HomePage/>} />
            <Route path={'/create'} element={<AddOrderPage/>} />
          </Routes>        
        </BrowserRouter>
      </div>      
  );
}

export default App;


