import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/autentication/usuario/usuario';
import { UsuarioService } from 'src/app/autentication/usuario/usuario.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{

  user$?: Observable<Usuario>;

  constructor(private usuarioService: UsuarioService, private router: Router) { }
  
  ngOnInit(): void {
    this.user$ =  this.usuarioService.retornaUsuario();
  }

  public logout(){
    this.usuarioService.logout();
    this.router.navigate(['']);
  }

}
