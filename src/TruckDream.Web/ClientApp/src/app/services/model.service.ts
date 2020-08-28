import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ModelService extends BaseService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    super();
    this.baseUrl += 'model/';
  }

  public getAll(): Observable<any[]> {
    return (
      this.httpClient.get<any[]>
        (this.baseUrl, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

}
