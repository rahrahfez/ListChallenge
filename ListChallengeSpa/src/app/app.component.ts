import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';

import { CreateNodeComponent } from './create-node/create-node.component';
import { ListDatabase } from './list-database.service';
import { GenerateValuesComponent } from './generate-values/generate-values.component';
import { Root } from 'src/models/root.model';
import { Factory } from 'src/models/factory.model';
import { Observable } from 'rxjs';
import { Child } from 'src/models/child.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  label: string;
  list: Root;
  root$: Observable<Factory>;
  factoryValues$: Observable<Child>;

  currentFactory: string;

  createNodeRef: MatDialogRef<CreateNodeComponent>;
  generateValuesRef: MatDialogRef<GenerateValuesComponent>;

  title = 'ListChallengeSpa';

  constructor(private ldb: ListDatabase, public dialog: MatDialog) {}

  ngOnInit() {
    this.GetList();
  }

  GetList() {
    this.root$ = this.ldb.GetRoots();
  }

  GetValues() {
    return this.ldb.GetValues(this.currentFactory);
  }

  trackFactory(index: number, factory: Factory) {
    return factory ? factory.id : undefined;
  }

  CreateNewNode() {
    this.createNodeRef = this.dialog.open(CreateNodeComponent);
    this.createNodeRef.afterClosed().subscribe(() => this.GetList());
  }

  GenerateNewValues(factory: string) {
    this.currentFactory = factory;
    localStorage.setItem('factoryId', factory);
    this.generateValuesRef = this.dialog.open(GenerateValuesComponent);
    this.generateValuesRef.afterClosed().subscribe(() => this.factoryValues$ = this.GetValues());
  }

  ngOnDestroy() {

  }
}

