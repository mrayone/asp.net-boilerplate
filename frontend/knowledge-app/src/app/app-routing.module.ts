import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashBoardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { CanActivateUser } from './guards/can-activate-user';
import { UnauthorizedComponent } from './components/shared/unauthorized/unauthorized.component';

const routes: Routes = [
  { path: 'dashboard', component: DashBoardComponent, data: { title: 'Dashboard' }, canActivate: [CanActivateUser]   },
  { path: 'login', component: LoginComponent },
  { path: 'nao-autorizado', component: UnauthorizedComponent },
  { path: 'usuarios', loadChildren: './components/usuario/usuario.module#UsuarioModule' },
  { path: 'permissoes', loadChildren: './components/permissao/permissao.module#PermissaoModule' },
  { path: 'perfis', loadChildren: './components/perfil/perfil.module#PerfilModule' },
  { path: '',   redirectTo: '/dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
