import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { ListarPerfisComponent } from './listar-perfis/listar-perfis.component';
import { AdicionarPerfilComponent } from './adicionar-perfil/adicionar-perfil.component';


const routes: Routes = [
    { path: '', component: ListarPerfisComponent, data: { title: 'Perfis Registradadas' }, canActivate: [CanActivateUser] },
    { path: 'adicionar', component: AdicionarPerfilComponent, data: { title: 'Adicionar Perfil' }, canActivate: [CanActivateUser] },
 ];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PerfilRoutingModule { }
