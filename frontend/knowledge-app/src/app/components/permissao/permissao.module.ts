import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PermissaoRoutingModule } from './permissao-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';

import { FormularioComponent } from './formulario/formulario.component';
import { ListaPermissoesComponent } from './lista-permissoes/lista-permissoes.component';
import { AdicionarPermissaoComponent } from './adicionar-permissao/adicionar-permissao.component';
import { DetalhesPermissaoComponent } from './detalhes-permissao/detalhes-permissao.component';
@NgModule({
  declarations: [
    FormularioComponent,
    AdicionarPermissaoComponent,
    ListaPermissoesComponent,
    DetalhesPermissaoComponent
  ],
  imports: [
    CommonModule,
    PermissaoRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    SharedModule
  ]
})
export class PermissaoModule { }
