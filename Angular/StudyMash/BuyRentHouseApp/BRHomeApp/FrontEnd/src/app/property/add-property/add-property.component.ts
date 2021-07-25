import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IPropertyBase } from 'src/app/models/IPropertyBase.interface';
import { Property } from 'src/app/models/Property';
import { AlertifyService } from 'src/app/services/alertify.service';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('AddPropertyTabSet', { static: false }) AddPropertyTabSet!: TabsetComponent;
  //  @ViewChild('Form') addPropertyForm : NgForm | undefined;

  property = new Property();

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

  constructor(private formBuilder: FormBuilder,
             private router: Router,
             private alertifyService : AlertifyService,
             private houseService: HousingService ) { }

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
      this.mapProperty();
      console.log(this.property);
      this.houseService.addProperty(this.property);
      console.log(this.addPropertyForm);

      if(this.SellRent.value === '2'){
        this.router.navigate(['/rent-property']);
      }
      else{
        this.router.navigate(['/']);
      }
      this.alertifyService.success("Congrats, your property has been listed successfully");
      this.nextButtonClicked = false;
    }
    else{
      this.alertifyService.error("Please review the form and provide all the required data.");
    }

  }

  mapProperty() : void{
    this.property.Id = this.houseService.generateNewPropertyId();
    this.property.Name = this.Name.value;
    this.property.Price = this.Price.value;
    this.property.SellRent = +this.SellRent.value;
    this.property.PType = this.PType.value;
    this.property.FType = this.FType.value;
    this.property.BuiltArea = this.BuiltArea.value;
    this.property.BHK = this.BHK.value;
    this.property.City = this.City.value;
    this.property.RTM = this.RTM.value;
    this.property.Address = this.Address.value;
    this.property.CarpetArea = this.CarpetArea?.value;
    this.property.Address2 = this.Landmark?.value;
    this.property.FloorNo = this.FloorNo?.value;
    this.property.TotalFloor = this.TotalFloor?.value;
    this.property.AOP = this.AOP?.value;
    this.property.Possession = this.Possession?.value;
    this.property.MainEntrance = this.MainEntrance?.value;
    this.property.Security = this.Security?.value;
    this.property.Gated = this.Gated?.value;
    this.property.Maintenance = this.Maintenance?.value;
    this.property.Description = this.Description?.value;
    this.property.PostedOn = new Date().toString();
    this.property.PostedBy = "CJ";
  }

  selectTab(tabId: number, isCurrentTabValid : boolean) {
    this.nextButtonClicked = true;
    if(isCurrentTabValid){
      this.AddPropertyTabSet.tabs[tabId].active = true;
      this.nextButtonClicked = false;
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

  //#region Getter Method
    //#region BasicInfoTab
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
    //#endregion BasicInfoTab

    //#region PriceInfoTab
    get PriceInfoTab(){
      return this.addPropertyForm.controls.PriceInfoTab as FormGroup
    }

    get Price(){
      return this.PriceInfoTab.controls.Price as FormControl;
    }

    get BuiltArea(){
      return this.PriceInfoTab.controls.BuiltArea as FormControl;
    }

    get Maintenance(){
      return this.PriceInfoTab.controls.Maintenance as FormControl;
    }

    get Security(){
      return this.PriceInfoTab.controls.Security as FormControl;
    }

    get CarpetArea(){
      return this.PriceInfoTab.controls.CarpetArea as FormControl;
    }
    //#endregion PriceInfoTab

    //#region  AddressInfoTab
    get AddressInfoTab(){
      return this.addPropertyForm.controls.AddressInfoTab as FormGroup
    }

    get Address(){
      return this.AddressInfoTab.controls.Address as FormControl;
    }

    get Landmark(){
      return this.AddressInfoTab.controls.Landmark as FormControl;
    }

    get FloorNo(){
      return this.AddressInfoTab.controls.FloorNo as FormControl;
    }

    get TotalFloor(){
      return this.AddressInfoTab.controls.TotalFloor as FormControl;
    }
    //#endregion AddressInfoTab

    //#region OtherInfoTab
    get OtherInfoTab(){
      return this.addPropertyForm.controls.OtherInfoTab as FormGroup
    }

    get RTM(){
      return this.OtherInfoTab.controls.RTM as FormControl;
    }

    get Gated(){
      return this.OtherInfoTab.controls.Gated as FormControl;
    }

    get Description(){
      return this.OtherInfoTab.controls.Description as FormControl;
    }

    get AOP(){
      return this.OtherInfoTab.controls.AOP as FormControl;
    }

    get Possession(){
      return this.OtherInfoTab.controls.Possession as FormControl;
    }

    get MainEntrance(){
      return this.OtherInfoTab.controls.MainEntrance as FormControl;
    }
    //#endregion OtherInfoTab
  //#endregion Getter Method
}
