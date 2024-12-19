
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';

import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import React from 'react';
import LoginPopup from '../Views/general/Login/LoginPopup';



interface HeaderProp {
    setNavbar: () => void;
}
const Header: React.FC<HeaderProp> = ({ setNavbar }) => {
    
      
    
  return (
      <Box sx={{ flexGrow: 1 }}>
          <AppBar position="static">
              <Toolbar>
                  <IconButton
                      size="large"
                      edge="start"
                      color="inherit"
                      aria-label="menu"
                      sx={{ mr: 2 }}
                      onClick={setNavbar} 
                  >
                      <MenuIcon />
                  </IconButton>
                  <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                      Player Finder
                  </Typography>
                  <LoginPopup/>
              </Toolbar>
          </AppBar>
      </Box>
  );
}

export default Header
