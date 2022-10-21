import React from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import logo from '../../movieLogo5.png';

const Nav = () => {
    /* const navStyle = {
        backgroundColor: "#1976D2",
        height: "10%",
        width: "100%",
        display: "flex",
        justifyContent : "space-betweenx",
        alignItems: "center",
    } */

    const headerNavStyle = {
        color: "white",
    }

    const headerNavStyleWidth = {
        color: "white", 
        width:"12%",
        display: "flex",
        justifyContent: "center"
    }

    const navigate = useNavigate();

    return (
        <AppBarStyle>
            <Flex>
                <div style={headerNavStyleWidth}>
                    <img src={logo} alt='logo' width="50%" height="60px"></img>
                </div>
                <h3 style={headerNavStyle} onClick={() => navigate('/')}>MOVIES</h3>
                <h3 style={headerNavStyleWidth}>SEARCH</h3>
            </Flex>
        </AppBarStyle>
    );
}

export default Nav;

const AppBarStyle = styled.div`
    background-color: #000000dc;
    height: 5%;
    width: 100%;
    background-image: url('../../assets/back-img.svg');
`

const Flex = styled.div`
    display: flex;
    justify-content : space-between;
    align-items: center;
    margin: 0 0.5em;
`

/*<img src='https://assets-global.website-files.com/5f15b50525745912903311ad/5f15b505dd58c115cd49d484_Logo-full-white.svg' alt='logo' width="90%"></img>*/