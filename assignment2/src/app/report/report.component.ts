import { Component, Input } from '@angular/core';

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
      if (item.voteDetailId == this.vote.voteDetailID) {
        totalVote = totalVote + item.optionScore;
      }  
    }
    return totalVote;
  }
}
