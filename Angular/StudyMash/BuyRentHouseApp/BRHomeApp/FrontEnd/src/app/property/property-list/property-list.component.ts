import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { IProperty } from '../IProperty.interface';


@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  propertyCollections: Array<IProperty>;

  constructor(private housingServices : HousingService) {
    this.propertyCollections = [];
  }

  ngOnInit(): void {
      this.housingServices.getAllProperties().subscribe(data =>{
        this.propertyCollections = data;
      }, error =>{
        console.log(error);
      });
  }
}
