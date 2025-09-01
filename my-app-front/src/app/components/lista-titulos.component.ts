
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Titulo } from '../titulo.model';

@Component({
  selector: 'app-lista-titulos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lista-titulos.component.html',
  styleUrls: ['./lista-titulos.component.css']
})
export class ListaTitulosComponent implements OnInit {
  titulos: Titulo[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<Titulo[]>('http://localhost:5189/api/titulos').subscribe(data => {
      this.titulos = data;
    });
  }


  valorOriginal(titulo: Titulo): number {
    return titulo.parcelas.reduce((acc, p) => acc + p.valor, 0);
  }

  diasEmAtrasoParcela(parcela: any, dataBase: Date = new Date()): number {
    const venc = new Date(parcela.dataVencimento);
    const diff = dataBase.getTime() - venc.getTime();
    return diff > 0 ? Math.floor(diff / (1000 * 60 * 60 * 24)) : 0;
  }

  detalharParcelas(titulo: Titulo) {
    return titulo.parcelas;
  }

  valorAtualizadoDetalhado(titulo: Titulo): number {
    return titulo.parcelas.reduce((acc, p) => acc + (p.valorAtualizado || p.valor), 0);
  }
}
