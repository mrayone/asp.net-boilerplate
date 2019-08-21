import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'generoUsuario'
})
export class GeneroUsuarioPipe implements PipeTransform {

  transform(value: string, ...args: any[]): any {
    return value == 'F' ? 'Feminino' : 'Masculino';
  }

}
