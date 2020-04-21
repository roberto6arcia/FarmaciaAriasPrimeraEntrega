import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductoConsultaComponent } from './Farmacia/producto-consulta/producto-consulta.component';
import { ProductoRegistroComponent } from './Farmacia/producto-registro/producto-registro.component';

const routes: Routes = [
  {path: 'productoConsulta', component: ProductoConsultaComponent},
 {path: 'productoRegistro',component: ProductoRegistroComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
