import { Component, EventEmitter, Output } from '@angular/core';
import { NewVote, OptionDetail } from '../vote-item/option-detail.component';

@Component({
  selector: 'app-create-vote',
  templateUrl: './create-vote.component.html',
  styleUrls: ['./create-vote.component.css']
})
export class CreateVoteComponent {
  @Output() addVoteEvent = new EventEmitter<any>();
  optionDetail : OptionDetail[] = [''].map(option => ({detail: option}));

  newVote = new NewVote();
  checkOption : boolean = false;

  addVote() {
    for (var option of this.optionDetail){
      if (option.detail == ''){
        this.checkOption = false;
      } else {
        this.checkOption = true;
      }
    }

    if (this.newVote.topicName && this.newVote.topicDescription && this.checkOption) {
        this.addVoteEvent.emit({'newVotes': this.newVote, 'optionDetail': this.optionDetail});
        this.resetForm(); 
      }
  }

  resetForm() {
    this.newVote = new NewVote();
    this.optionDetail = [''].map(option => ({detail: option}));
  }

  moreOption() {
    const temp = new OptionDetail;
    temp.detail = '';
    this.optionDetail.push(temp);
  }

}
