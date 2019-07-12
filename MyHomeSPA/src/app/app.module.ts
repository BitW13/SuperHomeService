import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavpanelComponent } from './navpanel/navpanel.component';
import { NoteComponent } from './notes/note/note.component';
import { NoteItemComponent } from './notes/note-item/note-item.component';
import { NoteCategoryItemComponent } from './notes/note-category-item/note-category-item.component';
import { NoteService } from './notes/services/note.service';
import { NoteCategoryService } from './notes/services/note-category.service';
import { ShoppingPlannerComponent } from './shoppingPlanners/shopping-planner/shopping-planner.component';
import { ShoppingPlannerItemComponent } from './shoppingPlanners/shopping-planner-item/shopping-planner-item.component';
import { ShoppingCategoryItemComponent } from './shoppingPlanners/shopping-category-item/shopping-category-item.component';
import { TaskComponent } from './tasks/task/task.component';
import { TaskCategoryItemComponent } from './tasks/task-category-item/task-category-item.component';
import { TaskItemComponent } from './tasks/task-item/task-item.component';
import { ShoppingTypeItemComponent } from './shoppingPlanners/shopping-type-item/shopping-type-item.component';
import { PurchaseService } from './shoppingPlanners/services/purchase.service';
import { ShoppingCategoryService } from './shoppingPlanners/services/shopping-category.service';
import { TypeOfPurchaseService } from './shoppingPlanners/services/type-of-purchase.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavpanelComponent,
    NoteComponent,
    NoteItemComponent,
    NoteCategoryItemComponent,
    TaskComponent,
    TaskCategoryItemComponent,
    TaskItemComponent
    NoteCategoryItemComponent,
    ShoppingPlannerComponent,
    ShoppingPlannerItemComponent,
    ShoppingCategoryItemComponent,
    ShoppingTypeItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    NoteService, 
    NoteCategoryService, 
    PurchaseService, 
    ShoppingCategoryService, 
    TypeOfPurchaseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
