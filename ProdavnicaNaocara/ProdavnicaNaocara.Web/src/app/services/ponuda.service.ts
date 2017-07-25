import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PonudaService {

  constructor(private http: Http) { }

  getAll(): Observable<IPonuda[]> {
    return this.http
      .get(`http://localhost:34028/ponude`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IPonuda[]);
  }

  get(id: number): Observable<IPonuda> {
    return this.http
      .get(`http://localhost:34028/ponude/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IPonuda);
  }
  add(ponuda: IPonuda): Observable<IPonuda> {
    return this.http
      .post(`http://localhost:34028/ponude`, ponuda)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IPonuda);
  }
  update(ponuda: IPonuda): Observable<void> {
    return this.http
      .put(`http://localhost:34028/ponude/${ponuda.id}`, ponuda)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }

  delete(id: number): Observable<void> {
    return this.http
      .delete(`http://localhost:34028/ponude/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }
}
