export class Permissao {
  id: string;
  tipo:	string;
  valor: string;
  action: any;

  constructor() {
    this.tipo = '';
    this.valor = '';
  }
}
