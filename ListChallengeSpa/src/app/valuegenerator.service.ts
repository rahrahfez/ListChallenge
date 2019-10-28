import { Injectable } from '@angular/core';

import { Child } from 'src/models/child.model';

@Injectable({
  providedIn: 'root'
})
export class ValuegeneratorService {

  constructor() { }

  generateChildValues(
    min: number,
    max: number,
    numberOfValues: number,
    factory_Id: string): Child[] {
      let arr: Child[] = [];
      for (let i = 0; i < numberOfValues; i++) {
        const rand = Math.floor(Math.random() * (max - min + 1) + min);
        const child: Child = {
          factoryId: factory_Id,
          value: rand
        };
        arr[i] = child;
      }
      return arr;
  }
}
