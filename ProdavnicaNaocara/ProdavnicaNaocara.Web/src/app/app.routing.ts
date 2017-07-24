import { KupacComponent } from './components/kupac/kupac.component';
import { KupciComponent } from './components/kupci/kupci.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'kupci', pathMatch: 'full' },
  { path: 'kupci', component: KupciComponent },
  { path: 'kupci/dodavanje', component: KupacComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
