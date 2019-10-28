import { Root } from '../../models/root.model';
import { Factory } from 'src/models/factory.model';
import { Child } from 'src/models/child.model';

export interface IAppState {
  root: Root;
  factory: Factory;
  child: Child;
}

export const initialAppState: IAppState = {
  root: null,
  factory: null,
  child: null
};

