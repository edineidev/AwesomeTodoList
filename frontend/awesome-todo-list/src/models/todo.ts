export class Todo {
  id:number;
  name:string;
  done?:Date;

  constructor(id:number, name:string, done?:Date) {
    this.id = id;
    this.name = name;
    this.done = done;
  }
}
