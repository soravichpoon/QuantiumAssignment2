import { Component, inject } from '@angular/core';
import { OptionDetail } from '../shared/models/option-detail.model';
import { Api2Service } from '../shared/service/api2.service';
import { VoteDetails } from '../shared/models/vote.model';
import { OptionDetails } from '../shared/models/option.model';

@Component({
  selector: 'app-create-vote',
  templateUrl: './create-vote.component.html',
  styleUrls: ['./create-vote.component.css']
})
export class CreateVoteComponent {
  optionDetail : OptionDetail[] = [''].map(option => ({detail: option}));

  newVotes = new VoteDetails();
  checkOption : boolean = false;
  api2Service: Api2Service = inject(Api2Service);

  addVote(): void {
    for (var option of this.optionDetail){
      if (option.detail == ''){
        this.checkOption = false;
      } else {
        this.checkOption = true;
      }
    }

    if (this.newVotes.topicName && this.newVotes.topicDetail && this.checkOption) {
      let optDetails = new OptionDetails();
      const optionDetailList = [];
      
      for (var option of this.optionDetail) {
        optDetails.optionName = option.detail;
        optionDetailList.push(optDetails);
        optDetails = new OptionDetails();
      }

      this.api2Service.add_vote(this.newVotes, optionDetailList);
      this.resetForm(); 
    }

  }

  resetForm(): void {
    this.newVotes = new VoteDetails();
    this.optionDetail = [''].map(option => ({detail: option}));
  }

  moreOption(): void {
    const temp = new OptionDetail;
    temp.detail = '';
    this.optionDetail.push(temp);
  }

}
