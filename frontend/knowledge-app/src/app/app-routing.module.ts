import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashBoardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { CanActivateUser } from './guards/can-activate-user';
import { UnauthorizedComponent } from './components/shared/unauthorized/unauthorized.component';

const routes: Routes = [
  { path: 'perfil', component: PerfilComponent, data: { title: 'Perfil do Usuário' }, canActivate: [CanActivateUser] },
  { path: 'dashboard', component: DashBoardComponent, data: { title: 'Dashboard' }, canActivate: [CanActivateUser]   },
  { path: 'login', component: LoginComponent },
  { path: 'nao-autorizado', component: UnauthorizedComponent },
  { path: 'usuarios', loadChildren: './components/usuario/usuario.module#UsuarioModule', canActivate: [CanActivateUser] },
  { path: '',   redirectTo: '/dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
