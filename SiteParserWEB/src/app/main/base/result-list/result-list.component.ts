import { Component, OnInit } from '@angular/core';
import { ResultModel } from 'src/app/core/models/result.model';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-result-list',
  templateUrl: './result-list.component.html',
  styleUrls: ['./result-list.component.css']
})
export class ResultListComponent implements OnInit {
  result: ResultModel[] = [];

  constructor(private _dataSevice: DataService) {}

  ngOnInit() {
    this._dataSevice.getResult()
    .subscribe(
      data => {
        this.result = data;
      },
     );
  }

 
}
