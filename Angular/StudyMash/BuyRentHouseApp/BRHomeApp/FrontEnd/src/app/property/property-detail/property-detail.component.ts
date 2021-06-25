import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  propertyId : number = -0;
  constructor(private activateddRoute : ActivatedRoute, private router :Router) { }

  ngOnInit(): void {
    //This code only works once when the come from other pages
    //this.propertyId = +this.activateddRoute.snapshot.params['propertyid'];

    // This code works this user click from any where as it is a observable
    this.activateddRoute.params.subscribe(params => {
      this.propertyId = +params['propertyid'];
    });

  }

  onSelectNextPage(){
    this.propertyId += 1;
    this.router.navigate(['/property-detail/',this.propertyId]);
  }

  onSelectBackPage(){
    this.propertyId -= 1;
    if(this.propertyId < 1){
      this.propertyId = 1;
      return;
    }
    else{
      this.router.navigate(['/property-detail/',this.propertyId]);
    }
  }

}
