import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Book } from './book.model';

@Injectable()
export class BookService {

  selectedBook: Book;
  bookList: Book[];
  constructor(private http: Http) { }

  postBook(book: Book) {
    var body = JSON.stringify(book);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    return this.http.post('http://localhost:5000/api/books', body, requestOptions).map(x => x.json());
  }

  putBook(id, book) {
    var body = JSON.stringify(book);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:5000/api/books/' + id,
      body,
      requestOptions).map(res => res.json());
  }

  getBookList() {
    this.http.get('http://localhost:5000/api/books')
      .map((data: Response) => {
        return data.json() as Book[];
      }).toPromise().then(x => {
        this.bookList = x;
      })
  }

  deleteBook(id: number) {
    return this.http.delete('http://localhost:5000/api/books/' + id).map(res => res.json());
  }
}
