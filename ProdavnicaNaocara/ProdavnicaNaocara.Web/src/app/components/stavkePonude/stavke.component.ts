import { StavkeService } from '../../services/stavke.service';
import { PonudaService } from '../../services/ponuda.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'stavke',
  templateUrl: './stavke.component.html',
  styleUrls: ['./stavke.component.css']
})
export class StavkeComponent implements OnInit {

  ponuda: IPonuda = {} as IPonuda;
  stavke: IStavkaPonude[];
  ponude: IPonuda[];
  proizvodi: IProizvod[];

  constructor(private stavkeService: StavkeService, private ponudaService: PonudaService, private router: Router, private route: ActivatedRoute) { }

  public ngOnInit() {
    let ponudaId = +this.route.snapshot.params['id'];
    if (ponudaId) {
      this.ponudaService.get(ponudaId).subscribe((ponuda: IPonuda) => {
        this.ponuda = ponuda;
      });
      this.stavkeService.getStavkeByPonudaId(ponudaId).subscribe((stavke: IStavkaPonude[]) => {
        this.stavke = stavke;
      });
      this.stavkeService.getAllProizvod().subscribe((proizvodi: IProizvod[]) => {
        this.proizvodi = proizvodi;
      });
    }
  }

  izmeni(ponuda: IPonuda) {
    this.router.navigate(['ponude/izmena', ponuda.id]);
  }

  obrisi(ponuda: IPonuda) {
    if (confirm('Da li ste sigurni da zelite da izbrisete ponudu?')) {
      this.ponudaService.delete(ponuda.id).subscribe(() => {
        alert('Ponuda obrisana');
        this.router.navigate(['ponude']);
        this.ponude = this.ponude.filter((p: IPonuda) => p.id != ponuda.id);
      });
    }
  }

  dodajStavku() {
    this.stavke.push({
      ponudaId: this.ponuda.id,
      kolicnina: 0,
      statusPonude: '',
    });
  }

  obrisiStavku(index: number) {
    if (confirm('Da li ste sigurni da zelite da izbrisete izabranu stavku?')) {
      this.stavke.splice(index, 1);
    }
  }

  updateStavke() {
    this.stavkeService.updateStavke(this.ponuda.id, this.stavke).subscribe(() => {
      alert('Stavke sacuvane');
    });
  }

  odustani() {
    this.router.navigate(['ponude']);
  }
}
