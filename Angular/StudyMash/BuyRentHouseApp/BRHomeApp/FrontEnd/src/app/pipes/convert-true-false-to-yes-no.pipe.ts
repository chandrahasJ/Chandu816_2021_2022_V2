import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertTrueFalseToYesNo'
})
export class ConvertTrueFalseToYesNoPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value == true ? "Yes" : "No";
  }

}
