import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailsComponent } from './user/user-details/user-details.component';
import { NoteDetailsComponent } from './note/note-details/note-details.component';
import { NoteListComponent } from './note/note-list/note-list.component';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    UserDetailsComponent,
    NoteDetailsComponent,
    NoteListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', pathMatch: 'full', redirectTo: 'notes'},
       {path: 'notes', component:NoteListComponent},
       {
         path: 'notes/:id',
         component: NoteDetailsComponent
       },
       {path: 'users', component:UserListComponent},
       {
         path: 'users/:id',
         component: UserDetailsComponent
       }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
