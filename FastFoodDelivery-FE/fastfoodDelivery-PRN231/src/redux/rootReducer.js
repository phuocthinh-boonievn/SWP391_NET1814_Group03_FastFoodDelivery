import { combineReducers } from "@reduxjs/toolkit";
import fastfoodCart from "./features/fastfoodCart";
import userAccount from "./features/userAccount";
import orderHistory from "./features/ViewOrderHistory";
import shipperOrders from "./features/ViewShipperOrders"; 
import feedback from "./features/ViewAllFeedback";
export const rootReducer = combineReducers({
  accountmanage: userAccount,
  fastfoodcard: fastfoodCart,
  orderHistory,
  shipperOrders, 
  feedback,
});
