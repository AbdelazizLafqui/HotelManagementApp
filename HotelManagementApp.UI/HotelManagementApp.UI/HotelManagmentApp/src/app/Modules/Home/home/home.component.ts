import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Room } from '../../../shared/models/room';
import { Reservation } from '../../../shared/models/reservation';
import { RoomService } from '../../Room/room/services/room.service';
import { MatTableDataSource } from '@angular/material/table';
import { ReservationService } from '../../Reservation/reservation/services/reservation.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent implements OnInit, OnDestroy {


  roomsColumns: string[] = ['roomNumber', 'floorNumber', 'roomType', 'bed', 'capacity', 'amenities', 'price', 'actions'];
  reservationsColumns: string[] = ['guestName', 'mobileNumber', 'email', 'roomId', 'checkInDate', 'checkOutDate', 'amount', 'actions'];

  roomsDataSource = new MatTableDataSource<Room>([]);
  reservationsDataSource = new MatTableDataSource<Reservation>([]);

  private roomsSubscription?: Subscription;
  private reservationsSubscription?: Subscription;

  constructor(private roomService: RoomService, private reservationService: ReservationService) {

  }

  ngOnInit(): void {
    this.getRooms();
    this.getReservations();
  }

  onRoomDelete(row: any) {
    this.roomService.deleteRoom(row.id);
    this.getRooms();
  }
  
  onReservationDelete(row: any) {
    this.reservationService.deleteReservation(row.id);
    this.getReservations();
  }

  getRooms(): void {
    this.roomsSubscription = this.roomService.getRooms().subscribe(
      (data: Room[]) => {
        this.roomsDataSource.data = data;
      },
    );
  }

  getReservations(): void {
    this.reservationsSubscription = this.reservationService.getReservations().subscribe(
      (data: Reservation[]) => {
        this.reservationsDataSource.data = data;
      },
    );
  }

  ngOnDestroy(): void {
    this.roomsSubscription?.unsubscribe();
    this.reservationsSubscription?.unsubscribe();
    this.roomService.unsubscribe();
  }

}
