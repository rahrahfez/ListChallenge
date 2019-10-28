import { Action } from '@ngrx/store';
import { Factory } from 'src/models/factory.model';
import { Root } from 'src/models/root.model';
import { Child } from 'src/models/child.model';

export enum AppActions {
  LOAD_ROOT = '[APP] Load_Root',
  CREATE_FACTORY = '[APP] Create_Factory',
  UPDATE_FACTORY = '[APP] Update_Factory',
  DELETE_FACTORY = '[APP] Delete_Factory',
  GENERATE_VALUES = '[APP] Generate_Values'
}

export class LoadRoot implements Action {
  readonly type = AppActions.LOAD_ROOT;

  constructor(public payload: { root: Root }) { }
}

export class CreateFactory implements Action {
  readonly type = AppActions.CREATE_FACTORY;

  constructor(public payload: { factory: Factory }) { }
}

export class UpdateFactory implements Action {
  readonly type = AppActions.UPDATE_FACTORY;

  constructor(public payload: { factory: Factory }) { }
}

export class DeleteFactory implements Action {
  readonly type = AppActions.DELETE_FACTORY;

  constructor() {}
}

export class GenerateValues implements Action {
  readonly type = AppActions.GENERATE_VALUES;

  constructor(public payload: { value: Child }) { }
}

export type AppActionTypes =
  LoadRoot |
  CreateFactory |
  UpdateFactory |
  DeleteFactory |
  GenerateValues;
