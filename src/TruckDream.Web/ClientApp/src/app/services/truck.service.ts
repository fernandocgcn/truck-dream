import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TruckService extends BaseService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    super();
    this.baseUrl += 'truck/';
  }

  public getAll(): Observable<any[]> {
    return (
      this.httpClient.get<any[]>
        (this.baseUrl, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public insert(truck: any): Observable<any> {
    return (
      this.httpClient.post<any>
        (this.baseUrl, truck, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public update(truck: any): Observable<any> {
    return (
      this.httpClient.put<any>
        (this.baseUrl, truck, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public delete(id: number): Observable<any> {
    return (
      this.httpClient.delete<any>
        (this.baseUrl + id, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

}
