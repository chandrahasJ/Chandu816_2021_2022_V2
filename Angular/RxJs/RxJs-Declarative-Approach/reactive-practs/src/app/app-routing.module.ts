import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostsComponent } from './pages/posts/posts.component';
import { HomeComponent } from './pages/home/home.component';
import { DeclarativePostComponent } from './pages/declarative-post/declarative-post.component';
import { AltPostsComponent } from './pages/alt-posts/alt-posts.component';
import { PostFormComponent } from './components/post-form/post-form.component';

const routes: Routes = [
  {path: 'posts', component: PostsComponent},
  {path: 'declarative-post', component: DeclarativePostComponent},
  {path: 'alt-post', component: AltPostsComponent},
  {path: 'declarative-post/add', component: PostFormComponent},
  {path: 'declarative-post/edit/:id', component: PostFormComponent},
  {path: '', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
