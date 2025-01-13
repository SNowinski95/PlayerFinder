import React, { ReactNode, useCallback } from 'react';
import Grid from '@mui/material/Grid2';
import Header from './Header';
import Footer from './Footer';
import { Outlet } from 'react-router-dom';
import { useState } from 'react';
import Navbar from './Navbar';

const Layout = () => {
    const [showNavbar, setshowNavbar] = useState(() => false);
    const setshowNavbarHandler = useCallback(() => {
        setshowNavbar((prev: Boolean) => !prev);
    }, [showNavbar]);
    return (
        <>
            <Grid container spacing={2}>
                <Grid size = {{xs :12}}>
                    <Header setNavbar={setshowNavbarHandler} />
                </Grid>
                {showNavbar ?
                    <Navbar/>
                    : <Grid size = {{xs :12}}> <Outlet /> </Grid>
                }
                <Grid size = {{xs :12}}>
                    <Footer />
                </Grid>
            </Grid>
        </>
    );
};

export default Layout;
