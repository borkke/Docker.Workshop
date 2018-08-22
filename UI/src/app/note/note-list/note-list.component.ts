import { Component, OnInit } from '@angular/core';
import { Note } from '../../_shared/note';
import { BackendService } from '../../_shared/backend.service';

@Component({
  selector: 'notes-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.scss']
})
export class NoteListComponent implements OnInit {

  notes: Note[] = [];

  constructor(private backendService: BackendService) { }

  ngOnInit() {
    this.backendService.getNotes().subscribe(
      notes => {
        this.notes = notes
      },
      error => console.error(<any>error)
    )
  }

}
