export const mensagensDeErro = {
  nome: {
    required: 'O nome deve ser fornecido',
    minlength: 'O Nome precisa ter no mínimo 3 caracteres',
    maxlength: 'O Nome precisa ter no máximo 150 caracteres'
  },
  sobrenome: {
    required: 'O sobrenome deve ser fornecido',
    minlength: 'O sobrenome precisa ter no mínimo 3 caracteres',
    maxlength: 'O sobrenome precisa ter no máximo 150 caracteres'
  },
  cpf: {
    required: 'O CPF deve ser fornecido',
    minlength: 'O CPF precisa ter no mínimo 11 caracteres',
    maxlength: 'O sobrenome precisa ter no máximo 14 caracteres'
  },
  sexo: {
    required: 'O sexo deve ser fornecido',
    pattern: 'O sexo só pode ser definido como [M]asculino ou [F]eminino.'
  },
  dataDeNascimento: {
    required: 'O data de nascimento deve ser fornecida',
  },
  email: {
    required: 'O e-mail deve ser fornecido',
    email: 'Não é um e-mail válido.'
  },
  telefone: {
    minlength: 'O telefone precisa ter no mínimo 11 caracteres',
    maxlength: 'O telefone precisa ter no máximo 13 caracteres'
  },
  celular: {
    minlength: 'O celular precisa ter no mínimo 13 caracteres',
    maxlength: 'O celular precisa ter no máximo 15 caracteres'
  },
  logradouro: {
    minlength: 'O logradouro precisa ter no mínimo 3 caracteres',
    maxlength: 'O logradouro precisa ter no máximo 150 caracteres'
  },
  numero: {
    minlength: 'O numero precisa ter no mínimo 3 caracteres',
    maxlength: 'O numero precisa ter no máximo 10 caracteres'
  },
  complemento: {
    minlength: 'O complemento precisa ter no mínimo 3 caracteres',
    maxlength: 'O complemento precisa ter no máximo 50 caracteres'
  },
  bairro: {
    minlength: 'O bairro precisa ter no mínimo 3 caracteres',
    maxlength: 'O bairro precisa ter no máximo 150 caracteres'
  },
  cep: {
    minlength: 'O cep precisa ter no mínimo 8 caracteres',
    maxlength: 'O cep precisa ter no máximo 9 caracteres'
  },
  cidade: {
    minlength: 'O cidade precisa ter no mínimo 3 caracteres',
    maxlength: 'O cidade precisa ter no máximo 150 caracteres'
  },
  estado: {
    minlength: 'O estado precisa ter no mínimo 2 caracteres',
    maxlength: 'O estado precisa ter no máximo 2 caracteres'
  },
  perfilId: {
    required: 'O perfil é requerido.'
  }
};
