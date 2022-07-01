import { Injectable } from '@angular/core';

const KEY = 'token';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

 public retornaToken(): string{
    return localStorage.getItem(KEY) ?? '';
  }

  public salvaToken(token: string){
    localStorage.setItem(KEY, token);
  }

  public excluiToken(){
    localStorage.removeItem(KEY);
  }

  public possuiToken(): boolean{
    return !! this.retornaToken();
  }
}
