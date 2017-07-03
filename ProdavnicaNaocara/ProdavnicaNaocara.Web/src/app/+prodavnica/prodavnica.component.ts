import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'prodavnica',
  templateUrl: './prodavnica.component.html',
  styleUrls: ['./prodavnica.component.scss']
})
export class ProdavnicaComponent implements OnInit {

  ngOnInit(): void {
    console.log('ucitao prodavnicu');
  }

}
