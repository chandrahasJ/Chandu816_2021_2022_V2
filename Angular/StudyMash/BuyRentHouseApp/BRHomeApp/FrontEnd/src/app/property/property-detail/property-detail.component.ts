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
    this.activateddRoute.params.subscribe(params => {
      this.propertyId = +params['propertyid'];
      this.housingService.getProperty(this.propertyId).subscribe(
        (data) => {
          this.mapProperty(data);
        }
      );

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

  mapProperty(propertyInfo : any) : void{
    console.log(propertyInfo)
    this.property.Id = propertyInfo.Id;
    this.property.Name = propertyInfo.Name;
    this.property.Price = propertyInfo.Price;
    this.property.SellRent = +propertyInfo.SellRent;
    this.property.PType = propertyInfo.PType;
    this.property.FType = propertyInfo.FType;
    this.property.BuiltArea = propertyInfo.BuiltArea;
    this.property.BHK = propertyInfo.BHK;
    this.property.City = propertyInfo.City;
    this.property.RTM = propertyInfo.RTM;
    this.property.Address = propertyInfo.Address;
    this.property.CarpetArea = propertyInfo.CarpetArea!;
    this.property.Address2 = propertyInfo.Landmark!;
    this.property.FloorNo = propertyInfo.FloorNo!;
    this.property.TotalFloor = propertyInfo.TotalFloor!;
    this.property.AOP = propertyInfo.AOP!;
    this.property.Possession = propertyInfo.Possession!;
    this.property.MainEntrance = propertyInfo.MainEntrance!;
    this.property.Security = propertyInfo.Security!;
    this.property.Gated = propertyInfo.Gated!;
    this.property.Maintenance = propertyInfo.Maintenance!;
    this.property.Description = propertyInfo.Description!;
    this.property.PostedOn = propertyInfo.PostedOn;
    this.property.PostedBy = propertyInfo.PostedBy;
    this.property.Image = propertyInfo.Image!;
  }

}
