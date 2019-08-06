import { Component, OnInit } from '@angular/core';
import { Router, ActivationStart, ActivatedRoute } from '@angular/router';
import { map, filter } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Logout } from 'src/app/state-manager/actions/autorizacao/autorizacao.actions';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public titulo =  'Knowledg.IO';
  constructor(private router: Router, private store: Store<AppState>) {
   }

  ngOnInit() {
    this.router.events.pipe( filter(event => event instanceof ActivationStart) )
    .subscribe(event => {
      const { snapshot } = event as ActivatedRoute;
      this.titulo =  snapshot.data.title;
     });

    }
    onLogout() {
      this.store.dispatch(new Logout());
      this.router.navigate(['/login']);
    }

}
