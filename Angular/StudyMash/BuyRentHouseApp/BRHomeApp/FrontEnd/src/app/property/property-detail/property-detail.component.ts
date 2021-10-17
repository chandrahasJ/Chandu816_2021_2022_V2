import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/models/Property';
import { HousingService } from 'src/app/services/housing.service';

import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';
import { IPhoto } from 'src/app/models/IPhoto.interface';


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

  primaryImage! : string;

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


    this.ngrXGalleryLoad();
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

    this.galleryImages =  this.populateGalleryImages();
  }

  populateGalleryImages() : NgxGalleryImage[]{
    const photoUrls : NgxGalleryImage[] = [];
    for(const photo of this.property.photos!){
        if(photo.isPrimary == true){
            this.property.primaryImage = photo.imageUrl;
        }
        else{
          photoUrls.push( {
              small : photo.imageUrl,
              medium : photo.imageUrl,
              big : photo.imageUrl,
          })
        }
    }
    return photoUrls;
  }
}
