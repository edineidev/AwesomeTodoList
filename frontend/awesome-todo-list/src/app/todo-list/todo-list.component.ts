import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.sass'],
})
export class TodoListComponent implements OnInit {
  todos = [
    {
      id: 1,
      name: 'test',
      done: '2020-05-03T20:29:21.6988459',
    },
    {
      id: 2,
      name: 'test2',
      done: null,
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
