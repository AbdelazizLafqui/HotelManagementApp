import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrl: './room.component.sass',

})
export class RoomComponent implements OnInit {
  AddingRoomForm!: FormGroup;
  constructor(private fb: FormBuilder)
  {

  }
  ngOnInit(): void {
    this.AddingRoomForm = this.fb.group({
      roomNumber: new FormControl('',{ validators: [Validators.required]}),
      floorNumber: new FormControl('',{ validators: [Validators.required]}),
      roomType: [''],
      bedConfiguration:  [''],
      roomCapacity:  [''],
      amenities:  [''],
      pricePerNight:  [''],
      });
  }

}
