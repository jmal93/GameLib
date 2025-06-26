import axios, { AxiosResponse } from "axios";

const axiosClient = axios.create({
  baseURL: "http://localhost:5102/api/Auth",
  headers: {
    "Content-Type": "application/json",
  },
});

export const submitLogin = async (body: string): Promise<any> => {
  try {
    const response = await axiosClient.post("/login", body);
    return response;
  } catch (e) {
    console.error("Error in logging in user: ", e);
  }
};
