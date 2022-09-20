import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SongListItem } from '../../models';

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
  constructor(private client: HttpClient) {}

  addThisSong() {
    this.client
      .post<SongListItem>(environment.apiUrl + 'songs', this.form.value)
      .pipe(tap((r) => console.log(r)))
      .subscribe();
  }
}

type CreateForm = {
  title: FormControl<string>;
  artist: FormControl<string>;
  album: FormControl<string>;
};
