import 'rxjs/add/observable/of';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { OnInit, Component } from '@angular/core';
import { LivrariaService } from '../livraria.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {
  
  public displayedColumns = ['id', 'name', 'authors', 'publishYear', 'edition', 'isbn', 'price', 'buyDate', 'buyPrice', 'sellDate', 'sellPrice'];
  public dataSource: MatTableDataSource<any>;

  public noResults$ = false;
  constructor(
    private _service: LivrariaService,
    private _router: Router,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.atualizarListaDeLivros();
  }

  excluir(id) {
    this._service.excluir(id).subscribe(() => {
      this.atualizarListaDeLivros();
    });
  }

  editar(id) {
    this._router.navigate(["/main/disciplina/editar", id]);
  }

  private atualizarListaDeLivros() {
    this._service.listar().subscribe(suc => {
      this.noResults$ = suc.length == 0;
      this.dataSource = new MatTableDataSource(suc);
    }, () => {
        console.log('Erro ao carregar a lista')
      });
  }

}
