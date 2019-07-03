import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashBoardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  { path: 'perfil', component: PerfilComponent },
  { path: 'dashboard', component: DashBoardComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
