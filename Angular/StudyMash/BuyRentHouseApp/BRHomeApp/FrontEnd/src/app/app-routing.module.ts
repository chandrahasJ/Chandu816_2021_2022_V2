import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { PropertyListComponent } from './property/property-list/property-list.component';

const routes: Routes = [
  { path : '', component : PropertyListComponent},
  { path : 'rent-property', component : PropertyListComponent},
  { path : 'add-property', component : AddPropertyComponent},
  { path : 'property-detail/:propertyid', component : PropertyDetailComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
