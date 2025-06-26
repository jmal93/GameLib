import axios, { AxiosResponse } from "axios";

const axiosClient = axios.create({
  baseURL: "http://localhost:5102/api/Auth",
  headers: {
    "Content-Type": "application/json",
  },
});

export const submitLogin = async (body: string): Promise<any> => {
  try {
    const response: AxiosResponse<any, any> = await axiosClient.post("/login");

    return response.status;
  } catch (e) {
    console.error("Error in logging in user");
  }
};
