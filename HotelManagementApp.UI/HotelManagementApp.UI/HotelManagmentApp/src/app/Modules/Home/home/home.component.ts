import { Component, Input } from '@angular/core';
import { Room } from '../../../shared/models/rooms';
import { Reservation } from '../../../shared/models/reservation';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent {
  @Input() rooms!: Room[] | null;
  @Input() reservations!: Reservation[] | null;


}
