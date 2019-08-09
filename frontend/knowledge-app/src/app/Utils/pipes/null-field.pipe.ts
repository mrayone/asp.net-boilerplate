import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nullField'
})
export class NullFieldPipe implements PipeTransform {
  transform(value: string): string {
    return value ? value : '-';
  }
}
