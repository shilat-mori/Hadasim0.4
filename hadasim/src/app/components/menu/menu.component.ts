import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  menuItems:Array<string> = ['Home', 'Patients'];
  @Output() menuItemClicked: EventEmitter<string> = new EventEmitter<string>();

  MenuItemClick(item: string): void {
    this.menuItemClicked.emit(item);
  }
}
