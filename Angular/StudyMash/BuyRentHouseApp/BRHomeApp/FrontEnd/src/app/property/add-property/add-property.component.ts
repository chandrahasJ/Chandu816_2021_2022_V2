import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IKeyValuePair } from 'src/app/models/IKeyValuePair';
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

  propertyType?: IKeyValuePair[];
  furnishType?: IKeyValuePair[];
  yesNoType : Array<string> =['Yes','No'];
  mainEntranceArray : Array<string> = ['East', 'West', 'North', 'South'];
  BHKArray : Array<number> =[1,2,3,4,5];
  cityArray!: any[];

  nextButtonClicked : boolean = false;

  propertyView : IPropertyBase = {
    id : 0,
    name : '',
    price : null,
    sellRent : 0,
    propertyType : '',
    furnishingType : '',
    bhk : null,
    builtArea : null,
    city : '',
    readyToMove : false
  };

  constructor(private formBuilder: FormBuilder,
             private router: Router,
             private alertifyService : AlertifyService,
             private houseService: HousingService ) { }

  ngOnInit(): void {
    this.getDataFromAPI();
    this.createAddPropertyForm();
  }

  getDataFromAPI(){
    this.houseService.getAllCities().subscribe(
      data =>{
        this.cityArray = data;
        console.log(data);
      }
    );

    this.houseService.getFurnishingType().subscribe(
      data => {
        this.furnishType = data;
        console.log(data);
      }
    );

    this.houseService.getPropertyTypes().subscribe(
      data => {
        this.propertyType = data;
        console.log(data);
      }
    );
  }

  createAddPropertyForm(){
    this.addPropertyForm = this.formBuilder.group({
        BasicInfoTab : this.formBuilder.group({
          SellRent : ['1', Validators.required],
          PType : [null, Validators.required],
          Name : [null, [Validators.required, Validators.minLength]],
          BHK : [null, Validators.required],
          FType: [null, Validators.required],
          City: ['', Validators.required]
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
    this.property.id = this.houseService.generateNewPropertyId();
    this.property.name = this.Name.value;
    this.property.price = this.Price.value;
    this.property.sellRent = +this.SellRent.value;
    this.property.propertyType = this.PType.value;
    this.property.furnishingType = this.FType.value;
    this.property.builtArea = this.BuiltArea.value;
    this.property.bhk = this.BHK.value;
    this.property.city = this.City.value;
    this.property.readyToMove = this.RTM.value;
    this.property.address = this.Address.value;
    this.property.carpetArea = this.CarpetArea?.value;
    this.property.address2 = this.Landmark?.value;
    this.property.floorNo = this.FloorNo?.value;
    this.property.totalFloors = this.TotalFloor?.value;
    this.property.age = this.AOP?.value;
    this.property.estPossessionOn = this.Possession?.value;
    this.property.mainEntrance = this.MainEntrance?.value;
    this.property.security = this.Security?.value;
    this.property.gated = this.Gated?.value;
    this.property.maintenance = this.Maintenance?.value;
    this.property.description = this.Description?.value;
    this.property.postedOn = new Date().toString();
    this.property.postedBy = "CJ";
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

  convertStringToNumber(stringData:string) :number{
    return parseInt(stringData);
  }

  convertYesNoToBoolean(stringData:string):boolean{
    return stringData == "Yes" ? true : false;
  }
}
