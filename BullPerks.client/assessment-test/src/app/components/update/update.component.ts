import { Component } from '@angular/core';
import { finalize, pipe } from 'rxjs';
import { BlpTokenService } from 'src/app/_services/blp-token.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  public isDisable: boolean = false;
  constructor(private blpTokenService: BlpTokenService){}

   postData()
   {
    this.isDisable = true;
      this.blpTokenService.postUpdateData().pipe(
        finalize(()=>this.isDisable = false )
      ).subscribe(resp=>{
        alert(resp ? "Successfully Updated" : "Updation Failed") 
      });
   }
}
