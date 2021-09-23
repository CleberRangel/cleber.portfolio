import { AbstractControl } from '@angular/forms';
import { NovoUsuarioService } from './novo-usuario.service';
import { Injectable } from '@angular/core';
import { first, map, switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UsuarioExisteService {
  constructor(private novoUsuarioService: NovoUsuarioService) {}

  /**
   * Validates if user name is already in use.
   * @returns returns an error map with the usuarioExistente property if the validation check fails
   */
  usuarioJaExiste() {
    return (control: AbstractControl) => {
      return (
        control.valueChanges.pipe(
          switchMap((nomeUsuario) =>
            this.novoUsuarioService.verificarUsuario(nomeUsuario)
          ),
          map((usuarioExiste) =>
          usuarioExiste ? { usuarioExistente: true } : null
        ),
        first()
        )
      );
    };
  }
}
