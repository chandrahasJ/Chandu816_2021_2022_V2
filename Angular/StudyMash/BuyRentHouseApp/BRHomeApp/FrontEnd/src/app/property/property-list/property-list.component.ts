import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';


@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  propertyCollections: any;

  constructor(private housingServices : HousingService) {
  }

  ngOnInit(): void {
      this.housingServices.getAllProperties().subscribe(data =>{
        this.propertyCollections = data;
      }, error =>{
        console.log(error);
      });
  }
}
