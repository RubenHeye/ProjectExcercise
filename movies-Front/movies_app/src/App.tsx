import React from 'react';
import './App.css';
import Nav from './components/nav/Nav';
import { Route, Routes } from 'react-router';
import List from './components/movies/List';
import NotFound from './views/NotFound';
import MovieDetails from './views/MovieDetails';

function App() {
  return (
    <React.Fragment>
        <Nav />
        <Routes>
          <Route path='/' element={<List />}></Route>
          <Route path='/:id' element={<MovieDetails />}></Route>
          <Route path='*' element={<NotFound/>}></Route>
        </Routes>
    </React.Fragment>
  );
}

export default App;
