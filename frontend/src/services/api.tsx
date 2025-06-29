import axios, { AxiosResponse } from "axios";
import { Game } from "@/models/Game";
import { getAuthToken } from "./auth";

const axiosClient = axios.create({
  baseURL: "http://localhost:5102/api",
  headers: {
    "Content-Type": "application/json",
  },
});

axiosClient.interceptors.request.use(async (config) => {
  const token = await getAuthToken();
  if (token) {
    config.headers.Authorization = "Bearer " + token.value;
  }
  return config;
});

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

export const getUserLibrary = async (): Promise<any> => {
  try {
    const response = await axiosClient.get("/User/library");

    return response.data;
  } catch (e) {
    console.error("Error in getting library: " + e);
  }
};

export const addGameToUserLibrary = async (gameId: number) => {
  try {
    const response = await axiosClient.post("/User/library/" + gameId);

    return response.data;
  } catch (e) {
    console.error("Error in adding game to library: " + e);
  }
};

export * as GameService from "@/services/api";
