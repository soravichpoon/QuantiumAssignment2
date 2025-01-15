import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {
  @Input() vote : any;
  @Input() option : any;                 

  calTotal(option: any): number{
    var totalVote = 0;
    for (var item of option) {
      if (item.voteDetailID == this.vote.voteDetailID) {
        totalVote = totalVote + item.optionScore;
      }  
    }
    console.log(totalVote);
    return totalVote;
  }
}
