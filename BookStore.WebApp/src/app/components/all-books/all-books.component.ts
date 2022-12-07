import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/book.service';

@Component({
  selector: 'app-all-books',
  templateUrl: './all-books.component.html',
  styleUrls: ['./all-books.component.css']
})
export class AllBooksComponent implements OnInit {

  public books : any;

  constructor(private service:BookService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  public getBooks() : void{
    this.service.getBooks().subscribe(result => {
      this.books = result;
    });
  }
}
