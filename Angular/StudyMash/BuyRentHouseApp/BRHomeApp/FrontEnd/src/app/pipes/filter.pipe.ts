import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString :string, propName : string): any[] {
    const resultArray = [];
    if(value.length == 0 || filterString === '' || propName === '' ){
      return value;
    }

    for (const iterator of value) {
      if(iterator[propName].toLowerCase( ).indexOf(filterString.toLowerCase( )) > -1  ){
        resultArray.push(iterator);
      }
    }

    return resultArray;
  }

}
