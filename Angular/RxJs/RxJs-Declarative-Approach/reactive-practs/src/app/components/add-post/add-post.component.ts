import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { IPost } from 'src/app/models/Post';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

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
              private catergoryService: DeclarativeCategoryService,
              private postService: DeclarativePostService) {}

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
  }

  onAddPost(){
    let purePost = this.postFormGroup.value as IPost;

    let post = {
      ...purePost,
      categoryName : ''
    } as IPost

    this.postService.addPost(post);
  }

  validateForm(){
    return this.postFormGroup.invalid;
  }
}
