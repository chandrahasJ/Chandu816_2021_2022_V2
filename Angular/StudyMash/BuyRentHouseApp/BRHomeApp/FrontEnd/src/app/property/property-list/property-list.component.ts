import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProperty } from 'src/app/models/IProperty.interface';
import { HousingService } from 'src/app/services/housing.service';



@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  propertyCollections: Array<IProperty>;
  SellRent = 1;
  constructor(private housingServices : HousingService, private activatedRoute: ActivatedRoute) {
    this.propertyCollections = [];
  }

  ngOnInit(): void {
      this.SellRent = (this.activatedRoute.snapshot.url.toString() == "" ? 1 : 2);
      this.housingServices.getAllProperties(this.SellRent).subscribe(data =>{
        this.propertyCollections = data;
      }, error =>{
        console.log(error);
      });
  }
}
