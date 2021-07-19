import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {  Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IPropertyBase } from 'src/app/models/IPropertyBase.interface';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('AddPropertyTabSet', { static: false }) AddPropertyTabSet!: TabsetComponent;
  @ViewChild('Form') addPropertyForm : NgForm | undefined;
  
  propertyType: Array<string> = ['House','Apartment','Duplex'];
  furnishType: Array<string> = ['Fully Furnished','Semi Furnished','Un-Furnished'];
  yesNoType : Array<string> =['Yes','No'];
  mainEntranceArray : Array<string> = ['East', 'West', 'North', 'South'];

  propertyView : IPropertyBase = {
    Id : 0,
    Name : '',
    Price : 0,
    SellRent : 0,
    PType : '',
    FType : '',
    BHK : 0,
    BuiltArea : 0,
    City : '',
    RTM : 0
  };

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onBack(){
    this.router.navigate(['/']);
  }

  onSubmit(){
    console.log(this.addPropertyForm)
  }

  selectTab(tabId: number) {
    this.AddPropertyTabSet.tabs[tabId].active = true;
  }
}
