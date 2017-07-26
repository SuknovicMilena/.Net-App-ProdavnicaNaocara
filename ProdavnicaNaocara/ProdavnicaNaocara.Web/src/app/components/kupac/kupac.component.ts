import { MestoService } from './../../services/mesto.service';
import { KupacService } from './../../services/kupac.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'kupac',
  templateUrl: './kupac.component.html',
  styleUrls: ['./kupac.component.css']
})

export class KupacComponent {

  kupac: IKupac = {} as IKupac;
  ulica: IUlica = {} as IUlica;
  adresa: IAdresa = {} as IAdresa;
  mesta: IMesto[];
  ulice: IUlica[];
  mestoId: number;

  constructor(private kupacService: KupacService, private mestoService: MestoService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    let kupacId = +this.route.snapshot.params['id'];
    if (kupacId) {
      this.kupacService.get(kupacId).subscribe((kupac: IKupac) => {
        this.kupac = kupac;
      });
    }
    this.mestoService.getAllMesta().subscribe((mesta: IMesto[]) => {
      this.mesta = mesta;
    });
  }

  vratiSveUliceZaMesto(mestoId: number) {
    this.mestoService.getUlicePoMestima(mestoId).subscribe((ulice: IUlica[]) => {
      this.ulice = ulice;
    });
  }

  dodaj() {

    this.kupacService.add(this.kupac).subscribe((k: IKupac) => {
      alert('Kupac dodat!');
      this.odustani();
    });
  }
  izmeni() {
    this.kupacService.update(this.kupac).subscribe(() => {
      alert('Kupac izmenjen!');
      this.odustani();
    });
  }

  odustani() {
    this.router.navigate(['kupci']);
  }
}
