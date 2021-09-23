import { FormGroup } from '@angular/forms';

/**
 * From validator to check if user name and passwords are the same.
 *
 * @param control
 * @returns returns an error map with the senhaIgualUsuario property if the validation check fails
 */
export function usuarioSenhaIguaisValidator(formGroup: FormGroup) {
  const username = formGroup.get('userName')?.value ?? '';
  const password = formGroup.get('password')?.value ?? '';

  if (username.trim() + password.trim()) {
    return username !== password ? null : { senhaIgualUsuario: true };
  } else {
    return null;
  }
}
