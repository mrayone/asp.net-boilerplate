import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormularioComponent } from './formulario/formulario.component';
import { ListaPermissoesComponent } from './lista-permissoes/lista-permissoes.component';
import { AdicionarPermissaoComponent } from './adicionar-permissao/adicionar-permissao.component';
import { PermissaoRoutingModule } from './permissao-routing.module';
@NgModule({
  declarations: [
    FormularioComponent,
    AdicionarPermissaoComponent,
    ListaPermissoesComponent
  ],
  imports: [
    CommonModule,
    PermissaoRoutingModule
  ]
})
export class PermissaoModule { }
