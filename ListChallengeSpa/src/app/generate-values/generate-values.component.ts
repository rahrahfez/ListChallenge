import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';

import { ListDatabase } from '../list-database.service';
import { ValuegeneratorService } from '../valuegenerator.service';
import { Child } from 'src/models/child.model';
import { Factory } from 'src/models/factory.model';
import { min, concatMap, takeUntil } from 'rxjs/operators';
import { from, Subscription } from 'rxjs';

const RangeValidator: ValidatorFn = (fg: FormGroup) => {
  const min = fg.get('MinValue').value;
  const max = fg.get('MaxValue').value;

  return min !== null && max !== null && min < max ? null : { range: true };
};

@Component({
  selector: 'app-generate-values',
  templateUrl: './generate-values.component.html',
  styleUrls: ['./generate-values.component.css']
})
export class GenerateValuesComponent implements OnInit, OnDestroy {
  generateValuesForm: FormGroup;
  childToBeDeleted$: Subscription;
  childs$: Subscription;

  factoryId: string;
  factoryLabel: string;

  constructor(
    private fb: FormBuilder,
    private ldb: ListDatabase,
    private vgs: ValuegeneratorService) {}

  ngOnInit() {
    this.initForm();
    this.factoryId = localStorage.getItem('factoryId');
  }

  initForm() {
    this.generateValuesForm = this.fb.group({
      MinValue: this.fb.control('', Validators.required),
      MaxValue: this.fb.control('', Validators.required),
      NumberOfValues: this.fb.control('', [Validators.required, Validators.max(15)])
    }, { validator: RangeValidator });
  }

  updateFactory() {

    const minValue = this.generateValuesForm.controls.MinValue.value;
    const maxValue = this.generateValuesForm.controls.MaxValue.value;
    const numberOfValues = this.generateValuesForm.controls.NumberOfValues.value;

    const factory: Factory = {
      id: this.factoryId,
      rangeLow: minValue,
      rangeHigh: maxValue,
      values: []
    };
    this.ldb.DeleteChildByFactoryId(this.factoryId).subscribe();
    this.ldb.UpdateFactory(factory).subscribe();

    const childs: Child[] = this.vgs.generateChildValues(minValue, maxValue, numberOfValues, this.factoryId);

    this.childs$ = from(childs)
        .pipe(
          concatMap(child => this.ldb.GenerateNewValues(child)))
          .subscribe();
  }

  deleteFactory() {
    this.factoryId = localStorage.getItem('factoryId');
    this.ldb.DeleteFactory(this.factoryId).subscribe();
    localStorage.removeItem('factoryId');
  }

  ngOnDestroy() {
    // this.childToBeDeleted$.unsubscribe();
    // this.childs$.unsubscribe();
  }
}

type ValidatorFn = (c: AbstractControl) => ValidationErrors | null;

