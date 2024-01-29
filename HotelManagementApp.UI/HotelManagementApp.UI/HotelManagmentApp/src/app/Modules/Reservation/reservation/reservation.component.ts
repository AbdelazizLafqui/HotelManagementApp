import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from './services/reservation.service';
import { createReservationRequest } from '../../../shared/Items/createReservationItem';
import { RoomService } from '../../Room/room/services/room.service';
import { roomLookupItem } from '../../../shared/Items/roomLookupItem';
@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.sass'
})
export class ReservationComponent implements OnInit {

  reservationForm!: FormGroup;
  roomLookupItems!: roomLookupItem[];
  constructor(private fb: FormBuilder, private reservationService: ReservationService, private roomService: RoomService) {

  }

  ngOnInit(): void {
    this.reservationForm = this.fb.group({
      guestName: ['', Validators.required, Validators.minLength(5)],
      mobileNumber: [''],
      guestEmail: ['', [Validators.required, Validators.email]],
      room: ['', [Validators.required]],
      checkinDate: ['', [Validators.required]],
      checkoutDate: ['', [Validators.required]],
      reservationAmount: [{ value: '', disabled: true }],
    })
  }

  addReservation() {
    const room: createReservationRequest = {
      guestName: this.reservationForm.get('guestName')?.value,
      mobileNumber: this.reservationForm.get('mobileNumber')?.value,
      email: this.reservationForm.get('guestEmail')?.value,
      roomId: parseInt(this.reservationForm.get('room')?.value),
      checkInDate: this.reservationForm.get('checkinDate')?.value,
      checkOutDate: this.reservationForm.get('checkoutDate')?.value,
      amount: this.reservationForm.get('reservationAmount')?.value,
    };

    this.reservationService.addReservation(room);
  }
  getRooms(): void {
    this.roomService.getRoomsLookups().subscribe(
      (data: roomLookupItem[]) => {
        this.roomLookupItems = data;
      },
    );
  }


}
