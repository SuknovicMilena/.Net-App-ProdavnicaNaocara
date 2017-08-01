import { KupacService } from '../../services/kupac.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'kupci',
  templateUrl: './kupci.component.html',
  styleUrls: ['./kupci.component.css']
})
export class KupciComponent implements OnInit {

  kupci: IKupac[];

  constructor(private kupacService: KupacService, private router: Router) { }

  ngOnInit() {
    this.kupacService.getAll().subscribe((kupci: IKupac[]) => {
      this.kupci = kupci;
    });
  }

  dodaj() {
    this.router.navigate(['kupci/dodavanje']);
  }

  izmeni(kupac: IKupac) {
    this.router.navigate(['kupci/izmena', kupac.id]);
  }

  idiNaZahteve(kupac: IKupac) {
    this.router.navigate(['kupci', kupac.id, 'zahtevi']);
  }

  obrisi(kupac: IKupac) {
    if (confirm('Da li ste sigurni da zelite da obrisete ovog kupca?')) {
      this.kupacService.delete(kupac.id).subscribe(() => {
        alert('Kupac obrisan!');
        this.kupci = this.kupci.filter((k: IKupac) => k.id != kupac.id);
      });

    }
  }
}
