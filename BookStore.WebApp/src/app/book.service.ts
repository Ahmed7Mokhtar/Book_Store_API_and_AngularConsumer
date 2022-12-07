import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private getAllBooksPath = 'https://localhost:7173/Books/GetAllBooks';
  private addBookPath = 'https://localhost:7173/Books/AddNewBook';


  constructor(private http:HttpClient) { }

  public getBooks() : Observable<any>{
    return this.http.get(this.getAllBooksPath);
  }

  public addBook(book:any) : Observable<any>{
    return this.http.post(this.addBookPath, book);
  }
}
