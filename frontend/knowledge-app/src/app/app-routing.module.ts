import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashBoardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  { path: 'perfil', component: PerfilComponent, data: { title: 'Perfil do Usuário' } },
  { path: 'dashboard', component: DashBoardComponent, data: { title: 'Dashboard' } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
