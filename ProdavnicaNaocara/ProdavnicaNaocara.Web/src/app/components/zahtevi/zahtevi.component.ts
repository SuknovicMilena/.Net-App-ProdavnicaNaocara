import { KupacService } from './../../services/kupac.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'zahtevi',
  templateUrl: './zahtevi.component.html',
  styleUrls: ['./zahtevi.component.css']
})

export class ZahteviComponent {

  zahtevi: IZahtevZaPonudom[];
  kupac: IKupac = {} as IKupac;

  constructor(private kupacService: KupacService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let kupacId = +this.route.snapshot.params['id'];
    if (kupacId) {
      this.kupacService.getZahtevi(kupacId).subscribe((zahtevi: IZahtevZaPonudom[]) => {
        this.zahtevi = zahtevi;
      });
      this.kupacService.get(kupacId).subscribe((kupac: IKupac) => {
        this.kupac = kupac;
      });
    }
  }
  idiNaPonudu(zahtev: IZahtevZaPonudom) {
    this.router.navigate(['ponude/dodavanje/zahtevi', zahtev.id]);

  }
}
