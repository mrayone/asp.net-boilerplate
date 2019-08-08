export class Perfil {
    id: string;
    nome: string;
    descricao: string;
    atribuicoes: [
      {
        atribuicaoId: string;
        permissaoId: string;
      }
    ];
}
