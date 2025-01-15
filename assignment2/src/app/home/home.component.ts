import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { NewOption, NewVote, OptionDetail } from '../vote-item/option-detail.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @Input() voteTopicList : NewVote[] = [];
  @Input() optionDetailList : OptionDetail[] = [];
  @Output() updateScoreEvent = new EventEmitter<any>();

  updateOption(vote: any) {
    this.updateScoreEvent.emit({'optionScore': vote.optionScore, 'voteID': vote.voteID});
  }
}
