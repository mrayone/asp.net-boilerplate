import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

// components
import { MenuComponent } from './components/menu/menu.component';
import { DashBoardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './components/navbar/navbar.component';
import { UsuarioDetalhesComponent } from './components/usuario/usuario-detalhes/usuario-detalhes.component';
import { UsuarioListaComponent } from './components/usuario/usuario-lista/usuario-lista.component';

@NgModule({
  declarations: [
    AppComponent,
    DashBoardComponent,
    MenuComponent,
    PerfilComponent,
    NavbarComponent,
    UsuarioDetalhesComponent,
    UsuarioListaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
