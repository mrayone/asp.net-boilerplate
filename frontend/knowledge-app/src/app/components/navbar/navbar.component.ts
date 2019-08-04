import { Component, OnInit } from '@angular/core';
import { Router, ActivationStart, ActivatedRoute } from '@angular/router';
import { map, filter } from 'rxjs/operators';
import { TituloService } from 'src/app/services/titulo.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public titulo =  'Knowledg.IO';
  constructor(private router: Router, private tituloService: TituloService) {
   }

  ngOnInit() {
    this.titulo = this.tituloService.titulo;
  }

}
