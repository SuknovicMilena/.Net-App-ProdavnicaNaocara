import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MestoService {

  constructor(private http: Http) { }

  getAllMesta(): Observable<IMesto[]> {
    return this.http
      .get(`http://localhost:34028/mesta`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IMesto[]);
  }

  getMestaById(id: number): Observable<IMesto> {
    return this.http
      .get(`http://localhost:34028/mesta/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IMesto);
  }

  getUlicePoMestima(mestoId: number): Observable<IUlica[]> {
    return this.http
      .get(`http://localhost:34028/ulice/ulicePoMestima/${mestoId}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IUlica[]);
  }
}
