import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaPermissoesComponent } from './lista-permissoes/lista-permissoes.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { AdicionarPermissaoComponent } from './adicionar-permissao/adicionar-permissao.component';



const routes: Routes = [
    { path: '', component: ListaPermissoesComponent, data: { title: 'Permissões Registradadas' }, canActivate: [CanActivateUser] },
    { path: 'adicionar', component: AdicionarPermissaoComponent, data: { title: 'Adicionar Permissão' }, canActivate: [CanActivateUser] }
 ];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PermissaoRoutingModule { }
