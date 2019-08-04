import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';

@NgModule({
  declarations: [
    AdicionarUsuarioComponent,
    UsuarioListaComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule
  ]
})
export class UsuarioModule { }
