import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RoomService } from './services/room.service';
import { createRoomItem } from '../../../shared/Items/createRoomItem';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrl: './room.component.sass',

})
export class RoomComponent implements OnInit, OnDestroy {

  AddingRoomForm!: FormGroup;

  constructor(private fb: FormBuilder, private roomService: RoomService) {
  }

  ngOnInit(): void {
    this.AddingRoomForm = this.fb.group({
      roomNumber: new FormControl('', { validators: [Validators.required] }),
      floorNumber: new FormControl('', { validators: [Validators.required] }),
      roomType: new FormControl('', { validators: [Validators.required] }),
      bedConfiguration: new FormControl('', { validators: [Validators.required] }),
      roomCapacity: new FormControl('', { validators: [Validators.required] }),
      amenities: new FormControl('', { validators: [Validators.required] }),
      pricePerNight: new FormControl('', { validators: [Validators.required] }),
    });
  }

  addRoom() {
    const room:  createRoomItem = {
      roomNumber: this.AddingRoomForm.get('roomNumber')?.value,
      floorNumber: this.AddingRoomForm.get('floorNumber')?.value,
      roomType: this.AddingRoomForm.get('roomType')?.value,
      bed: this.AddingRoomForm.get('bedConfiguration')?.value,
      capacity: this.AddingRoomForm.get('roomCapacity')?.value,
      amenities: this.AddingRoomForm.get('amenities')?.value,
      price: this.AddingRoomForm.get('pricePerNight')?.value,
    };

    this.roomService.addRoom(room);

    this.AddingRoomForm.reset();

  }

  ngOnDestroy(): void {
    this.roomService.unsubscribe();
  }


}
