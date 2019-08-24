import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { httpInterceptorProviders } from 'src/app/http-interceptors';
import { FormsModule } from '@angular/forms';
import { NullFieldPipe } from '../../Utils/pipes/null-field.pipe';
import { GeneroUsuarioPipe } from '../../Utils/pipes/genero-usuario.pipe';
export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

// componentes
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { ListaUsuariosComponent } from './lista-usuarios/lista-usuarios.component';
import { SharedModule } from '../shared/shared.module';
import { FormularioUsuarioComponent } from './formulario/formulario-usuario.component';
import { CanActivateUser } from 'src/app/guards/can-activate-user';
import { PerfilUsuarioComponent } from './perfil-usuario/perfil-usuario.component';
import { DetalhesUsuarioComponent } from './detalhes-usuario/detalhes-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';
import { TrocarSenhaComponent } from '../senha/trocar-senha/trocar-senha.component';

@NgModule({
  declarations: [
    AdicionarUsuarioComponent,
    ListaUsuariosComponent,
    DetalhesUsuarioComponent,
    FormularioUsuarioComponent,
    PerfilUsuarioComponent,
    NullFieldPipe,
    GeneroUsuarioPipe,
    EditarUsuarioComponent,
    TrocarSenhaComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(options),
    FormsModule,
    NgbModule
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
