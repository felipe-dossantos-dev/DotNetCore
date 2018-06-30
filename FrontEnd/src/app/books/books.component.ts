import { Component, OnInit } from '@angular/core';
import { BookService } from './shared/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
  providers: [BookService]
})
export class BooksComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
