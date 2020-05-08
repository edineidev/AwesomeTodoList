import { Component, OnInit } from '@angular/core';

import { TodoService } from '../todo.service';
import { Todo } from 'src/models/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.sass'],
})
export class TodoListComponent implements OnInit {
  todos: Todo[];

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.todoService.getAll().subscribe(todos => this.todos = todos);
  }
}
