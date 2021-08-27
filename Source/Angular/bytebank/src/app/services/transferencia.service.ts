import { Transferencia } from './../models/transferencia.model';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransferenciaService {

  private listaTransferencia: any[];
  private url = 'http://localhost:3000/transferencias';

  constructor(private httpClient : HttpClient) {
    this.listaTransferencia = [];
  }

  todasTransferencias() : Observable<Transferencia[]>{
    return this.httpClient.get<Transferencia[]>(this.url);
  }

  adicionarNovaTransferencia(transferencia : Transferencia) : Observable<Transferencia> {
    transferencia.data = new Date();
    return this.httpClient.post<Transferencia>(this.url, transferencia);
  }
}
