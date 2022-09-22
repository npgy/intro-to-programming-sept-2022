import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { selectErrorMessage, selectHasAnError } from 'src/app/state';
import { ErrorEvents } from 'src/app/state/error.actions';

@Component({
  selector: 'app-error-display',
  templateUrl: './error-display.component.html',
  styleUrls: ['./error-display.component.css'],
})
export class ErrorDisplayComponent {
  hasError$: Observable<boolean> = this.store.select(selectHasAnError);
  message$: Observable<string | undefined> =
    this.store.select(selectErrorMessage);
  constructor(private store: Store) {}

  dismissErrorMessage() {
    this.store.dispatch(
      ErrorEvents.errordismissed({ payload: { hasErrors: false } })
    );
  }
}
