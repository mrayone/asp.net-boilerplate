import { Component, OnInit } from '@angular/core';
import { Router, ActivationStart, ActivatedRoute } from '@angular/router';
import { map, filter } from 'rxjs/operators';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public title =  'Knowledg.IO';
  constructor(private router: Router) {
   }

  ngOnInit() {
    this.router.events.pipe( filter(event => event instanceof ActivationStart) )
    .subscribe(event => {
      const { snapshot } = event as ActivatedRoute;
      this.title =  snapshot.data.title;
     });
  }

}
