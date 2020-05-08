import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    return this.http.get<Todo[]>(this.API, httpOptions);
  }

  post(name: string) {
    return this.http.post<Todo>(this.API, name, httpOptions);
  }
}
