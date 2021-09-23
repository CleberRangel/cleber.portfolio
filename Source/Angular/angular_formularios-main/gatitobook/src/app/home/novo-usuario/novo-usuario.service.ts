import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NovoUsuario } from './novo-usuario';

@Injectable({
  providedIn: 'root'
})
export class NovoUsuarioService {

  constructor(private http: HttpClient) { }

  cadastrarNovoUsuario(novoUsuario: NovoUsuario) : Observable<any>{
    return this.http.post('http://localhost:3000/user/signup', novoUsuario);
  }

  verificarUsuario(nomeUsuario: string): Observable<any>{
    return this.http.get(`http://localhost:3000/user/exists/${nomeUsuario}`)
  }

}
