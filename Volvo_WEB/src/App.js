import React from "react";
import { Switch, Route, Link } from "react-router-dom";
import "./App.css";

import AddTruck from "./components/AddTruck";
import Truck from "./components/Truck";
import TrucksList from "./components/TrucksList";

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/Trucks" className="navbar-brand">
          Volvo Trucks Latin America
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/Trucks"} className="nav-link">
              Trucks
            </Link>
          </li>
          <li className="nav-item">
            <Link to={"/add"} className="nav-link">
              Add
            </Link>
          </li>
        </div>
      </nav>

      <div className="container mt-3">
        <Switch>
          <Route exact path={["/", "/Trucks"]} component={TrucksList} />
          <Route exact path="/add" component={AddTruck} />
          <Route path="/Trucks/:id" component={Truck} />
        </Switch>
      </div>
    </div>
  );
}

export default App;