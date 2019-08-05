import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashBoardComponent } from './components/dashboard/dashboard.component';
import { UsuarioListaComponent } from './components/usuario/usuario-lista/usuario-lista.component';

const routes: Routes = [
  { path: 'perfil', component: PerfilComponent, data: { title: 'Perfil do Usuário' } },
  { path: 'dashboard', component: DashBoardComponent, data: { title: 'Dashboard' } },
  { path: 'usuarios', loadChildren: './components/usuario/usuario.module#UsuarioModule' },
  { path: '',   redirectTo: '/dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
