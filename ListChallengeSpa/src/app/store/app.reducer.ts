import { initialAppState, IAppState } from './app.state';
import { MetaReducer } from '@ngrx/store';

import { environment } from 'src/environments/environment';
import { Root } from 'src/models/root.model';
import { AppActions, AppActionTypes } from '../store/app.actions';
import { Factory } from 'src/models/factory.model';

export function appReducers(state = initialAppState, action: AppActionTypes) {
  switch (action.type) {
    case AppActions.LOAD_ROOT:
      return { ...state, root: action.payload.root };
    case AppActions.CREATE_FACTORY:
      return { ...state, factory: action.payload.factory };
    case AppActions.UPDATE_FACTORY:
      return { ...state, factory: action.payload.factory };
    case AppActions.DELETE_FACTORY:
      return { ...state };
    case AppActions.GENERATE_VALUES:
      return { ...state, value: action.payload.value };
    default:
      return state;
  }
}

export const metaReducers: MetaReducer<IAppState>[] = !environment.production ? [] : [];
