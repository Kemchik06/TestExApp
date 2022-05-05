import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../models/item.model';
import { ItemsCreateRequest } from '../models/itemsCreateRequest.model';

@Injectable()
export default class ItemService {
  public API = 'http://localhost:5000';
  public itemsApi = `${this.API}/items`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Item>> {
    return this.http.get<Array<Item>>(this.itemsApi);
  }

  saveItems(items: Array<Item>): Observable<Array<Item>> {
    var headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Accept": "application/json"
  });
    return this.http.post<Array<Item>>(this.itemsApi, items, {headers: headers});
  }

}