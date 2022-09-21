import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import { SongListModel } from '../models';
import * as fromSongs from './reducers/songs.reducer';

export const FEATURE_NAME = 'playlist';

export interface PlaylistsState {
  songList: fromSongs.SongState;
}

export const reducers: ActionReducerMap<PlaylistsState> = {
  songList: fromSongs.reducer,
};

// 1. Create a Feature Selector
const selectFeature = createFeatureSelector<PlaylistsState>(FEATURE_NAME);

// 2. A selector per "branch" of the feature state
const selectSongListBranch = createSelector(selectFeature, (f) => f.songList);
// 3. Any "Helpers" (optional)

const selectSongListEntities = createSelector(
  selectSongListBranch,
  (b) => b.songs
);

// 4. The exported selectors that our components need:

// TODO: We need a function that returns the SongListModel
export const selectSongListModel = createSelector(
  selectSongListEntities,
  (songs) =>
    ({
      data: songs,
    } as SongListModel)
);
