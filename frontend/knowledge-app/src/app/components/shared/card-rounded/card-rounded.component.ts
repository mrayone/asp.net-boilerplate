import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import {Md5} from 'ts-md5/dist/md5';
@Component({
  selector: 'app-card-rounded',
  templateUrl: './card-rounded.component.html',
  styleUrls: ['./card-rounded.component.scss']
})
export class CardRoundedComponent implements OnInit {

  @Input() titulo: string;
  @Input() nomeUsuario = '';
  @Input() email = '';
  @Input() bodyTemplate: any[];
  @Input() footerTemplate: any[];

  avatar = '';
  constructor() { }

  ngOnInit() {
    const md5 = new Md5();
    this.avatar = `https://gravatar.com/avatar/${ md5.appendStr(this.email).end() }?s=180`;
  }

}
