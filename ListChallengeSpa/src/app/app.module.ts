import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {
  MatButtonModule,
  MatDialogModule,
  MatInputModule,
  MatIconModule,
  MatListModule,
  MatFormFieldModule
} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';

import { AppComponent } from './app.component';
import { ListDatabase } from './list-database.service';
import { CreateNodeComponent } from './create-node/create-node.component';
import { GenerateValuesComponent } from './generate-values/generate-values.component';
import { appReducers } from './store/app.reducer';
import { AppEffects } from './store/app.effects';

@NgModule({
  declarations: [
    AppComponent,
    CreateNodeComponent,
    GenerateValuesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NoopAnimationsModule,
    FlexLayoutModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot(appReducers, {}),
    StoreDevtoolsModule.instrument({
      maxAge: 25
    }),
    EffectsModule.forRoot([AppEffects])
  ],
  providers: [ListDatabase],
  bootstrap: [AppComponent],
  entryComponents: [
    CreateNodeComponent,
    GenerateValuesComponent
  ]
})
export class AppModule { }
