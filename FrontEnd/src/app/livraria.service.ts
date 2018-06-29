import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LivrariaService {

  private _urlBooks = "http://localhost:5000/api/books";

  constructor(private _httpClient: HttpClient) { }

  adicionar(book) {
    return this._httpClient.post(this._urlBooks, book, { responseType: 'text' });
  }

  vender(book) {
    return this._httpClient.post(this._urlBooks + '/vender', book, { responseType: 'text' });
  }

  excluir(id) {
    return this._httpClient.delete(this._urlBooks + "/" + id, { responseType: 'text' });
  }

  editar(book) {
    return this._httpClient.put(this._urlBooks + "/" + book.id, book, { responseType: 'text' });
  }

  listar() {
    return this._httpClient.get<Array<any>>(this._urlBooks);
  }

  listarEstoque() {
    return this._httpClient.get<Array<any>>(this._urlBooks + '/stock');
  }

  carregar(id) {
    return this._httpClient.get<any>(this._urlBooks + "/" + id);
  }
}
