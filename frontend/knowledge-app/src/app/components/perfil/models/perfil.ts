import { AtribuicaoDTO } from './atribuicaoDTO';

export class Perfil {
    id: string;
    nome: string;
    descricao: string;
    atribuicoes: AtribuicaoDTO[];

    /**
     *
     */
    constructor() {
      this.atribuicoes = new Array<AtribuicaoDTO>();
    }
}
