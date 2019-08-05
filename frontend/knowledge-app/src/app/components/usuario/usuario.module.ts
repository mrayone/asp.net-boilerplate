import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule , IConfig} from 'ngx-mask';

// const
export let options: Partial<IConfig> | (() => Partial<IConfig>);

// componentes
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { SharedModule } from '../shared/shared.module';
import { FormularioUsuarioComponent } from './formulario/formulario-usuario.component';

@NgModule({
  declarations: [
    AdicionarUsuarioComponent,
    UsuarioListaComponent,
    FormularioUsuarioComponent,
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    NgbModule,
    NgxMaskModule.forRoot(options)
  ],
  exports: [
    FormularioUsuarioComponent
  ]
})
export class UsuarioModule { }
