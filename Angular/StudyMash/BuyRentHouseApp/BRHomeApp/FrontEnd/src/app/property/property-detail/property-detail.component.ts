import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { Property } from 'src/app/models/Property';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  propertyId : number = -0;
  property : Property ;

  constructor(private activateddRoute : ActivatedRoute,
             private router :Router,
             private housingService: HousingService) {
                this.property = new Property();

             }

  ngOnInit(): void {
    //This code only works once when the come from other pages
    //this.propertyId = +this.activateddRoute.snapshot.params['propertyid'];

    // This code works this user click from any where as it is a observable
    // this.activateddRoute.params.subscribe(params => {
    //   this.propertyId = +params['propertyid'];
    //   this.housingService.getProperty(this.propertyId).subscribe(
    //     (data) => {
    //       this.property = data;
    //     }
    //   );
    // });

    this.activateddRoute.data.subscribe(
      (data ) => {
        this.property = data['propertyInformation'];
      }
    );

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
