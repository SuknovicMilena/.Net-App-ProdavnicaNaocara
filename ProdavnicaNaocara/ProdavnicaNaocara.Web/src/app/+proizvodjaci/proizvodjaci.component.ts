import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProizvodjaciService } from './services/proizvodjaci.service';
import { Proizvodjac } from './../+prodavnica/models/proizvodjac';

@Component({
  selector: 'proizvodjaci',
  templateUrl: './proizvodjaci.component.html',
  styleUrls: ['./proizvodjaci.component.scss']
})
export class ProizvodjaciComponent implements OnInit {

  private proizvodjaci: Proizvodjac[] = [
    { id: 1, ime: 'prvi', adresa: 'prva' },
    { id: 2, ime: 'drugi', adresa: 'druga' },
    { id: 3, ime: 'treci', adresa: 'treca' },
  ];

  constructor(private router: Router, private proizvodjaciService: ProizvodjaciService) { }

  ngOnInit() {
    console.log('ucitao proizvodjace');
  }

}
