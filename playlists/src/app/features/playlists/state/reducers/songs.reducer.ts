import { createReducer } from '@ngrx/store';

export interface SongEntity {
  id: string;
  title: string;
  artist: string;
  album?: string;
}

export interface SongState {
  songs: SongEntity[];
}

const initialState: SongState = {
  songs: [],
};

export const reducer = createReducer(initialState);
