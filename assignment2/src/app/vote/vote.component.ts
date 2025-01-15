import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent {
  @Input() vote : any;
  @Input() option : any;
  @Output() newVoteEvent = new EventEmitter<any>();
  voteOption : any[] = [];
  voteID : number = 0;

  chooseVote(opt: any) {
    opt.optionIsVote = true;
    for (var item of this.option) {
      if (item != opt) {
        item.optionIsVote = false;
      }
    }
  }

  submit() {
    let indexx : number = 0;
    
    for (let [i, item] of this.option.entries()) {
      if (item.optionIsVote == true) {
        item.optionScore = item.optionScore + 1;
        this.voteID = item.voteDetailID;
        indexx = i;
      }
    }
    this.newVoteEvent.emit({'optionScore': this.option[indexx], 'voteID': this.voteID});
  }
}
