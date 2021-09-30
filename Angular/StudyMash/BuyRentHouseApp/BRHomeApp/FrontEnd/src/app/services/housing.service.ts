import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Property } from '../models/Property';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseUrl = environment.baseUrl;
  constructor(private httpClient: HttpClient) { }


  getAllProperties(SellRent? : number) : Observable<Property[]> {
    return this.httpClient.get<Property[]>(this.baseUrl+'/property/list/'+SellRent?.toString());
  }

  addProperty(property : Property){

  }


  generateNewPropertyId(){
    let propertyId = 0;

    if(localStorage.getItem('PID')){
      propertyId = +localStorage.getItem('PID')! + 1;
      localStorage.setItem('PID', String(propertyId));
      return propertyId;
    }else{
      propertyId = 101;
      localStorage.setItem('PID', String(propertyId));
      return propertyId;
    }
  }

  getProperty(Id : number) : Observable<Property>{
    return this.getAllProperties(1).pipe(
      map( propertiesArray  => {
        return propertiesArray.find(p => p.id == Id) as Property;
      })
    )
  }

  getAllCities() : Observable<string[]>{
    return this.httpClient.get<string[]>(this.baseUrl+'/City');
  }
}
