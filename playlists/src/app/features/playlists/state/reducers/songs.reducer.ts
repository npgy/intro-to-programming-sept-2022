import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, Action, on } from '@ngrx/store';
import { SongDocuments, SongEvents } from '../songs.actions';

export interface SongEntity {
  id: string;
  title: string;
  artist: string;
  album?: string;
}

export interface SongState extends EntityState<SongEntity> {}

export const adapter = createEntityAdapter<SongEntity>();

const initialState = adapter.getInitialState();

export const reducer = createReducer(
  initialState,
  on(SongEvents.titlechangerequested, (s, a) =>
    adapter.updateOne(
      {
        id: a.payload.id,
        changes: {
          album: a.payload.newTitle,
        },
      },
      s
    )
  ),
  on(SongDocuments.songs, (s, a) => adapter.setAll(a.payload, s)),
  on(SongDocuments.song, (s, a) => adapter.addOne(a.payload, s))
);
