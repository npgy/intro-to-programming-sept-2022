import { createReducer, on } from '@ngrx/store';
import * as fromSongsEvents from '../../features/playlists/state/songs.actions';
import * as fromErrors from '../../state/error.actions';

export interface ErrorsState {
  hasErrors: boolean;
  message?: string;
}

const initialState: ErrorsState = {
  hasErrors: false,
};

export const reducer = createReducer(
  initialState,
  on(fromSongsEvents.SongEvents.error, (s, a) => ({
    hasErrors: true,
    message: a.payload.message,
  })),
  on(fromErrors.ErrorEvents.errordismissed, (s, a) => ({
    hasErrors: a.payload.hasErrors,
  }))
);
