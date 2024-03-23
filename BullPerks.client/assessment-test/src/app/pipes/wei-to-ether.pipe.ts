import { Pipe, PipeTransform } from '@angular/core';
import BigNumber from 'bignumber.js';

@Pipe({
  name: 'weiToEther'
})
export class WeiToEtherPipe implements PipeTransform {

  transform(weiAmount: string): string {
    
    if (!weiAmount) {
      return '0'; // Return '0' if the input is null or empty
    }

    const wei = new BigNumber(weiAmount);

    // Convert wei to ether
    const etherAmount = wei.div(1e18);

    // Format the result to two decimal places
    return etherAmount.toFixed(2);
  }
}
