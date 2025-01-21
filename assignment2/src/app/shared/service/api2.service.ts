import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { VoteDetails } from '../models/vote.model';
import { OptionDetails } from '../models/option.model';

@Injectable({
  providedIn: 'root'
})

export class Api2Service {
  url : string = environment.apiBaseUrl;
  votes: VoteDetails[] = [];
  options: OptionDetails[] = [];

  constructor(private http: HttpClient) { }

  get_votes(): void {
    this.http.get(this.url + '/Votes/vote')
    .subscribe({
      next: res => {
        this.votes = res as VoteDetails[]
      },
      error: err => { console.log(err) }
    })
  }

  get_options(): void {
    this.http.get(this.url + '/Votes/option')
    .subscribe({
      next: res => {
        this.options = res as OptionDetails[]
      },
      error: err => { console.log(err) }
    })
  }

  async add_vote(voteDetail: any, optionDetail: any[]) {
    const URL = `${this.url}/Votes/vote`;
    const res = await this.http.post(URL, voteDetail).toPromise();
    alert("Add Vote Successfully");

    const updatedVotes: any = await this.http.get(URL).toPromise();
    this.votes = updatedVotes;

    this.add_option(optionDetail);
  }

  async add_option(optionDetail: any[]) {
    const id : number = this.votes[this.votes.length-1].voteDetailID;;
    const URL = `${this.url}/Votes/option`;

    for (var option of optionDetail) {
      option.voteDetailId = id;
      await this.http.post(URL, option).toPromise();
    }
    
    const updatedOptions: any = await this.http.get(URL).toPromise();
    this.options = updatedOptions;
  }

  update_option(voteDetailId: number, optionName: string, optionDetails: any): void {    

    const URL = `${this.url}/Votes/updateOption?voteDetailId=${voteDetailId}&optionName=${optionName}`;
    this.http.put(URL, optionDetails).subscribe(response => {
      alert("Update Score Successfully");
    });

  }
}