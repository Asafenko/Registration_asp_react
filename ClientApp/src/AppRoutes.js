import { Home } from "./components/Home";
import { Registration } from "./components/Registration"
import {ListTradeMark} from "./components/ListTradeMark";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/registration',
    element: <Registration />
  },
  {
    path: '/list',
    element:<ListTradeMark />
  }
];

export default AppRoutes;
