import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/book.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Book } from '../shared/book.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent implements OnInit {

  constructor(private bookService: BookService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.bookService.selectedBook = {
      id: 0,
      name: '',
      authors: '',
      edition: '',
      isbn: '',
      price: 0.00,
      buyDate: '',
      buyPrice: 0.00,
    };
  }


  onSubmit(form: NgForm) {
    if (form.value.id == null) {
      this.bookService.postBook(form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.bookService.getBookList();
          this.toastr.success('New Book Added Succcessfully', 'Book Register');
        })
    }
    else {
      this.bookService.putBook(form.value.id, form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.bookService.getBookList();
          this.toastr.info('Book Updated Successfully!', 'Book Register');
        });
    }
  }

}
