import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { DataModel } from '../models/data.models';
import { map } from 'rxjs/operators';
import { ResultModel } from '../models/result.model';

@Injectable()
export class DataService {

  constructor(private _http: HttpClient) { }
  private dataModelSource = new BehaviorSubject<DataModel>(new DataModel());
  currentDataModel = this.dataModelSource.asObservable();

  public getResult(): Observable<Array<ResultModel>> {
    return this._http.get<any[]>('/api/base').pipe(
      map(response => {
        return response.map(e => new ResultModel(e));
      }));
  }

  public saveResult(dataModel: DataModel): Observable<number> {
      return this._http.post('/api/base', dataModel).pipe(
        map(response => {
          return dataModel.id;
        }));
  }
}
