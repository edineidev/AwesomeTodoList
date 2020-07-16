import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { TodoService } from '../todo.service';
import { Todo } from 'src/models/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.sass'],
})
export class TodoListComponent implements OnInit {
  public form: FormGroup;
  public todos: Todo[];

  constructor(private fb: FormBuilder, private todoService: TodoService) {
    this.form = this.fb.group({
      title: ['', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(60),
      ])]
    });
  }

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.todoService.getAll().subscribe(todos => this.todos = todos);
    console.log(this.todos);
  }

  addTodo() {
    const title = this.form.get('title').value;
    this.todoService.post(title).subscribe(console.log);
    this.form.reset();
    this.load();
  }

  markDone(event, id){
    console.log(event.target.checked);
    if (event.target.checked) {
      this.todoService.markDone(id).subscribe(console.log);
    } else {
      this.todoService.markUnDone(id).subscribe(console.log);
    }

  }

}
