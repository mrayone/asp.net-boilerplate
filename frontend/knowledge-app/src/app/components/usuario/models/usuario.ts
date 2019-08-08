export class Usuario {
  public id: string;
  public nome: string;
  public sobrenome: string;
  public sexo: string;
  public email: string;
  public cpf: string;
  public dataDeNascimento: any;
  public perfilId: string;
  public celular: string;
  public telefone: string;
  public logradouro: string;
  public numero: string;
  public complemento: string;
  public bairro: string;
  public cep: string;
  public cidade: string;
  public estado: string;

  constructor() {
    this.nome = '';
    this.sobrenome = '';
    this.sexo = '';
    this.email = '';
    this.cpf = '';
    this.dataDeNascimento = '';
  }
}
