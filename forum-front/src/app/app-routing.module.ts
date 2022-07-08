import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TopicDetailComponent } from './pages/topic-detail/topic-detail.component';
import { TopicListComponent } from './pages/topicList/topicList.component';

const routes: Routes = [
  {path:"topics", component:TopicListComponent},
  {path:"topics/:id", component:TopicDetailComponent},
  {path:"**", redirectTo: ""}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
