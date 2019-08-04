import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { CardRoundedComponent } from '../shared/card-rounded/card-rounded.component';

@NgModule({
  declarations: [
    AdicionarUsuarioComponent,
    UsuarioListaComponent,
    CardRoundedComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule
  ]
})
export class UsuarioModule { }
