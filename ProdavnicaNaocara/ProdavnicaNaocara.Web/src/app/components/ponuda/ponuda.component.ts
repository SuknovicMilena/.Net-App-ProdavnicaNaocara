import { KupacService } from './../../services/kupac.service';
import { PonudaService } from '../../services/ponuda.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ponuda',
  templateUrl: './ponuda.component.html',
  styleUrls: ['./ponuda.component.css']
})
export class PonudaComponent implements OnInit {

  ponuda: IPonuda = {} as IPonuda;
  zahtev: IZahtevZaPonudom = {} as IZahtevZaPonudom;

  constructor(private kupacService: KupacService, private ponudaService: PonudaService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let ponudaId = +this.route.snapshot.params['id'];
    if (ponudaId) {
      this.ponudaService.get(ponudaId).subscribe((ponuda: IPonuda) => {
        this.ponuda = ponuda;
      });
    }
    else {
      let zahtevId = +this.route.snapshot.params['zahtevId'];
      this.kupacService.getZahtevById(zahtevId).subscribe((zahtev: IZahtevZaPonudom) => {
        this.zahtev = zahtev;
        this.ponuda.zahtevId = zahtevId;
      });

    }

  }

  dodaj() {
    this.ponudaService.add(this.ponuda).subscribe((ponuda: IPonuda) => {
      alert('Ponuda dodata!');
      this.router.navigate(['ponuda/stavkePonude', ponuda.id]);
    });
  }
  izmeni() {
    this.ponudaService.update(this.ponuda).subscribe(() => {
      alert('Ponuda izmenjena!');
      this.odustani();
    });
  }
  odustani() {
    this.router.navigate(['ponude']);
  }
}
