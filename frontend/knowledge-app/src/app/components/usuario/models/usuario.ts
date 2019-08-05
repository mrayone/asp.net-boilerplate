export class Usuario {
  public id: string;
  public nome: string;
  public sobrenome: string;
  public sexo: string;
  public email: string;
  public cpf: string;
  public dateDeNascimento: string;
  public perfilId: string;
  public celular: string;
  public telefone: string;
  public status: boolean;
  public logradouro: string;
  public numero: string;
  public complemento: string;
  public bairro: string;
  public cep: string;
  public cidade: string;
  public estado: string;

  constructor() {
    this.id = '';
    this.nome = '';
    this.sobrenome = '';
    this.sexo = '';
    this.email = '';
    this.cpf = '';
    this.dateDeNascimento = '';
    this.perfilId = '';
    this.celular = '';
    this.telefone = '';
    this.status = true;
    this.logradouro = '';
    this.numero = '';
    this.complemento = '';
    this.bairro = '';
    this.cep = '';
    this.cidade = '';
    this.estado = '';
  }
}
