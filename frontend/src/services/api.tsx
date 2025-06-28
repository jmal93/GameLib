import axios, { AxiosResponse } from "axios";
import { Game } from "@/models/Game";

let token = "";

const axiosClient = axios.create({
  baseURL: "http://localhost:5102/api",
  headers: {
    "Content-Type": "application/json",
    Authorization: "Bearer " + token,
  },
});

export const setToken = (new_token: string) => {
  token = new_token;
};

export const submitLogin = async (body: string): Promise<any> => {
  try {
    const response = await axiosClient.post("/Auth/login", body);
    return response;
  } catch (e) {
    console.error("Error in logging in user: ", e);
  }
};

export const getAllGames = async (): Promise<Game[]> => {
  try {
    const response: AxiosResponse<Game[]> = await axiosClient.get("/Game");

    return response.data;
  } catch (e) {
    console.error("Error in getting all games: " + e);
    throw e;
  }
};

export const getGameById = async (id: number) => {
  const response = await axiosClient.get("/Game/" + id);

  return response.data;
};

export * as GameService from "@/services/api";
