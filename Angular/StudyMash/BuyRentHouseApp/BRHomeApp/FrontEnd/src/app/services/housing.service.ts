import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IProperty } from '../property/IProperty.interface';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private httpClient: HttpClient) { }

  getAllProperties() : Observable<IProperty[]> {
    return this.httpClient.get<IProperty[]>('data/properties.json').pipe(
      map(data => {
        const propertiesArray: Array<IProperty> = [];
        for (const key in data) {
          if (Object.prototype.hasOwnProperty.call(data, key)) {
            //I was getting error stating that
            //no index signature with a parameter of type 'string' was found on type 'object'.ts(7053) in map
            //This error is resolved by providing get with get<IProperty[]>
            const element = data[key];
            propertiesArray.push(element);
          }
        }
        return propertiesArray;
      })
    );
  }
}
