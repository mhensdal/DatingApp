import { Component, OnInit } from '@angular/core';
import { ValuesService } from './services/values.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'DatingApp-SPA';
  values: any;

  constructor(public valuesService: ValuesService) {}

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.valuesService.getValues().subscribe(
      result => {
        this.values = result;
        console.log(result);
      },
      err => {

      }
    );
  }
}
