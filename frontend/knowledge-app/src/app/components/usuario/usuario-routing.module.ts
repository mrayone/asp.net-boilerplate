import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { ListaUsuariosComponent } from './lista-usuarios/lista-usuarios.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { PerfilUsuarioComponent } from './perfil-usuario/perfil-usuario.component';
import { DetalhesUsuarioComponent } from './detalhes-usuario/detalhes-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';


const routes: Routes = [
  { path: '', component: ListaUsuariosComponent, data: { title: 'Usuários Registrados' }, canActivate: [CanActivateUser] },
  { path: 'adicionar', component: AdicionarUsuarioComponent, data: { title: 'Adicionar Novo Usuário' }, canActivate: [CanActivateUser] },
  { path: 'perfil', component: PerfilUsuarioComponent, data: { title: 'Perfil do Usuário' }, canActivate: [CanActivateUser] },
  { path: 'editar/:id', component: EditarUsuarioComponent, data: { title: 'Editar o Usuário' }, canActivate: [CanActivateUser] },
  {
    path: 'detalhes/:id', component: DetalhesUsuarioComponent,
    data: { title: 'Detalhes do Usuário' }, canActivate: [CanActivateUser]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
