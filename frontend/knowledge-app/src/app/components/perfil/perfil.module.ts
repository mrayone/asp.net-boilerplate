import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilRoutingModule } from './perfil-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';


import { ListaPerfisComponent } from './lista-perfis/lista-perfis.component';
import { AdicionarPerfilComponent } from './adicionar-perfil/adicionar-perfil.component';
import { FormularioComponent } from './formulario/formulario.component';
import { EditarPerfilComponent } from './editar-perfil/editar-perfil.component';
import { DetalhesPerfilComponent } from './detalhes-perfil/detalhes-perfil.component';

@NgModule({
  declarations: [
    ListaPerfisComponent,
    AdicionarPerfilComponent,
    FormularioComponent,
    EditarPerfilComponent,
    DetalhesPerfilComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    PerfilRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class PerfilModule { }
