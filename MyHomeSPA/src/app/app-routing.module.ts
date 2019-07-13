import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NoteComponent } from './notes/note/note.component';
import { ShoppingPlannerComponent } from './shoppingPlanners/shopping-planner/shopping-planner.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'notes',
    component: NoteComponent
  },
  {
    path: 'shoppingPlanner',
    component: ShoppingPlannerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
