import { PonudaService } from '../../services/ponuda.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ponude',
  templateUrl: './ponude.component.html',
  styleUrls: ['./ponude.component.css']
})
export class PonudeComponent implements OnInit {

  ponude: IPonuda[];

  constructor(private ponudaService: PonudaService, private router: Router) { }

  ngOnInit() {
    this.ponudaService.getAll().subscribe((ponude: IPonuda[]) => {
      this.ponude = ponude;
    });
  }
  dodaj() {
    this.router.navigate(['ponude/dodavanje']);
  }
  izmeni(ponuda: IPonuda) {
    this.router.navigate(['ponude/izmena', ponuda.id]);
  }

  obrisi(ponuda: IPonuda) {
    if (confirm('Da li ste sigurni da zelite da izbrisete ponudu?')) {
      this.ponudaService.delete(ponuda.id).subscribe(() => {
        alert('Ponuda obrisana');
        this.ponude = this.ponude.filter((p: IPonuda) => p.id != ponuda.id);
      });
    }
  }

}
