import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { BookFilters } from '../models/filters/bookFilters';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private bookUrl: string = '';

  constructor(private http: HttpClient) { 
    this.bookUrl = environment.APIEndpoint + '/api/book';
  }

  public Search(filters: BookFilters) : Observable<Book[]> {
    const url = `${this.bookUrl}/Search/`;
    return this.http.post<Book[]>(url, filters);
  }
}
