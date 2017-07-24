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
