import { Injectable } from '@angular/core';
import { Actions, createEffect } from '@ngrx/effects';
import { tap } from 'rxjs';

@Injectable()
export class SongEffects {
  loadSongs$ = createEffect(
    () => {
      return this.actions$.pipe(
        tap((a) => {
          console.log(a.type);
        })
      );
    },
    { dispatch: false }
  );
  constructor(private actions$: Actions) {}
}
