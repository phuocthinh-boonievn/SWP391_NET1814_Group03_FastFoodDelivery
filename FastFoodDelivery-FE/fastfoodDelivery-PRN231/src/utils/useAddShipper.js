import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const apiEndpoint = "https://localhost:7173/api/User/register"; 

function useAddShipper() {
  const [account, setAccount] = useState({
    username: "",
    email: "",
    fullName: "",
    address: "",
    phoneNumber: "",
    password: "",
    confirmPassword: "",
  });
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setAccount((prevState) => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await axios.post(apiEndpoint, account);
    navigate("/manage-shipper-accounts"); // Redirect to shipper account management after saving
  };

  return {
    account,
    handleChange,
    handleSubmit,
  };
}

export default useAddShipper;
