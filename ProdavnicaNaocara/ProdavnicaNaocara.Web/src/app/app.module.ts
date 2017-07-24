import { KupacComponent } from './components/kupac/kupac.component';
import { MestoService } from './services/mesto.service';
import { KupacService } from './services/kupac.service';
import { KupciComponent } from './components/kupci/kupci.component';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AppRoutingModule

  ],
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    KupciComponent,
    KupacComponent
  ],
  providers: [
    KupacService,
    MestoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
