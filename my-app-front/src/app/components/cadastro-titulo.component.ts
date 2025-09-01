import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Titulo } from '../titulo.model';

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro-titulo',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cadastro-titulo.component.html',
  styleUrls: ['./cadastro-titulo.component.css']
})
export class CadastroTituloComponent {
  tituloForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.tituloForm = this.fb.group({
      numeroTitulo: ['', Validators.required],
      nomeDevedor: ['', Validators.required],
      cpfDevedor: ['', [Validators.required, Validators.pattern(/\d{11}/)]],
      percentualJuros: [0, Validators.required],
      percentualMulta: [0, Validators.required],
      parcelas: this.fb.array([])
    });
  }

  get parcelas() {
    return this.tituloForm.get('parcelas') as FormArray;
  }

  adicionarParcela() {
    this.parcelas.push(this.fb.group({
      numeroParcela: [this.parcelas.length + 1, Validators.required],
      dataVencimento: ['', Validators.required],
      valor: [0, Validators.required]
    }));
  }

  removerParcela(index: number) {
    this.parcelas.removeAt(index);
  }

  onSubmit() {
    if (this.tituloForm.valid) {
      const titulo: Titulo = this.tituloForm.value;
      this.http.post('http://localhost:5189/api/titulos', titulo).subscribe({
        next: () => alert('Título cadastrado com sucesso!'),
        error: () => alert('Erro ao cadastrar título!')
      });
    }
  }
}
