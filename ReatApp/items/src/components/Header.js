import {Navbar, Nav, Container } from 'react-bootstrap';
import {
  BrowserRouter,
  Routes,
  Route,
  Link
} from "react-router-dom";
import {About} from './About';
import {Contact} from './Contact';
import Items from './Items';
 

function Header() {
  return (
    <BrowserRouter>
    <div className="App">
      <>
      <Navbar bg="primary" variant="dark">
        <Container>
          <Navbar.Brand href="#items">My Items</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link as= {Link} to='/'>Items</Nav.Link>
            <Nav.Link as = {Link} to='/about'>About</Nav.Link>
            <Nav.Link as = {Link} to='/contact' >Contact</Nav.Link>           
          </Nav>
        </Container>
      </Navbar>     
      </> 

      <div>
        <Routes>
        <Route path='/' element={<Items />}></Route>
          <Route path='/about' element={<About />}></Route>
          <Route path='/contact' element={<Contact />}></Route>          
        </Routes>
      </div>
    </div>
    </BrowserRouter>
  );
}

export default Header;
