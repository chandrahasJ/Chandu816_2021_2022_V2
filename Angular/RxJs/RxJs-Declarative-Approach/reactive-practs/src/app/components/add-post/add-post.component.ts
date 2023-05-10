import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddPostComponent {

  postFormGroup = this.createPostFormGroup();

  categories$ = this.catergoryService.category_data$;

  constructor(private formBuilder: FormBuilder,
              private catergoryService: DeclarativeCategoryService) {}

  createPostFormGroup() {
    return this.formBuilder.group({
      title: new FormControl<string | null>(null,{
        nonNullable: true,
        validators: [Validators.required]
      }),
      description: new FormControl<string>(''),
      catergoryId: new FormControl<string | null>('',{
        validators: [Validators.required]
      }),
    });
    this.postFormGroup.controls['catergoryId'].patchValue('');
  }

  onAddPost(){
    console.log(this.postFormGroup.value);
  }

  validateForm(){
    console.log(this.postFormGroup.invalid);
    return this.postFormGroup.invalid;
  }
}
