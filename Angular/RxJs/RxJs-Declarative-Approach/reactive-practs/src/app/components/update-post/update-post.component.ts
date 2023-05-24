import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { tap } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-update-post',
  templateUrl: './update-post.component.html',
  styleUrls: ['./update-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UpdatePostComponent {

  post$ = this.postService
              .post$
              .pipe(tap(postData => {
                  postData && this.postFormGroup.patchValue(postData);
              }));

  postFormGroup = this.createPostFormGroup();

  categories$ = this.catergoryService.category_data$;

  constructor(private formBuilder: FormBuilder,
              private catergoryService: DeclarativeCategoryService,
              private postService: DeclarativePostService) {}

  createPostFormGroup() {
    return this.formBuilder.group({
      id: new FormControl<string | null>(null),
      title: new FormControl<string | null>(null,{
        nonNullable: true,
        validators: [Validators.required]
      }),
      description: new FormControl<string>(''),
      categoryId: new FormControl<string | null>('',{
        validators: [Validators.required]
      }),
    });
  }

  onUpdatePost(){
    let purePost = this.postFormGroup.value as IPost;

    this.postService.updatePost(purePost);
  }

  validateForm(){
    return this.postFormGroup.invalid;
  }
}
