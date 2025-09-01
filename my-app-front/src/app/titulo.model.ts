export interface Parcela {
  numeroParcela: number;
  dataVencimento: string;
  valor: number;
  diasAtraso?: number;
  multa?: number;
  juros?: number;
  valorAtualizado?: number;
}

export interface Titulo {
  numeroTitulo: string;
  nomeDevedor: string;
  cpfDevedor: string;
  percentualJuros: number;
  percentualMulta: number;
  parcelas: Parcela[];
  valorAtualizado?: number;
}
