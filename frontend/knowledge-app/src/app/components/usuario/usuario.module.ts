import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule , IConfig} from 'ngx-mask';
import { httpInterceptorProviders } from 'src/app/http-interceptors';
import { FormsModule } from '@angular/forms';
import { NullFieldPipe } from '../../utils/pipes/null-field.pipe';
import { GeneroUsuarioPipe } from '../../utils/pipes/genero-usuario.pipe';
// const
export let options: Partial<IConfig> | (() => Partial<IConfig>);

// componentes
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { SharedModule } from '../shared/shared.module';
import { FormularioUsuarioComponent } from './formulario/formulario-usuario.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { PerfilUsuarioComponent } from './perfil-usuario/perfil-usuario.component';
import { UsuarioDetalhesComponent } from './usuario-detalhes/usuario-detalhes.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';

@NgModule({
  declarations: [
    AdicionarUsuarioComponent,
    UsuarioListaComponent,
    UsuarioDetalhesComponent,
    FormularioUsuarioComponent,
    PerfilUsuarioComponent,
    NullFieldPipe,
    GeneroUsuarioPipe,
    EditarUsuarioComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
    NgxMaskModule.forRoot(options)
  ],
  exports: [
    FormularioUsuarioComponent
  ],
  providers: [
    CanActivateUser,
    httpInterceptorProviders
  ],
})
export class UsuarioModule { }
