import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Persona } from '../hotel/models/persona';
import { Reserva } from '../hotel/models/reserva';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Reserva[]> {
    return this.http.get<Reserva[]>(this.baseUrl + 'api/Reserva')
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Reserva[]>('Consulta Reserva', null))
      );
  }

  getId(IdHabitacion: string): Observable<Reserva> {
    const url = `${this.baseUrl + 'api/Reserva'}/${IdHabitacion}`;
      return this.http.get<Reserva>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Reserva>('Buscar Reserva', null))
      );
  }

  post(reserva: Reserva): Observable<Reserva> {
    return this.http.post<Reserva>(this.baseUrl + 'api/Reserva', reserva)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Reserva>('Registrar Reserva', null))
      );
  }
}