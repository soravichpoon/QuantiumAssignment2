import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  APIURL = "https://localhost:8000/";

  page : string = 'home';

  votes:any=[];
  options:any=[];
  newVote:any;

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.get_votes();
    this.get_options();
  }

  get_votes() {
    this.http.get(this.APIURL+"get_votes").subscribe((res)=>{
      this.votes = res;
    })
  }

  get_options() {
    this.http.get(this.APIURL+"get_option").subscribe((res)=>{
      this.options = res;
    })
  }

  pageChange(page : any) {
    if (page == 'home') {
      this.page = 'home';
    } else {
      this.page = 'create';
    }
  }

  async addVote(vote: any) {
    let body = new FormData();

    body.append('topicName', vote.newVotes.topicName);
    body.append('topicDetail', vote.newVotes.topicDescription);

    const res = await this.http.post(this.APIURL + "add_vote", body).toPromise();
    alert(res);

    const updatedVotes: any = await this.http.get(this.APIURL + "get_votes").toPromise();
    this.votes = updatedVotes;

    this.addOption(vote);
  }

  async addOption(vote: any){
    let id : string = this.votes[this.votes.length-1].voteDetailID;;
    let option = new FormData();

    for (var item in vote.optionDetail) {
      option.append('optionDetail', vote.optionDetail[item].detail);
      option.append('voteDetailID', id);
      await this.http.post(this.APIURL + "add_option", option).toPromise();
      option = new FormData();
    }
    
    const updatedOptions: any = await this.http.get(this.APIURL + "get_option").toPromise();
    this.options = updatedOptions;
  }

  updateScore(option: any){
    let body = new FormData();
    body.append("id", option.voteID);
    body.append("score", option.optionScore.optionScore);
    body.append("detail", option.optionScore.optionDetail);
    this.http.post(this.APIURL + "update_vote", body).subscribe((res)=>{
      alert(res);
      this.get_options();
    })
  }

}  
