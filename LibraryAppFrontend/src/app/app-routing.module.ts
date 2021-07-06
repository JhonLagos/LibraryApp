import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SearchBooksComponent } from './components/search-books/search-books.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'search-books', component: SearchBooksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
