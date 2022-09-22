// A typescript interface that describes (For the typescript compiler) the data that is stored in the state
// that is neede by the app module.
import * as fromErrors from './reducers/errors.reducer';
import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';

export interface AppState {
  errors: fromErrors.ErrorsState;
}

// the functions that will handle the state for the application module. Since we have no state, there are no functions.
export const reducers: ActionReducerMap<AppState> = {
  errors: fromErrors.reducer,
};

const selectErrorsBranch =
  createFeatureSelector<fromErrors.ErrorsState>('errors');

// const selectErrorsBranch = (state: AppState) => state.errors;

export const selectHasAnError = createSelector(
  selectErrorsBranch,
  (b) => b.hasErrors
);

export const selectErrorMessage = createSelector(
  selectErrorsBranch,
  (b) => b.message
);
