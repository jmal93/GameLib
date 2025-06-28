import { deleteCookie, getCookie, OptionsType, setCookie } from "cookies-next";

const cookieOptions: OptionsType = {
  httpOnly: false,
};

export const setAuthToken = (token: string) => {
  setCookie("authToken", token, cookieOptions);
};

export const getAuthToken = () => {
  return getCookie("authToken");
};

export const removeAuthToken = () => {
  deleteCookie("authToken");
};
