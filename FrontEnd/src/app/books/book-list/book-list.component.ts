import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/book.service';
import { Book } from '../shared/book.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
  providers: [BookService]
})
export class BookListComponent implements OnInit {

  constructor(private bookService: BookService, private toastr: ToastrService) { }

  ngOnInit() {
    this.bookService.getBookList();
  }

  showForEdit(book: Book) {
    this.bookService.selectedBook = Object.assign({}, book);
  }


  onDelete(id: number) {
    if (confirm('Are you sure?') == true) {
      this.bookService.deleteBook(id)
        .subscribe(x => {
          this.bookService.getBookList();
          this.toastr.warning("Deleted Successfully", "Book Register");
        })
    }
  }
}
