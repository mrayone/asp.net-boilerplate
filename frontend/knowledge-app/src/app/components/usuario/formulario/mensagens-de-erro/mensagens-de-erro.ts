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
  }
};
