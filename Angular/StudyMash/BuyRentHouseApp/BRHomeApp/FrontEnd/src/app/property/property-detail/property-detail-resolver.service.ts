import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Property } from 'src/app/models/Property';
import { HousingService } from 'src/app/services/housing.service';

@Injectable({
  providedIn: 'root'
})
export class PropertyDetailResolverService implements Resolve<Property> {

  constructor(private housingService : HousingService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
     Property | Observable<Property> | Promise<Property> {
      const id = route.params['propertyid'] ;
     return this.housingService.getProperty(id);
  }
}
