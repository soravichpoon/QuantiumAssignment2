import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { OptionDetails } from '../shared/models/option.model';
import { VoteDetails } from '../shared/models/vote.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @Input() voteTopicList : VoteDetails[] = [];
  @Input() optionDetailList : OptionDetails[] = [];
}
