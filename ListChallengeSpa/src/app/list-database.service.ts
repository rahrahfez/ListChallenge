// rootid: afe3c224-c9e7-4410-9a24-0ca0b342f82d
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Factory } from 'src/models/factory.model';
import { Child } from 'src/models/child.model';
import { ValuegeneratorService } from './valuegenerator.service';

@Injectable({
  providedIn: 'root'
})
export class ListDatabase {
  readonly url = 'https://rocky-fortress-44530.herokuapp.com';

  constructor(private http: HttpClient) {}

  GetRoots() {
    return this.http.get<Factory>(this.url + '/factory');
  }

  GetValues(id: string) {
    return this.http.get<Child>(this.url + `/child/${id}/values`);
  }

  CreateFactory(factory: Factory) {
    return this.http.post<Factory>(this.url + '/factory', factory);
  }

  UpdateFactory(factory: Factory) {
    return this.http.post<Factory>(this.url + '/factory/' + factory.id, factory);
  }

  GenerateNewValues(child: Child) {
    return this.http.post<Child>(this.url + '/child', child);
  }

  DeleteChild(child: Child) {
    return this.http.delete(this.url + '/child');
  }

  DeleteAllChild(child: Child[]) {
    return this.http.delete(this.url + '/child');
  }

  DeleteFactory(id: string) {
    return this.http.delete(this.url + `/factory/${id}`);
  }
}
