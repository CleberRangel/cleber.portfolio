import { AbstractControl } from '@angular/forms';
/**
 * Validator to check if a string is lower case.
 *
 * @param control
 * @returns returns an error map with the minusculo property if the validation check fails
 */
export function minusculoValidator(control: AbstractControl) {
  const valor = control.value as string;
  if (valor != valor.toLowerCase()) {
    return { minusculo: true };
  } else {
    return null;
  }
}
