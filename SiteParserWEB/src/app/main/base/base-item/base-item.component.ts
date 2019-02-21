import { Component, OnInit } from '@angular/core';
import { DataModel } from 'src/app/core/models/data.models';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DataService } from 'src/app/core/services/data.service';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-base-item',
  templateUrl: './base-item.component.html',
  styleUrls: ['./base-item.component.css']
})
export class BaseItemComponent implements OnInit {
  public word: string;
  public dataModel: DataModel;
  public dataModelOBs: Observable<DataModel>;

  data: DataModel[] = [];
  onFormChange: any;
  form: FormGroup;
  formErrors: any;
  constructor(private _dataService: DataService, private formBuilder: FormBuilder) {
    this.createForm();
   }

  ngOnInit() {
    this.dataModel = new DataModel();
    this.onFormChange = this.form.valueChanges
    .pipe(
      debounceTime(300),
      distinctUntilChanged()
    )
    .subscribe(
      data => {
        this.dataModel.text = data.text;
        this.dataModel.word = data.word;
    });
  }

  createForm() {
    this.formErrors = {
      text   : {},
      word   : {},
    };
    this.form = this.formBuilder.group({
      text : [''],
      word : ['']
    });
  }

  changeListener($event) : void {
    this.readThis($event.target);
  }

  save() {
    console.log(this.dataModel);
    this._dataService.saveResult(this.dataModel)
    .subscribe();
  }


  setValues() {
    this.form.setValue({
      text: this.dataModel.text ? this.dataModel.text : null,
      word : this.dataModel.word ? this.dataModel.word : null,
    }, {emitEvent: false});
  }

  readThis(inputValue: any) : void {
    var file:File = inputValue.files[0]; 
    var myReader:FileReader = new FileReader();

    myReader.onloadend = (e) => {
      console.log(myReader.result);
    let result = myReader.result;
    this.form.patchValue({text: myReader.result}); 
   };
    myReader.readAsText(file);
  } 
}
