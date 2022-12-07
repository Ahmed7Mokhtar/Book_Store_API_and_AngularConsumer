import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBookComponent } from './components/add-book/add-book.component';
import { AllBooksComponent } from './components/all-books/all-books.component';

const routes: Routes = [
  {path:'', component: AllBooksComponent},
  {path:'addBook', component: AddBookComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
