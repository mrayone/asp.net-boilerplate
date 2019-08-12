import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { ListarPerfisComponent } from './listar-perfis/listar-perfis.component';


const routes: Routes = [
    { path: '', component: ListarPerfisComponent, data: { title: 'Perfis Registradadas' }, canActivate: [CanActivateUser] },
 ];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PerfilRoutingModule { }
