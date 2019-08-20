import { AtribuicaoDTO } from './atribuicaoDTO';

export class Perfil {
    id: string;
    nome: string;
    descricao: string;
    atribuicoes: AtribuicaoDTO[];
    action: any;

    /**
     *
     */
    constructor() {
      this.atribuicoes = new Array<AtribuicaoDTO>();
    }
}
