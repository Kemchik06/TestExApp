import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models/item.model';
import ItemService from '../shared/services/item.servise';
import { FormControl } from '@angular/forms';
import { ItemsCreateRequest } from '../shared/models/itemsCreateRequest.model';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  public items: Array<Item>;
  public itemsToCreate: Array<Item>;
  public newItem = new Item(); 

  constructor(private itemService: ItemService) { 
    this.items = new Array<Item>();
    this.itemsToCreate = new Array<Item>();
  }

  ngOnInit(): void {
    this.getAll();
  }

  public getAll(){
    this.itemService.getAll().subscribe(data => {
      this.items = data;
    });
  }

  public saveItems(){
    this.itemService.saveItems(this.itemsToCreate).subscribe(data =>{
      this.itemsToCreate = [];
      this.getAll();
    },
    error => console.error(error));
  }

  addItem() {
    this.itemsToCreate.push(this.newItem)
    this.newItem = new Item();
}

}
