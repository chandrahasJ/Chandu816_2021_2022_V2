import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizePagesGuard } from './Guards/authorize-pages.guard';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailResolverService } from './property/property-detail/property-detail-resolver.service';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

const routes: Routes = [
  { path : '', component : PropertyListComponent},
  { path : 'rent-property', component : PropertyListComponent},
  {
    path : 'add-property',
    component : AddPropertyComponent,
    canActivate : [AuthorizePagesGuard]
  },
  {
     path : 'property-detail/:propertyid',
     component : PropertyDetailComponent,
     resolve : {propertyInformation : PropertyDetailResolverService}
  },
  { path : 'user/login', component : UserLoginComponent},
  { path : 'user/register', component : UserRegisterComponent},
  { path : '**', component : PropertyListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
