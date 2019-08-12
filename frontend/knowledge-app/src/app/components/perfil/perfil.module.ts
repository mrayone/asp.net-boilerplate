import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilRoutingModule } from './perfil-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';


import { ListarPerfisComponent } from './listar-perfis/listar-perfis.component';

@NgModule({
  declarations: [
    ListarPerfisComponent
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
