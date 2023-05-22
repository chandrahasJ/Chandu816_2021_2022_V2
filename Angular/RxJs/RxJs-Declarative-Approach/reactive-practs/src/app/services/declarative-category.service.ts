import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from '../models/Category';
import { catchError, map, shareReplay } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DeclarativeCategoryService {
  constructor(private http: HttpClient) {}

  category_data$ = this.http
                      .get<{ [id: string]: ICategory }>(
                        'https://project-rxjs-default-rtdb.firebaseio.com/categories.json'
                      )
                      .pipe(
                        map((categories) => {
                          let categoryData: ICategory[] = [];
                          for (let id in categories) {
                            categoryData.push({ ...categories[id], id });
                          }
                          return categoryData;
                        }),
                        catchError(this.handleError),
                      );

  handleError(error: Error) {
    // Write your handle logic here
    return throwError(() => {
      return 'something is not right, try after some time.';
    });
  }
}
