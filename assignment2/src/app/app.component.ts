import { Component, inject, OnInit } from '@angular/core';
import { Api2Service } from './shared/service/api2.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  page : string = 'home';
  api2Service : Api2Service = inject(Api2Service);

  ngOnInit(): void {
    this.api2Service.get_votes();
    this.api2Service.get_options();
  }

  pageChange(page : any): void {
    this.page = page;
  }
}  
