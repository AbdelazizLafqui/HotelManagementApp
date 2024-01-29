import { Component, Input, OnInit } from '@angular/core';
import { Room } from '../../../shared/models/room';
import { Reservation } from '../../../shared/models/reservation';
import { RoomService } from '../../Room/room/services/room.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent implements OnInit {

  roomsColumns: string[] = ['roomNumber', 'floorNumber', 'roomType', 'bed', 'capacity', 'amenities', 'price', 'actions'];
  reservationsColumns: string[] = ['guestName', 'mobileNumber', 'email', 'roomId', 'checkInDate', 'checkOutDate', 'amount'];

  roomsDataSource = new MatTableDataSource<Room>([]);  
  reservationsDataSource = new MatTableDataSource<Reservation>([]);  
  constructor(private roomService: RoomService) {
    
  }
  ngOnInit(): void {
    this.getRooms();
  }

  getRooms(): void {
    this.roomService.getRooms().subscribe(
      (data: Room[]) => {
        this.roomsDataSource.data = data;
      },
    );
  } 
}
