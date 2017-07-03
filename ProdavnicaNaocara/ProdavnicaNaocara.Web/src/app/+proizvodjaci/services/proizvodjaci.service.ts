import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Config } from './../../config';
import { Proizvodjac } from './../../+prodavnica/models/proizvodjac';

@Injectable()
export class ProizvodjaciService {

  constructor(private http: Http) {
  }

  getAll(): Observable<Proizvodjac[]> {
    return this.http
      .get(Config.apiUrl + 'proizvodjaci')
      .map((response: Response) => response.json() as Proizvodjac[]);
  }

  get(id: number): Observable<Proizvodjac> {
    return this.http
      .get(Config.apiUrl + 'proizvodjaci/' + id)
      .map((response: Response) => response.json() as Proizvodjac);
  }
}
