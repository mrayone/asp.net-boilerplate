import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaPermissoesComponent } from './lista-permissoes/lista-permissoes.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';



const routes: Routes = [
    { path: '', component: ListaPermissoesComponent, data: { title: 'Permissões Registradadas' }, canActivate: [CanActivateUser] }
 ];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PermissaoRoutingModule { }
