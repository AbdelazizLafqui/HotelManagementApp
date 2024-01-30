import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from './services/reservation.service';
import { createReservationRequest } from '../../../shared/Items/createReservationItem';
import { RoomService } from '../../Room/room/services/room.service';
import { roomLookupItem } from '../../../shared/Items/roomLookupItem';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.sass'
})
export class ReservationComponent implements OnInit, OnDestroy {

  reservationForm!: FormGroup;
  roomLookupItems!: roomLookupItem[];
  selectedRoom!: roomLookupItem;
  
  private roomsLookupSubscription?: Subscription;
  private selectedRoomSubscription?: Subscription;

  constructor(private fb: FormBuilder, private reservationService: ReservationService, private roomService: RoomService) {

  }

  ngOnInit(): void {
    this.reservationForm = this.fb.group({
      guestName: ['', Validators.required, Validators.minLength(5)],
      mobileNumber: ['',Validators.required],
      guestEmail: ['', [Validators.required, Validators.email]],
      room: ['', [Validators.required]],
      checkInDate: ['', [Validators.required]],
      checkOutDate: ['', [Validators.required]],
      reservationAmount: [{ value: '', disabled: true }],
    },);

    this.selectedRoomSubscription = this.reservationForm.get('room')?.
    valueChanges.subscribe((selectedRoom: roomLookupItem) => {
      this.selectedRoom = selectedRoom;
      if (selectedRoom) {
        this.updatePrice();
      }
    });
    this.getRoomsLookups();
  }

  dateRangeValidator() {
    const checkInDate = this.reservationForm.get('checkInDate')?.value;
    const checkOutDate = this.reservationForm.get('checkOutDate')?.value;

    if (checkInDate && checkOutDate && checkInDate > checkOutDate) {
      this.reservationForm.get('checkOutDate')?.setErrors({ dateRange: true });
      this.reservationForm
    } else {
      this.reservationForm.get('checkOutDate')?.setErrors(null);
    }
  }
  updatePrice() {
    const checkInDate = this.reservationForm.get('checkInDate')?.value;
    const checkOutDate = this.reservationForm.get('checkOutDate')?.value;
    if(checkInDate === "" && checkOutDate === "" && this.selectedRoom)
    {
      return;
    }


    const millisecondsPerDay = 24 * 60 * 60 * 1000;
    const differenceInMilliseconds = new Date(checkOutDate).getTime() - new Date(checkInDate).getTime();
    var daysDifference = Math.ceil(differenceInMilliseconds / millisecondsPerDay);
    var amount = this.selectedRoom!.price * daysDifference;
    if (amount>0) {
      this.reservationForm.get('reservationAmount')!.setValue(amount);
    } else {
      this.reservationForm.get('reservationAmount')!.setValue(0);
    }
  }

  onCheckDateChange() {
    this.dateRangeValidator();
    this.updatePrice();
  }
  addReservation() {
    const reservation: createReservationRequest = {
      guestName: this.reservationForm.get('guestName')?.value,
      mobileNumber: this.reservationForm.get('mobileNumber')?.value,
      email: this.reservationForm.get('guestEmail')?.value,
      roomId: this.selectedRoom?.id ?? "",
      checkInDate: this.reservationForm.get('checkInDate')?.value,
      checkOutDate: this.reservationForm.get('checkOutDate')?.value,
      amount: this.reservationForm.get('reservationAmount')?.value,
    };

    this.reservationService.addReservation(reservation);
    this.reservationForm.reset();
  }

  getRoomsLookups(): void {
    this.roomsLookupSubscription = this.roomService.getRoomsLookups().subscribe(
      (data: roomLookupItem[]) => {
        this.roomLookupItems = data;
      },
    );
  }

  ngOnDestroy(): void {
    this.roomsLookupSubscription?.unsubscribe();
    this.selectedRoomSubscription?.unsubscribe();
    this.reservationService.unsubscribe();

  }


}
