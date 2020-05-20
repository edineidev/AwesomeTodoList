import {throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import {catchError} from 'rxjs/operators';

import { Todo } from 'src/models/todo';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  private readonly API = 'https://localhost:5001/api/v1/todolist';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Todo[]>(this.API, httpOptions)
      .pipe(catchError(this.handleError.bind(this)));
  }

  post(name: string) {
    const body = JSON.stringify(name);
    return this.http.post<Todo>(this.API, body, httpOptions)
      .pipe(catchError(this.handleError.bind(this)));
  }

  handleError(errorResponse: HttpErrorResponse) {
    if (errorResponse.error instanceof ErrorEvent) {
      console.error('Client Side Error :', errorResponse.error.message);
    } else {
      console.error('Server Side Error :', errorResponse);
    }

    // return an observable with a meaningful error message to the end user
    return throwError('There is a problem with the service.We are notified & working on it.Please try again later.');
  }
}
