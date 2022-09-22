import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { SongSummaryModel } from '../../models';
import { selectSongSummaryModel } from '../../state';

@Component({
  selector: 'app-songs-summary',
  templateUrl: './songs-summary.component.html',
  styleUrls: ['./songs-summary.component.css'],
})
export class SongsSummaryComponent {
  model$: Observable<SongSummaryModel> = this.store.select(
    selectSongSummaryModel
  );
  constructor(private store: Store) {}
}
