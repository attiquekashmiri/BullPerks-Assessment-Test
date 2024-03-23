import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Info } from 'src/app/_models/info';
import { BlpTokenService } from 'src/app/_services/blp-token.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css'],
})
export class InfoComponent implements OnInit {
  infoData: Info[] = [];
  constructor(private blpTokenService: BlpTokenService) { }

  ngOnInit(): void {
    this.fetchInfo();
  }
  fetchInfo() {
    this.blpTokenService.getData().subscribe((res: Info[]) => {
      this.infoData = this.convertDatesToLocalTime(res);
    });
  }
  // Function to convert UTC dates to local timezone
  private convertDatesToLocalTime(data: Info[]): Info[] {
    const offset = new Date().getTimezoneOffset(); // Get the user's timezone offset in minutes

    // Iterate over each Info object and convert the createdDate to local timezone
    return data.map((item: Info) => {
      // Check if item.createdDate is a Date object
      if (item.createdDate instanceof Date) {
        // If it's already a Date object, convert it to local timezone
        item.createdDate = new Date(item.createdDate.getTime() - (offset * 60000)); // Subtract the offset from the UTC time
      } else if (typeof item.createdDate === 'string') {
        // If it's a string, parse it to a Date object and then convert to local timezone
        item.createdDate = new Date(item.createdDate);
        item.createdDate = new Date(item.createdDate.getTime() - (offset * 60000)); // Subtract the offset from the UTC time
      }
      return item;
    });
  }

}
