import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { tap } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.scss'],
})
export class PostFormComponent {


  postFormGroup = this.createPostFormGroup();

  categories$ = this.catergoryService.category_data$;

  constructor(
    private formBuilder: FormBuilder,
    private catergoryService: DeclarativeCategoryService,
    private postService: DeclarativePostService
  ) {}

  createPostFormGroup() {
    return this.formBuilder.group({
      id: new FormControl<string | null>(null),
      title: new FormControl<string | null>(null, {
        nonNullable: true,
        validators: [Validators.required],
      }),
      description: new FormControl<string>(''),
      categoryId: new FormControl<string | null>('', {
        validators: [Validators.required],
      }),
    });
  }

  onPost() {
    let purePost = this.postFormGroup.value as IPost;

    this.postService.updatePost(purePost);
  }

  validateForm() {
    return this.postFormGroup.invalid;
  }
}
