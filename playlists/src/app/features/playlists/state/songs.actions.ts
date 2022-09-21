import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { SongCreate } from '../models';
import { SongEntity } from './reducers/songs.reducer';

export const SongEvents = createActionGroup({
  source: 'playlists songs events',
  events: {
    added: props<{ payload: SongCreate }>(),
    addedToPlaylist: props<{ payload: { id: string } }>(),
    titleChangeRequested: props<{ payload: { id: string } }>(),
    featureEntered: emptyProps(),
  },
});

export const SongDocuments = createActionGroup({
  source: 'playlists song documents',
  events: {
    songs: props<{ payload: SongEntity[] }>(),
  },
});
