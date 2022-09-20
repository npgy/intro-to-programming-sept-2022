import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SongListModel } from '../../models';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-song-list',
  templateUrl: './song-list.component.html',
  styleUrls: ['./song-list.component.css'],
})
export class SongListComponent {
  model: Observable<SongListModel>;

  constructor(private client: HttpClient) {
    this.model = this.client.get<SongListModel>(environment.apiUrl + 'songs');
  }
}
