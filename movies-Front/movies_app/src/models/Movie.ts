export interface ExternalIds {
    imdb_id: string;
    facebook_id: string;
    instagram_id: string;
    twitter_id: string;
}

export interface Similar {
    id: number;
    title: string;
}

export interface Director {
    id: number;
    name: string;
}

export interface Writer {
    id: number;
    name: string;
}

export interface Cast {
    id: number;
    name: string;
}

export interface Movie {
    budget: number;
    genres: string[];
    homepage: string;
    id: number;
    original_language: string;
    overview: string;
    popularity: number;
    poster_path: string;
    release_date: string;
    revenue: number;
    runtime: number;
    tagline: string;
    title: string;
    vote_average: number;
    vote_count: number;
    external_ids: ExternalIds;
    similar: Similar[];
    certification: string;
    directors: Director[];
    writers: Writer[];
    cast: Cast[];
    trailer_yt: string;
}
