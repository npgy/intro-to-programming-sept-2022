import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { SongCreate } from '../../models';
import { SongEvents } from '../../state/songs.actions';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent {
  form = new FormGroup<CreateForm>({
    title: new FormControl<string>('', { nonNullable: true }),
    artist: new FormControl<string>('', { nonNullable: true }),
    album: new FormControl<string>('', { nonNullable: true }),
  });
  constructor(private store: Store) {}

  addThisSong(theInputThatShouldHaveTheFoccus: HTMLInputElement) {
    const song: SongCreate = {
      title: this.form.controls.title.value,
      artist: this.form.controls.artist.value,
      album: this.form.controls.album.value,
    };
    this.store.dispatch(SongEvents.added({ payload: song }));
    this.form.reset();
    theInputThatShouldHaveTheFoccus.focus();
  }
}

type CreateForm = {
  title: FormControl<string>;
  artist: FormControl<string>;
  album: FormControl<string>;
};
