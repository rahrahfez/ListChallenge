import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';

import { LoadRoot, AppActions, CreateFactory, DeleteFactory, UpdateFactory, GenerateValues } from './app.actions';
import { ListDatabase } from '../list-database.service';
import { map, tap, switchMap } from 'rxjs/operators';

@Injectable()
export class AppEffects {
  @Effect({ dispatch: false }) loadRoot$ = this.action$
    .pipe(
      ofType<LoadRoot>(AppActions.LOAD_ROOT),

  );

  @Effect({ dispatch: false })
  createFactory$ = this.action$.pipe(
    ofType<CreateFactory>(AppActions.CREATE_FACTORY)
  );

  @Effect({ dispatch: false })
  updateFactory$ = this.action$.pipe(
    ofType<UpdateFactory>(AppActions.UPDATE_FACTORY)
  );

  @Effect({ dispatch: false })
  deleteFactory$ = this.action$.pipe(
    ofType<DeleteFactory>(AppActions.DELETE_FACTORY)
  );

  @Effect({ dispatch: false })
  generateValues$ = this.action$.pipe(
    ofType<GenerateValues>(AppActions.GENERATE_VALUES)
  );
  constructor(private action$: Actions, private ldb: ListDatabase) {}
}
