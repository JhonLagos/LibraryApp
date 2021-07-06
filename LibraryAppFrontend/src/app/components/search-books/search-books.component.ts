import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookFilters } from 'src/app/models/filters/bookFilters';
import { BookService } from 'src/app/services/book.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-search-books',
  templateUrl: './search-books.component.html',
  styleUrls: ['./search-books.component.css']
})
export class SearchBooksComponent implements OnInit {
  public filters: BookFilters = new BookFilters();
  public books: Book[] = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    Swal.showLoading();
    this.bookService.Search(this.filters)
      .subscribe(
        response => {
          Swal.hideLoading();
          Swal.close();
          this.books = response;
        },
        error => {
          Swal.hideLoading();
          Swal.close();
          Swal.fire({
            title: 'Error!',
            text: 'Ocurrio un error al obtener listado de libros',
            icon: 'error',
            confirmButtonText: 'Aceptar'
          })
        }
      )
  }
}
