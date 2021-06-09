import { Component, OnInit } from '@angular/core';
import { of, Observable } from 'rxjs';

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
  styleUrls: ['./view-users.component.scss']
})
export class ViewUsersComponent implements OnInit {

  contacts$ : any;
  users : any;
  userStatus : any;

  constructor() { }

  ngOnInit(): void {
    //Eg : 1
    this.users = ['Chandu', 'Hello', 'Compunding','IWillBeBecomeBetterProgrammer'];

    this.contacts$ = of(this.users); //of is used create observables
    console.log(this.contacts$);

    //Eg :2
    //Creating observables using new Observables keywords
    new Observable(observer => {

        setTimeout(() => {
          observer.next('In Progress');
        }, 2000);

        setTimeout(() => {
          observer.next('In Pending Mode');
        }, 4000);

        setTimeout(() => {
          observer.next('In Still in Pending Mode');
        }, 6000);

        setTimeout(() => {
          observer.next('Completed');
        }, 8000);

    }).subscribe(data => {
      this.userStatus = data;
    },error => {
      console.log(error)
    });

  }

}
