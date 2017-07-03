import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProizvodjaciComponent } from './proizvodjaci.component';

const routes: Routes = [
  { path: '', component: ProizvodjaciComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProizvodjaciRoutingModule { }
