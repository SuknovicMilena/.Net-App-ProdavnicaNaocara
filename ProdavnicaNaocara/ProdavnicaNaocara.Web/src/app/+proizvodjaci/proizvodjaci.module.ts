import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ProizvodjaciComponent } from './proizvodjaci.component';
import { ProizvodjaciRoutingModule } from './proizvodjaci.routing';
import { ProizvodjaciService } from './services/proizvodjaci.service';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    ProizvodjaciRoutingModule
  ],
  exports: [],
  declarations: [
    ProizvodjaciComponent
  ],
  providers: [
    ProizvodjaciService
  ],
})
export class ProizvodjaciModule { }
