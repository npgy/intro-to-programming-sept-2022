import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  SongListSortOptions,
  SongSorterEvents,
} from '../../state/song-sorter.actions';
import { selectSortingBy } from '../../state';

@Component({
  selector: 'app-list-sorter',
  templateUrl: './list-sorter.component.html',
  styleUrls: ['./list-sorter.component.css'],
})
export class ListSorterComponent {
  sortingBy$ = this.store.select(selectSortingBy);
  constructor(private store: Store) {}

  setSortBy(payload: SongListSortOptions) {
    this.store.dispatch(SongSorterEvents.sort({ payload }));
  }
}
