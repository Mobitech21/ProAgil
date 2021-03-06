import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventosComponent } from './Componentes/eventos/eventos.component';
import { PalestrantesComponent } from './Componentes/palestrantes/palestrantes.component';
import { ContatosComponent } from './Componentes/contatos/contatos.component';
import { DashBoardComponent } from './Componentes/dashboard/dashBoard.component';
import { AppComponent } from './app.component';


const routes: Routes = [
  { path: '' , redirectTo: 'dashboard', pathMatch: 'full'},
  { path: 'eventos' , component: EventosComponent},
  { path: 'palestrantes' , component: PalestrantesComponent},
  { path: 'contatos' , component: ContatosComponent},
  { path: 'dashboard' , component: DashBoardComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
