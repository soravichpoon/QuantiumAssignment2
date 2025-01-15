import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CreateVoteComponent } from './create-vote/create-vote.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { VoteComponent } from './vote/vote.component';
import { ReportComponent } from './report/report.component';
import { DetailComponent } from './detail/detail.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    CreateVoteComponent,
    HomeComponent,
    VoteComponent,
    ReportComponent,
    DetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
