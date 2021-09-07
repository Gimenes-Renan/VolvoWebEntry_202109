import http from "../http-common";

const getAll = () => {
  return http.get("/truckModel");
};

const get = id => {
  return http.get(`/truckModel/${id}`);
};

export default {
  getAll,
  get
};