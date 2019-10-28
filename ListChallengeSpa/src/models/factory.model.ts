import { Child } from './child.model';

export class Factory {
  id?: string;
  rootId?: string;
  rangeLow: number;
  rangeHigh: number;
  label?: string;
  values: Child[];
}
