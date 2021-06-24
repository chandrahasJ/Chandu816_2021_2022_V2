import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  propertyId : number = -0;
  constructor(private activateddRoute : ActivatedRoute) { }

  ngOnInit(): void {
    this.propertyId = this.activateddRoute.snapshot.params['propertyid']
  }

}
