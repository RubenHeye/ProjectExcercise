import React, { useContext, useEffect, useState } from 'react';
import styled from 'styled-components';
import { getHttpRequest } from '../../api/api-client';
import { Movie } from '../../models/Movie';
import ListItem from './ListItem';

const List = () => {
    //const [count, setCount] = useState<number>(5);
    const [movie, setMovie] = useState<Movie[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getHttpRequest("/markets");
            if (!response.error) {
                const result = response.data.result;
                setMovie(result);
            }
            setIsLoading(false);
        }

        fetchData();
        
      }, []);

    return (
        <>
            {isLoading ? (<div>Loading ...</div>) : (
            <Container>
                <ListStyle>
                    {movie.map((data:any, i) => <ListItem key={i} text={i}  name={data.name} volume={data.volumeUsd24h}/>)}
                </ListStyle>
            </Container>)}
        </>
    );
}

export default List;

const ListStyle = styled.div`
    padding: 1em 1em;
    display: grid;
    grid-template-columns: 33% 33% 33%;
    gap: 10px;
`

const Container = styled.div`
    background-color: rgb(0,0,0);
`