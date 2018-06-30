import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, RequestMethod } from '@angular/http';
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
    return this.http.post('http://localhost:5000/api/books', body, requestOptions);
  }

  putBook(id, book) {
    var body = JSON.stringify(book);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:5000/api/books/' + id, body, requestOptions);
  }

  getBookList() {
    return this.http.get('http://localhost:5000/api/books')
      .subscribe(data => {
        this.bookList = data.json() as Book[];
      })
  }

  deleteBook(id: number) {
    return this.http.delete('http://localhost:5000/api/books/' + id);
  }

  sellBook(id, book) {
    var body = JSON.stringify(book);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    return this.http.post('http://localhost:5000/api/books/' + id + '/sell', body, requestOptions); 
  }

}
