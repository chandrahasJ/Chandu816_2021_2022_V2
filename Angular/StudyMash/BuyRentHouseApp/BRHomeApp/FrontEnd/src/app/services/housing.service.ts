import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IProperty } from '../models/IProperty.interface';
import { Property } from '../models/Property';


@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private httpClient: HttpClient) { }


  getAllProperties(SellRent? : number) : Observable<Property[]> {
    return this.httpClient.get<Property[]>('data/properties.json').pipe(
      map(data => {
        const propertiesArray: Array<Property> = [];
        const localStorageProperties = JSON.parse(localStorage.getItem('newProperty')!);
        if(localStorageProperties){
          for (let key in localStorageProperties) {
            if(SellRent){
              if (Object.prototype.hasOwnProperty.call(localStorageProperties, key)
                  && localStorageProperties[key].SellRent === SellRent ) {

                const element = localStorageProperties[key];
                propertiesArray.push(element);
              }
            }
            else{
              if (Object.prototype.hasOwnProperty.call(localStorageProperties, key)  ) {
                const element = localStorageProperties[key];
                propertiesArray.push(element);
              }
            }
          }
        }

        for (const key in data) {
          if(SellRent){
            if (Object.prototype.hasOwnProperty.call(data, key)
              && data[key].SellRent === SellRent ) {
              //I was getting error stating that
              //no index signature with a parameter of type 'string' was found on type 'object'.ts(7053) in map
              //This error is resolved by providing get with get<IProperty[]>
              const element = data[key];
              propertiesArray.push(element);
            }
          }
          else{
            if (Object.prototype.hasOwnProperty.call(data, key)  ) {
              const element = data[key];
              propertiesArray.push(element);
            }
          }
        }
        return propertiesArray;
      })
    );
  }

  addProperty(property : Property){
    let newProperties = [];
    const localData = JSON.parse(localStorage.getItem('newProperty')!);
    if(localData){
      newProperties = [property , ...localData]
    }
    else{
      newProperties = [property]
    }
    localStorage.setItem('newProperty', JSON.stringify(newProperties));
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
    return this.getAllProperties().pipe(
      map( propertiesArray  => {
        return propertiesArray.find(p => p.Id === Id) as Property;
      })
    )
  }

}
