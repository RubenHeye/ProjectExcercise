import { CRow, CCol, CCard, CCardImage, CCardBody, CCardTitle, CCardText } from "@coreui/react";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import styled from "styled-components";
import { getHttpRequest } from "../api/api-client";
import { Movie } from "../models/Movie";
import imgTest from '../imgTest.jpg'
import '@coreui/coreui/dist/css/coreui.min.css'
import ListItem from "../components/movies/ListItem";
import ControlledCarousel from "../components/utils/ControlledCarousel";
import { Carousel, Stack, Card, Button } from "react-bootstrap";


const MovieDetails  = () => {
    const { id } = useParams();
    const [movieDetail, setMovieDetail] = useState<Movie>();
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [index, setIndex] = useState(0);

    const handleSelect = (selectedIndex:any, e:any) => {
      setIndex(selectedIndex);
    };

    useEffect(() => {
        const fetchData = async () => {
            const response = await getHttpRequest(`/markets/${id}`);
            if (!response.error) {
                const result = response.data.result;
                setMovieDetail(result);
            }
            setIsLoading(false);
        }
        fetchData();

      }, [id]);
    
    const [movies, setMovies] = useState<Movie[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getHttpRequest("/markets");
            if (!response.error) {
                const result = response.data.result;
                setMovies(result);
                console.log(result);
            }
            setIsLoading(false);
        }

        fetchData();
        
      }, []);

    return <Container> 
        {isLoading ? (
            <div>loading...</div>
        ) : (
            <>
            <Container>
                <CCard className="mb-3" style={{ maxWidth: '100%' }}>
                    <CRow className="g-0">
                        <CCol md={5}>
                        <CCardImage src={imgTest} height="100%" width=""/>
                        </CCol>
                        <CCol md={7}>
                        <CCardBody>
                            <CCardTitle>Card title</CCardTitle>
                            <CCardText>
                            This is a wider card with supporting text below as a natural lead-in to additional
                            content. This content is a little bit longer.
                            </CCardText>
                            <CCardText>
                            <small className="text-medium-emphasis">Last updated 3 mins ago</small>
                            </CCardText>
                        </CCardBody>
                        </CCol>
                    </CRow>
                </CCard>
                {/* <ListStyle>
                <Carousel style={{ height: 500 }} activeIndex={index} indicators={false} onSelect={handleSelect}>
                    {movies.map((data:any, i) => (
                    <Carousel.Item>
                        <Stack direction="horizontal" className="h-100 justify-content-center align-items-center" gap={3}>             
                            <ListItem key={i} text={i}  name={data.name} volume={data.volumeUsd24h}/>
                            </Stack>
                        </Carousel.Item>))}
                    </Carousel>
                </ListStyle> */}
            </Container>
            <div>
      <h1 className="text-center fw-bold my-5">
        User Reviews ({movies.length})
      </h1>
      <div className="bg-dark bg-opacity-25 container-fluid">
        <Carousel style={{ height: 500 }}>
          {movies.map((review, i) => (
            <Carousel.Item style={{ height: 500 }}>
              <Stack
                direction="horizontal"
                className="h-100 justify-content-center align-items-center"
                gap={3}
              >
                <ListItem key={i} text={i}  name={review.id} volume={review.budget}/>
              </Stack>
            </Carousel.Item>
          ))}
        </Carousel>
      </div>
    </div>
            </>
        )}
        </Container>
};

export default MovieDetails;

const Container = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    flex-direction: column;
`

const ListStyle = styled.div`
    padding: 1em 1em;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
    gap: 10px;
    justify-content: space-around;
`