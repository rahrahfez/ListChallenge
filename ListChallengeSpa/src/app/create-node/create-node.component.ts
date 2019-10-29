import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ListDatabase } from '../list-database.service';
import { Factory } from 'src/models/factory.model';

@Component({
  selector: 'app-create-node',
  templateUrl: './create-node.component.html',
  styleUrls: ['./create-node.component.css']
})
export class CreateNodeComponent implements OnInit {
  createFactoryForm: FormGroup;

  ngOnInit() {
    this.initForm();
  }

  constructor(private fb: FormBuilder, private ldb: ListDatabase) {}

  initForm() {
    this.createFactoryForm = this.fb.group({
      Label: this.fb.control('', [Validators.required, Validators.maxLength(30)])
    });
  }

  get label() { return this.createFactoryForm.controls.Label.value; }

  onCreateFactory() {
    // Creates a factory with label and default variables.
    const factory: Factory = {
      rootId: 'c266a972-2a51-4c06-865c-d4b5b6061544',
      label: this.label,
      rangeLow: 0,
      rangeHigh: 0,
      values: []
    };
    console.log(factory);
    this.ldb.CreateFactory(factory).subscribe();
  }
}
