import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'utcToLocalDate'
})
export class UtcToLocalDatePipe implements PipeTransform {

  constructor(private datePipe: DatePipe) {}

  transform(utcDate: Date | string, format: string = 'medium'): string {
    if (typeof utcDate === 'string') {
      utcDate = new Date(utcDate);
    }
    const localDate = new DatePipe('en-US').transform(utcDate, format);
    return localDate || ''; // Return empty string if localDate is null
  }

}
