import styled from 'styled-components';
import Grid from '@mui/material/Grid2';
import { NavLink, Outlet } from "react-router-dom";
import '../../scss/global.css';


const Nav = styled.div`
    border: solid;
    border-color: #1976d2;
    margin-top: -2vh;
    list-style-type: none;
`;
const GridWrap = styled.div`
    display: contents;
    
`;
const Navbar = () => {
    return (
        <>
            <GridWrap>
            <Grid size = {{xs :2}}>
                    <Nav>
                        <nav>
                            <ul style={{ listStyleType: "none", paddingInlineStart: "0px"}}>
                                <li>
                                    <NavLink to="/">Home</NavLink>
                                </li>
                                <li>
                                    <NavLink to="/games">Games</NavLink>
                                </li>
                                <li>
                                    <NavLink to="/profile">Profile</NavLink>
                                </li>
                                <li>
                                    <NavLink to="/about">About</NavLink>
                                </li>
                            </ul>
                        </nav>

                    </Nav>
                    
            </Grid><Grid size = {{xs :10}}>
                <Outlet />
                </Grid>
            </GridWrap>
        </>
    );
}

export default Navbar;