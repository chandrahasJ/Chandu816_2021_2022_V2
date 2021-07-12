import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {  Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('AddPropertyTabSet', { static: false }) AddPropertyTabSet!: TabsetComponent;
  @ViewChild('Form') addPropertyForm : NgForm | undefined;
  
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
