import { useNavigate } from "react-router-dom";
import styled from "styled-components";

const NotFound  = () => {
    const navigate = useNavigate();
    return <Container> 
            <h1 style={{ fontSize: "40px" }}>404</h1>
            <h2>Page not found!</h2>
            <button onClick={() => navigate("/")}>HOME</button>
        </Container>
};

export default NotFound;

const Container = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 500px;
`