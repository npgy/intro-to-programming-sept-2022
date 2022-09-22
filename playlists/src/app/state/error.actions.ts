import { createActionGroup, emptyProps, props } from '@ngrx/store';
import * as fromErrors from './reducers/errors.reducer';

export const ErrorEvents = createActionGroup({
  source: 'app errors',
  events: {
    errorDismissed: props<{ payload: fromErrors.ErrorsState }>(),
  },
});
