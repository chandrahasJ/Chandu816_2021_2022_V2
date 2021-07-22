import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
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
  //  @ViewChild('Form') addPropertyForm : NgForm | undefined;

  addPropertyForm! : FormGroup;

  propertyType: Array<string> = ['House','Apartment','Duplex'];
  furnishType: Array<string> = ['Fully Furnished','Semi Furnished','Un-Furnished'];
  yesNoType : Array<string> =['Yes','No'];
  mainEntranceArray : Array<string> = ['East', 'West', 'North', 'South'];
  BHKArray : Array<string> =['1','2','3','4','5'];

  nextButtonClicked : boolean = false;

  propertyView : IPropertyBase = {
    Id : 0,
    Name : '',
    Price : null,
    SellRent : 0,
    PType : '',
    FType : '',
    BHK : null,
    BuiltArea : null,
    City : '',
    RTM : 0
  };

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.createAddPropertyForm();
  }

  createAddPropertyForm(){
    this.addPropertyForm = this.formBuilder.group({
        BasicInfoTab : this.formBuilder.group({
          SellRent : ['1', Validators.required],
          PType : [null, Validators.required],
          Name : [null, [Validators.required, Validators.minLength]],
          BHK : [null, Validators.required],
          FType: [null, Validators.required],
          City: [null, Validators.required]
        }),
        PriceInfoTab : this.formBuilder.group({
          Price : ['', Validators.required],
          BuiltArea : ['', Validators.required],
          CarpetArea: [null],
          Security: [null],
          Maintenance : [null],
        }),
        AddressInfoTab : this.formBuilder.group({
          FloorNo :[null],
          TotalFloor : [null],
          Address :[null, Validators.required],
          Landmark : [null]
        }),
        OtherInfoTab : this.formBuilder.group({
          RTM : [null, Validators.required],
          PossessionOn: [null],
          AOP : [null],
          Gated : [null],
          MainEntrance : [null],
          Description :[null]
        })
    });
  }

  onBack(){
    this.router.navigate(['/']);
  }

  onSubmit(){
    this.nextButtonClicked = true;
    if( this.allTabsValid()){
      console.log(this.addPropertyForm);
      console.log("Congrats, your property has been listed successfully");
      this.nextButtonClicked = false;
    }
    else{
      console.log("Please review the form and provide all the required data.");
    }

  }

  selectTab(tabId: number, isCurrentTabValid : boolean) {
    this.nextButtonClicked = true;
    if(isCurrentTabValid){
      this.AddPropertyTabSet.tabs[tabId].active = true;
    }
  }

  allTabsValid() : boolean{
    if(this.BasicInfoTab.invalid){
      this.AddPropertyTabSet.tabs[0].active = true;
      return false;
    }

    if(this.PriceInfoTab.invalid){
      this.AddPropertyTabSet.tabs[1].active = true;
      return false;;
    }

    if(this.AddressInfoTab.invalid){
      this.AddPropertyTabSet.tabs[2].active = true;
      return false;;
    }

    if(this.OtherInfoTab.invalid){
      this.AddPropertyTabSet.tabs[3].active = true;
      return false;;
    }
    return true;
  }

  // //Getter Method
  get BasicInfoTab(){
    return this.addPropertyForm.controls.BasicInfoTab as FormGroup
  }

  get SellRent(){
    return this.BasicInfoTab.controls.SellRent as FormControl;
  }

  get Name(){
    return this.BasicInfoTab.controls.Name as FormControl;
  }

  get PType(){
    return this.BasicInfoTab.controls.PType as FormControl;
  }

  get FType(){
    return this.BasicInfoTab.controls.FType as FormControl;
  }

  get City(){
    return this.BasicInfoTab.controls.City as FormControl;
  }

  get BHK(){
    return this.BasicInfoTab.controls.BHK as FormControl;
  }

  get PriceInfoTab(){
    return this.addPropertyForm.controls.PriceInfoTab as FormGroup
  }

  get Price(){
    return this.PriceInfoTab.controls.Price as FormControl;
  }

  get BuiltArea(){
    return this.PriceInfoTab.controls.BuiltArea as FormControl;
  }

  get AddressInfoTab(){
    return this.addPropertyForm.controls.AddressInfoTab as FormGroup
  }

  get Address(){
    return this.AddressInfoTab.controls.Address as FormControl;
  }

  get OtherInfoTab(){
    return this.addPropertyForm.controls.OtherInfoTab as FormGroup
  }

  get RTM(){
    return this.OtherInfoTab.controls.RTM as FormControl;
  }

  //Getter Method
}
