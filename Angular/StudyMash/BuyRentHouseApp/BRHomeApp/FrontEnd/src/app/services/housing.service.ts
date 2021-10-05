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
    return this.httpClient.get<Property>(this.baseUrl+'/property/details/'+Id?.toString());
  }

  getAllCities() : Observable<string[]>{
    return this.httpClient.get<string[]>(this.baseUrl+'/City');
  }

  getPropertyAge(dateofEstablishment: string): string
    {
        const today = new Date();
        const estDate = new Date(dateofEstablishment);
        let age = today.getFullYear() - estDate.getFullYear();
        const m = today.getMonth() - estDate.getMonth();

        // Current month smaller than establishment month or
        // Same month but current date smaller than establishment date
        if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
            age --;
        }

        // Establshment date is future date
        if(today < estDate) {
            return '0';
        }

        // Age is less than a year
        if(age === 0) {
            return 'Less than a year';
        }

        return age.toString();
    }
}
