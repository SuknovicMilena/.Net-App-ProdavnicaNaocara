import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class KupacService {

  constructor(private http: Http) { }

  getAll(): Observable<IKupac[]> {
    return this.http
      .get(`http://localhost:34028/kupci`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IKupac[]);
  }

  get(id: number): Observable<IKupac> {
    return this.http
      .get(`http://localhost:34028/kupci/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IKupac);
  }
  add(kupac: IKupac): Observable<IKupac> {
    return this.http
      .post(`http://localhost:34028/kupci`, kupac)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IKupac);
  }

  update(kupac: IKupac): Observable<void> {
    return this.http
      .put(`http://localhost:34028/kupci/${kupac.id}`, kupac)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }

  delete(id: number): Observable<void> {
    return this.http
      .delete(`http://localhost:34028/kupci/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }
}
