import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProdavnicaComponent } from './prodavnica.component';

// const routes: Routes = [
//   {
//     path: '',
//     component: ProdavnicaComponent,
//     children: [
//       { path: '', redirectTo: 'proizvodjaci', pathMatch: 'full' },
//       { path: 'proizvodjaci', loadChildren: './components/proizvodjaci/proizvodjaci.module#ProizvodjaciModule' },
//     ]
//   }
// ];

const routes: Routes = [
  {
    path: '',
    component: ProdavnicaComponent,
    children: [
      {
        path: '',
        redirectTo: 'proizvodjaci',
      },
      {
        path: 'proizvodjaci',
        loadChildren: '../+proizvodjaci/proizvodjaci.module#ProizvodjaciModule'
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProdavnicaRoutingModule { }
