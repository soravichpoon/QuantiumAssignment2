import { Component, inject, Input } from '@angular/core';
import { Api2Service } from '../shared/service/api2.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent {
  @Input() votes : any;
  @Input() options : any;
  voteOption : any[] = [];
  voteID : number = 0;
  api2Service : Api2Service = inject(Api2Service);

  chooseVote(opt: any): void {
    opt.optionIsVote = true;
    for (var item of this.options) {
      if (item != opt) {
        item.optionIsVote = false;
      }
    }
  }

  submit(): void {
    let indexx : number = 0;
    
    for (let [i, item] of this.options.entries()) {
      if (item.optionIsVote == true) {
        item.optionScore = item.optionScore + 1;
        this.voteID = item.voteDetailId;
        indexx = i;
      }
    }
  
    this.api2Service.update_option(this.voteID, this.options[indexx].optionName, this.options[indexx]);
  }
}
