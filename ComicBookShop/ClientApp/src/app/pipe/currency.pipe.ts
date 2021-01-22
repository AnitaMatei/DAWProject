import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyPipe'
})

export class CurrencyPipe implements PipeTransform {
  public transform(price: number, currencyType:any): string {
    if(currencyType ==="dollar")
        return "$"+price;
    else if (currencyType ==="leu")
        return price +" LEI";
    else if (currencyType === "euro")
        return "€"+price;
    return price+' RON';
  }
}