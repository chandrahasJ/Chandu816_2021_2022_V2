import { Route } from '@angular/compiler/src/core';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Property } from 'src/app/models/Property';
import { HousingService } from 'src/app/services/housing.service';

@Injectable({
  providedIn: 'root'
})
export class PropertyDetailResolverService implements Resolve<Property> {

  constructor(private router: Router, private housingService : HousingService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
      Observable<any> | Observable<Property> |  Property {
      const id = route.params['propertyid'] ;
     return this.housingService.getProperty(id).pipe(
       catchError(error => {
        this.router.navigate(['/']);
        return of(null);
       })
     );
  }
}
