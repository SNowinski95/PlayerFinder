import { Popper  as BasePopup } from '@mui/base/Popper';
import { styled } from '@mui/system';
import Button from '@mui/material/Button';
import React, { useEffect } from 'react';
import useLocalStorage from '../../../general/LocalStorage';
import SimpleProfile from './SimpleProfileView';
import LoginView from './LoginView';
export default function LoginPopup(){
    const [anchor, setAnchor] = React.useState<null | HTMLElement>(null);
    const [userData, setUserData] =  useLocalStorage('UserData',null);
    useEffect(()=>{window.dispatchEvent(new Event("storage"));});
    const open = Boolean(anchor);
    const id = open ? 'login-popup' : undefined;
    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchor(anchor ? null : event.currentTarget);
      }
      const PopupConteiner = styled('div')(`
        background-color: '#242424'`)

    const PopupBody = styled('div')(`
        width: max-content;
        padding: 12px 16px;
        margin: 8px;
        border-radius: 8px;
        border: 1px solid #434D5B;
        background-color: #242424;
        box-shadow: 0px 4px 8px rgb(0 0 0 / 0.7);
        font-family: 'IBM Plex Sans', sans-serif;
        font-size: 0.875rem;
        z-index: 1;
      `,
      
    );
    const PopupBody2 = styled('div')(`
        padding: 12px 16px;
        margin: 8px;
        border-radius: 8px;
        border: 1px solid '#434D5B';
        background-color: '#242424';
      `);
    return(
        <>
            <Button aria-describedby={id} onClick={handleClick} color="inherit">Login</Button>
            <PopupConteiner>
                <BasePopup id={id} open={open} anchorEl={anchor}>
                    <PopupBody>{userData?.isLogin!! ? <SimpleProfile login= {userData.login} updateUser = {setUserData}/> : <LoginView updateUser={setUserData}/>}
                    </PopupBody>
                </BasePopup>
            </PopupConteiner>
            
        </>
    )
}