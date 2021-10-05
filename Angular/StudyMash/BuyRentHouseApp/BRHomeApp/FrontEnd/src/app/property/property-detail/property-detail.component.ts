import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/models/Property';
import { HousingService } from 'src/app/services/housing.service';

import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';


@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css'],
})
export class PropertyDetailComponent implements OnInit {
  propertyId : number = -0;
  property : Property ;

  galleryOptions!: NgxGalleryOptions[];
  galleryImages!: NgxGalleryImage[];

  constructor(private activateddRoute : ActivatedRoute,
             private router :Router,
             private housingService: HousingService) {
                this.property = new Property();

             }

  ngOnInit(): void {
    //This code only works once when the come from other pages
    //this.propertyId = +this.activateddRoute.snapshot.params['propertyid'];

    // This code works this user click from any where as it is a observable
    // this.activateddRoute.params.subscribe(params => {
    //   this.propertyId = +params['propertyid'];
    //   this.housingService.getProperty(this.propertyId).subscribe(
    //     (data) => {
    //       this.property = data;
    //     }
    //   );
    // });

    this.ngrXGalleryLoad();

    this.activateddRoute.data.subscribe(
      (data ) => {
        this.property = data['propertyInformation'];
      }
    );
    this.property.age = this.housingService
                .getPropertyAge(this.property?.estPossessionOn === undefined ?
                    new Date().toString():
                    this.property?.estPossessionOn
                  );
  }

  onSelectNextPage(){
    this.propertyId += 1;
    this.router.navigate(['/property-detail/',this.propertyId]);
  }

  onSelectBackPage(){
    this.propertyId -= 1;
    if(this.propertyId < 1){
      this.propertyId = 1;
      return;
    }
    else{
      this.router.navigate(['/property-detail/',this.propertyId]);
    }
  }

  ngrXGalleryLoad(){
    this.galleryOptions = [
      {
        width: '100%',
        height: '460px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide
      }
    ];

    this.galleryImages = [
      {
        small: 'assets/images/prop-1.jpg',
        medium: 'assets/images/prop-1.jpg',
        big: 'assets/images/prop-1.jpg'
      },
      {
        small: 'assets/images/prop-2.jpg',
        medium: 'assets/images/prop-2.jpg',
        big: 'assets/images/prop-2.jpg'
      },
      {
        small: 'assets/images/prop-3.jpg',
        medium: 'assets/images/prop-3.jpg',
        big: 'assets/images/prop-3.jpg'
      },{
        small: 'assets/images/prop-4.jpg',
        medium: 'assets/images/prop-4.jpg',
        big: 'assets/images/prop-4.jpg'
      },
      {
        small: 'assets/images/prop-5.jpg',
        medium: 'assets/images/prop-5.jpg',
        big: 'assets/images/prop-5.jpg'
      }
    ];
  }

}
