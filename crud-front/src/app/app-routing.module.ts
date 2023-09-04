import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivitisComponent } from './activitis/activitis.component';
import { PropertyComponent } from './property/property.component';

const routes: Routes = [
  {path:'Actividades',component:ActivitisComponent},
  {path:'Propiedades',component:PropertyComponent},
  {path:'',component:PropertyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
