import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Person } from './person';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public people: Person[] = [
    { name: 'John Doe', age: 25, gender: 'Male' },
    { name: 'Jane Doe', age: 30, gender: 'Female' },
    { name: 'Bob Smith', age: 40, gender: 'Male' }
  ];

  personForm!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.personForm = this.fb.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      gender: ['', Validators.required]
    });
  }

  onSubmit() {
    const newPerson = this.personForm.value;
    this.people.push(newPerson);
    this.createForm();
  }

  onEdit(person: Person, index: number) {
    this.people[index] = person;
  }
}
