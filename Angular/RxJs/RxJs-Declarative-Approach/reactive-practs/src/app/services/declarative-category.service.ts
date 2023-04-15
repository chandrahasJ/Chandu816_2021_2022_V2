import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from '../models/Category';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DeclarativeCategoryService {

  constructor(private http: HttpClient) { }

  get category_data(){
    return this.http
            .get<{[id: string]: ICategory}>('https://project-rxjs-default-rtdb.firebaseio.com/categories.json')
            .pipe(map(categories => {
              let categoryData: ICategory[] = [];
              for (let id in categories) {
                categoryData.push({ ...categories[id], id})
              }
              return categoryData;
            }));
  }
}
