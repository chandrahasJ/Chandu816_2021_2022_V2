import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  propertyCollections: Array<any> = [
    {
      Id: 1,
      Name: 'Birla House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 2,
      Name: 'C House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 3,
      Name: 'P House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 4,
      Name: 'A House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 5,
      Name: 'B House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 6,
      Name: 'AB House',
      Type: 'House',
      Price: 12000,
    },
    {
      Id: 7,
      Name: 'Chandrika House',
      Type: 'House',
      Price: 12000000,
    },
    {
      Id: 8,
      Name: 'Yogesh House',
      Type: 'Villa',
      Price: 12000,
    },
    {
      Id: 9,
      Name: 'Sandeep House',
      Type: 'Apartment',
      Price: 12000,
    },
    {
      Id: 10,
      Name: 'Public House',
      Type: 'House',
      Price: 12000,
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
