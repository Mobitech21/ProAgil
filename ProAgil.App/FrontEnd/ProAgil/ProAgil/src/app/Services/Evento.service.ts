import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../Models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

baseUrl = 'http://localhost:5000/api/evento';

constructor(private http: HttpClient) { }

getEventoaAllEventos(): Observable<Evento[]>{
  return this.http.get<Evento[]>(this.baseUrl);
}

getEventoByTema(tema: string): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseUrl}/getBytema/${tema}`);
}

getEventoById(id: number): Observable<Evento>{
  return this.http.get<Evento>(`${this.baseUrl}/${id}`);
}

putEvento(evento: Evento){
  return this.http.put(`${this.baseUrl}/${evento.id}`, evento);
}
postEvento(evento: Evento){
  return this.http.post(`${this.baseUrl}`, evento);
}

deleteEvento(id: number){
  return this.http.delete(`${this.baseUrl}/${id}`);
}

}
