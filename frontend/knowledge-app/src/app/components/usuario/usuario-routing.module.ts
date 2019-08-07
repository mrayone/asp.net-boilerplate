import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';


const routes: Routes = [
  { path: '', component: UsuarioListaComponent, data: { title: 'Usuários Registrados' }, canActivate: [CanActivateUser] },
  { path: 'adicionar', component: AdicionarUsuarioComponent, data: { title: 'Adicionar Novo Usuário' }, canActivate: [CanActivateUser] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
