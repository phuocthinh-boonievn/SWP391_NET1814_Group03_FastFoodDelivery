import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Layout from "./components/layout";
import AdminAccountManagement from "./pages/accountuser-management/AdminAccountManagement";
import Category from "./pages/category-management";
import FoodItemManagement from "./pages/fastfood-magegement";
import HomePage from "./pages/home";
import Login from "./pages/login";
import PaymentSuccess from "./pages/payment/paymentSuccess";
import Register from "./pages/register";
import ShoppingCart from "./pages/shoppingcart/ShoppingCart";
import ShipperAccountManagement from "./pages/accountuser-management/ShipperAccountManagement";
import AddShipper from "./pages/accountuser-management/AddShipper";
import ViewOrderHistory from "./pages/accountuser-management/ViewOrderHistory";
import ViewShipperOrders from "./pages/accountuser-management/ViewShipperOrders";
import ViewAllFeedback from "./pages/accountuser-management/ViewAllFeedback";
function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      children: [
        {
          path: "/",
          element: <HomePage />,
        },
        {
          path: "/fastfood-magegement",
          element: <FoodItemManagement />,
        },
        {
          path: "/category-management",
          element: <Category />,
        },
        {
          path: "/view-order-history",
          element: <ViewOrderHistory />,
        },
        {
          path: "/view-all-feedback", 
          element: <ViewAllFeedback />,
        },
        {
          path: "/view-shipper-orders",
          element: <ViewShipperOrders />,
        },
        {
          path: "/accountuser-management",
          element: <AdminAccountManagement />,
        },
        
        {
          path: "/shipper-account-management",
          element: <ShipperAccountManagement />,
        },
        {
          path: "/add-shipper",
          element: <AddShipper />,
        },
        {
          path: "/login",
          element: <Login />,
        },
        {
          path: "/register",
          element: <Register />,
        },
        {
          path: "/shoppingcart",
          element: <ShoppingCart />,
        },
        {
          path: "/paymentSuccess",
          element: <PaymentSuccess />,
        },
      ],
    },

    // {
    //   path: "/",
    //   element: <HomePage />,
    // },
    // {
    //   path: "/fastfood-magegement",
    //   element: <FoodItemManagement />,
    // },
    // {
    //   path: "/login",
    //   element: <Login />,
    // },
  ]);

  return <RouterProvider router={router} />;
}

export default App;
