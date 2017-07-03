import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ProdavnicaRoutingModule } from './prodavnica.routing';
import { ProdavnicaComponent } from './prodavnica.component';
import { ProdavnicaHeaderComponent } from './components/prodavnica-header/prodavnica-header.component';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    ProdavnicaRoutingModule
  ],
  exports: [],
  declarations: [
    ProdavnicaComponent,
    ProdavnicaHeaderComponent
  ],
  providers: [],
})
export class ProdavnicaModule { }
