import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostsComponent } from './pages/posts/posts.component';
import { HomeComponent } from './pages/home/home.component';
import { DeclarativePostComponent } from './pages/declarative-post/declarative-post.component';
import { AltPostsComponent } from './pages/alt-posts/alt-posts.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'posts', component: PostsComponent},
  {path: 'declarative-post', component: DeclarativePostComponent},
  {path: 'alt-post', component: AltPostsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
