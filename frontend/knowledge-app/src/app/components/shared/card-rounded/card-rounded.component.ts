import { Component, OnInit, Input, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-card-rounded',
  templateUrl: './card-rounded.component.html',
  styleUrls: ['./card-rounded.component.scss']
})
export class CardRoundedComponent implements OnInit {

  @Input() titulo: string;
  @Input() nomeUsuario: string;
  @Input() avatarUsuario: string;
  @Input() bodyTemplate: any[];
  @Input() footerTemplate: any[];
  constructor() { }

  ngOnInit() {
  }

}
