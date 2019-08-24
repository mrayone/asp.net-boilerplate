import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/reducers';
import { environment } from 'src/environments/environment';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './components/shared/shared.module';
import { UsuarioModule } from './components/usuario/usuario.module';
import { AppRoutingModule } from './app-routing.module';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CanActivateUser } from './guards/can-activate-user';
import { ErrosService } from './services/erros.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PermissaoModule } from './components/permissao/permissao.module';
import { httpInterceptorProviders } from './http-interceptors';
import { PerfilModule } from './components/perfil/perfil.module';

import { ToastrModule, ToastContainerModule } from 'ngx-toastr';
// components
import { DashBoardComponent } from './components/dashboard/dashboard.component';
// tslint:disable-next-line: max-line-length
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { MenuComponent } from './components/shared/menu/menu.component';
import { LoginComponent } from './components/login/login.component';
import { RecuperarSenhaComponent } from './components/senha/recuperar-senha/recuperar-senha.component';
import { RedefinirSenhaComponent } from './components/senha/redefinir-senha/redefinir-senha.component';
import { NgxMaskModule, IConfig } from 'ngx-mask';


@NgModule({
  declarations: [
    AppComponent,
    DashBoardComponent,
    MenuComponent,
    NavbarComponent,
    LoginComponent,
    RecuperarSenhaComponent,
    RedefinirSenhaComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({ positionClass: 'toast-top-center' }),
    ToastContainerModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    ReactiveFormsModule,
    NgbModule,
    UsuarioModule,
    PermissaoModule,
    PerfilModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : []
  ],
  providers: [
    CanActivateUser,
    ErrosService,
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
