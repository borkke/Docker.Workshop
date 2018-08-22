import { Component, OnInit } from '@angular/core';
import { BackendService } from '../../_shared/backend.service';
import { User } from '../../_shared/user';

@Component({
  selector: 'notes-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  users: User[] = [];

  constructor(private backendService: BackendService) { }

  ngOnInit() {
    this.backendService.getUsers().subscribe(
      notes => {
        this.users = notes
      },
      error => console.error(<any>error)
    )
  }

}
