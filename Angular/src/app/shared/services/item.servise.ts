import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../models/item.model';
import { ItemsCreateRequest } from '../models/itemsCreateRequest.model';
import { ItemDto } from '../models/itemDto.model';

@Injectable()
export default class ItemService {
  public API = 'http://localhost:5000';
  public itemsApi = `${this.API}/items`;

  constructor(private http: HttpClient) {}

  getAll(pageSize: number, pageNumber: number): Observable<ItemDto> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("pageSize",pageSize.toString());
    queryParams = queryParams.append("pageNumber",pageNumber.toString());
    
    return this.http.get<ItemDto>(this.itemsApi, {params:queryParams});
  }

  saveItems(items: Array<Item>): Observable<Array<Item>> {
    var headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Accept": "application/json"
  });
    return this.http.post<Array<Item>>(this.itemsApi, items, {headers: headers});
  }

}