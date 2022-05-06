import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models/item.model';
import ItemService from '../shared/services/item.servise';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  public items: Array<Item>;
  public itemsToCreate: Array<Item>;
  public newItem = new Item(); 
  public pageSize = 5;
  public pageNumber = 1;
  public itemsCount = 0;
  public buttonsArray = new Array();

  constructor(private itemService: ItemService) { 
    this.items = new Array<Item>();
    this.itemsToCreate = new Array<Item>();
  }

  ngOnInit(): void {
    this.getAll(this.pageNumber);
  }

  public getAll(pageNumber){
    this.itemService.getAll(this.pageSize, pageNumber).subscribe(data => {
      this.items = data.items;
      this.itemsCount = data.itemsCount;
      this.buttonsArray = Array.from({length: Math.ceil(this.itemsCount/this.pageSize)}, (_, i) => i + 1)
    });
  }

  public saveItems(){
    this.itemService.saveItems(this.itemsToCreate).subscribe(data =>{
      this.itemsToCreate = [];
      this.getAll(this.pageNumber);
    },
    error => console.error(error));
  }

  addItem() {
    this.itemsToCreate.push(this.newItem)
    this.newItem = new Item();
}
}
