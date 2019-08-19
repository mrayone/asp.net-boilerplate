export const mensagensDeErro = {
  email: {
    required: 'O e-mail deve ser fornecido',
    email: 'Não é um e-mail válido.'
  },
  senha: {
    required: 'Informe a senha',
    minLength: 'A senha deve possuir no mínimo 6 caracteres'
  },
  confirmaSenha: {
    required: 'Informe a senha novamente',
    minLength: 'A senha deve possuir no mínimo 6 caracteres',
    mustMatch: 'As senhas não conferem'
  }
};
