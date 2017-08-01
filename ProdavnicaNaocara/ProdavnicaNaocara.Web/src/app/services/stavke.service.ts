import { Observable } from 'rxjs/Rx';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class StavkeService {

  constructor(private http: Http) { }

  getStavkeByPonudaId(id: number): Observable<IStavkaPonude[]> {
    return this.http
      .get(`http://localhost:34028/stavkePonude/ponuda/${id}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IStavkaPonude[]);
  }

  getAllProizvod(): Observable<IProizvod[]> {
    return this.http
      .get(`http://localhost:34028/stavkePonude/proizvodi`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json() as IProizvod[]);
  }
  delete(RbStavkeId: number, ponudaId: number): Observable<void> {
    return this.http
      .delete(`http://localhost:34028/stavkePonude/${RbStavkeId}/ponuda/${ponudaId}`)
      .catch((response: Response) => {
        alert(response.text());
        return Observable.throw(response);
      })
      .map(response => response.json());
  }
}
