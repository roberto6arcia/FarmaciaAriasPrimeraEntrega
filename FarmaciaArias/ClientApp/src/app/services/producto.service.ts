import { Injectable, Inject } from '@angular/core';
import { Producto } from '../farmacia/models/producto';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
{
    this.baseUrl = baseUrl;
}

  get(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.baseUrl + 'api/Producto')
      .pipe(
          tap(_ => this.handleErrorService.log('datos enviados')),
          catchError(this.handleErrorService.handleError<Producto[]>('Consulta Producto', null))
      );
  }

  post(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl + 'api/Producto', producto)
      .pipe(
          tap(_ => this.handleErrorService.log('datos enviados')),
          catchError(this.handleErrorService.handleError<Producto>('Registrar Producto', null))
      );
  }

}
