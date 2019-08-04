import { Injectable } from '@angular/core';
import { Router, ActivatedRoute, ActivationStart } from '@angular/router';
import { filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TituloService {

  public titulo: string;
  constructor(private router: Router) {
    this.router.events.pipe( filter(event => event instanceof ActivationStart) )
    .subscribe(event => {
      const { snapshot } = event as ActivatedRoute;
      this.titulo =  snapshot.data.title;
     });
   }
}
