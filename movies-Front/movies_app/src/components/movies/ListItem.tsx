import { CCard, CCardImage, CCardBody, CCardTitle, CCardText } from "@coreui/react";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import imgTest from '../../imgTest.jpg'
import '@coreui/coreui/dist/css/coreui.min.css'

const ListItem = (props:any) => {
    const navigate = useNavigate();
    /* return <ListItemStyle onClick={() => navigate(`/${props.name.replace("/", "%2F")}`)}>
        {props.name} - {props.volume}
    </ListItemStyle> */
    return (
        <GridItem>
            <CCard className="mb-3" style={{ width: '100%', backgroundColor: "gray", textAlign: "center", cursor: "pointer", color: "white", borderRadius: "20px" }} onClick={() => navigate(`/${props.name.replace("/", "%2F")}`)}>
                <CCardImage orientation="top" src={imgTest} width="100%" style={{borderRadius: "20px 20px 0 0"}}/>
                <CCardBody>
                        <CCardTitle>{props.name}</CCardTitle>
                        <CCardText>
                        {props.volume}
                        </CCardText>
                        <CCardText><small className="text-medium-emphasis">Last updated 3 mins ago</small></CCardText>
                </CCardBody>
            </CCard>
        </GridItem>
    )
}
  
export default ListItem;

const GridItem = styled.div`
    display: flex;
    align-items: center;
    justify-content: center;
`

/* const ListItemStyle = styled.div`
    padding: 10px;
    border: 2px solid White;
    border-radius: 20px;
    text-align: center;
    width: 90%;
    margin: 5px 2px;
    color: white;
    background-color: #1976D2;
` */

