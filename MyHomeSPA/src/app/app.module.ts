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
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatExpansionModule} from '@angular/material/expansion';
import { PageComponent } from './page/page.component';

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
    TaskItemComponent,
    ShoppingPlannerComponent,
    ShoppingPlannerItemComponent,
    ShoppingCategoryItemComponent,
    ShoppingTypeItemComponent,
    PageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, 
    MatButtonModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatGridListModule,
    MatToolbarModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule,
    MatCheckboxModule,
    MatSlideToggleModule,
    MatExpansionModule
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
