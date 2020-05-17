import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';

import { AppComponent } from './app.component';
import { EventosComponent } from './Componentes/eventos/eventos.component';
import { NavibarComponent } from './Componentes/navibar/navibar.component';
import { DateTimeFormatPipe } from './Helps/DateTimeFormat.pipe';
import { ContatosComponent } from './Componentes/contatos/contatos.component';
import { DashBoardComponent } from './Componentes/dashboard/dashBoard.component';
import { PalestrantesComponent } from './Componentes/palestrantes/palestrantes.component';
import { TituloComponent } from './shared/titulo/titulo.component';

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    NavibarComponent,
    DateTimeFormatPipe,
    DashBoardComponent,
    PalestrantesComponent,
    ContatosComponent,
    TituloComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
        timeOut : 10000,
        positionClass : 'toast-bottom-right',
        preventDuplicates : true,

    }),


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
