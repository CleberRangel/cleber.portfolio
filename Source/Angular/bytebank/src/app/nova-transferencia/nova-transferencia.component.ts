import { TransferenciaService } from './../services/transferencia.service';
import { Component, EventEmitter, Output } from '@angular/core';
import { Transferencia } from '../models/transferencia.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nova-tranferencia',
  templateUrl: './nova-transferencia.component.html',
  styleUrls: ['./nova-transferencia.component.scss'],
})
export class NovaTransferenciComponent {

  @Output() valoresComErro = new EventEmitter<string>();


  valor!: number;
  destino!: number;

  constructor(private service: TransferenciaService,
    private router: Router) {

  }

  transferir() {
    console.log('Transferência realizada');

    if (this.ehValido()) {

      const valorParaEmitir: Transferencia = { valor: this.valor, destino: this.destino };

      this.service.adicionarNovaTransferencia(valorParaEmitir)
        .subscribe(resultado => {

          console.log(resultado);
          this.limparCampos();
          this.router.navigateByUrl('extrato');

        },
          error => console.error(error));
    }
  }

  limparCampos() {
    this.valor = 0;
    this.destino = 0;
  }

  private ehValido() {
    const valido = this.valor > 0;
    const destino = this.destino > 0;
    if (!valido && !destino) {
      this.valoresComErro.emit('Informe um valor válido');
    }
    return valido;
  }
}
