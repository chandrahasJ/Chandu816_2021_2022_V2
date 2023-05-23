import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, map, startWith, tap } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PostFormComponent {

  postId : string| null = null;

  postFormGroup = this.createPostFormGroup();

  categories$ = this.catergoryService.category_data$;

  selectedPost$ = this.route.paramMap.pipe(map(paramMaps => {
    let id = paramMaps.get('id');
    if(id){
      this.postId = id;
    }
    this.postService.selectPost(id + '');
    return id;
  }))

  post$ = this.postService.post$.pipe(tap(postData => {
    postData && this.postFormGroup.patchValue(postData);
  }))

  notification$ = this.postService
                      .postCRUDNotificationAction$
                      .pipe(
                        startWith(false),
                        tap(message => {
                          message && this.router
                              .navigateByUrl('/declarative-post')
                        })
                      );

  vm$ = combineLatest([this.selectedPost$,
                       this.post$,
                       this.notification$]);

  constructor(
    private formBuilder: FormBuilder,
    private catergoryService: DeclarativeCategoryService,
    private postService: DeclarativePostService,
    private router: Router,
    private route : ActivatedRoute
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

  onPostSubmit() {
    let purePost = this.postFormGroup.value as IPost;
    if(this.postId){
      this.postService.updatePost(purePost);
    } else {
      this.postService.addPost(purePost);
    }
  }

  validateForm() {
    return this.postFormGroup.invalid;
  }
}
