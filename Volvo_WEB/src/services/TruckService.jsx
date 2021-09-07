import http from "../http-common";

const getAll = () => {
  return http.get("/truck");
};

const get = id => {
  return http.get(`/truck/${id}`);
};

const create = data => {
  return http.post("/truck", data);
};

const update = (id, data) => {
  return http.put(`/truck/${id}`, data);
};

const remove = id => {
  return http.delete(`/truck/${id}`);
};


export default {
  getAll,
  get,
  create,
  update,
  remove
};