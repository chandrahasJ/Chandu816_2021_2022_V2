import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProperty } from 'src/app/models/IProperty.interface';
import { AlertifyService } from 'src/app/services/alertify.service';
import { HousingService } from 'src/app/services/housing.service';



@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css'],
})
export class PropertyListComponent implements OnInit {
  propertyCollections: Array<IProperty>;
  SellRent = 1;
  SearchCity = '';
  City = '';
  SortByParams = 'Select';
  SortByDirection = 'asc';

  constructor(private housingServices : HousingService,
              private activatedRoute: ActivatedRoute,
              private alertyService: AlertifyService) {
    this.propertyCollections = [];
  }

  ngOnInit(): void {
      this.SellRent = (this.activatedRoute.snapshot.url.toString() == "" ? 1 : 2);
      this.housingServices.getAllProperties(this.SellRent).subscribe(data =>{
        this.propertyCollections = data;
        const newPropertyData  = localStorage.getItem('newProperty');
        if(newPropertyData){
          const newProperty = JSON.parse(newPropertyData);
          if(newProperty.SellRent === this.SellRent){
            this.propertyCollections = [newProperty, ...this.propertyCollections];
          }
        }

      }, error =>{
        console.log(error);
      });
  }

  onSearchCityFilterClick(){
    this.SearchCity = this.City;
  }

  onSearchCityFilterClear(){
    this.SearchCity = '';
    this.City = '';
  }

  onSortDirection(){
    if(this.SortByParams === 'Select'){
      this.alertyService.error('Select Sort By option');
      return;
    }
    if(this.SortByDirection === 'asc'){
      this.SortByDirection = 'desc';
    }
    else{
      this.SortByDirection = 'asc';
    }
  }
}
