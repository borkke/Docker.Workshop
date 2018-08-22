import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Note } from './note';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  constructor(private http: HttpClient) { }

  getNotes():Observable<Note[]>{
    return this.http.get<Note[]>(environment.notesApi).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }

  getNoteById(id: number): Observable<Note | undefined>{
    return this.http.get<Note>(environment.notesApi + id).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }

  getUsers():Observable<User[]>{
    return this.http.get<User[]>(environment.usersApi).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }

  getUserById(id: number): Observable<User | undefined>{
    return this.http.get<User>(environment.usersApi + id).pipe(
      tap(data => console.log(data)),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
