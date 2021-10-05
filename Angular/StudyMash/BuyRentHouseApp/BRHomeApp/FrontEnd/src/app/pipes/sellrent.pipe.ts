import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sellrent'
})
export class SellrentPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value == 1 ? "Purchase" : "Rent";
  }

}
