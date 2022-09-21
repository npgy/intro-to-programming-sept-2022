// A typescript interface that describes (For the typescript compiler) the data that is stored in the state
// that is neede by the app module.

import { ActionReducerMap } from '@ngrx/store';

export interface AppState {}

// the functions that will handle the state for the application module. Since we have no state, there are no functions.
export const reducers: ActionReducerMap<AppState> = {};
