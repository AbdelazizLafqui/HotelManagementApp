import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.sass'
})
export class ReservationComponent implements OnInit {

  reservationForm!: FormGroup;
  constructor(private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.reservationForm = this.fb.group({
      reservationId: new FormControl({ value: '', disabled: false },{ validators: [Validators.required]}),
      guestName: ['',Validators.required, Validators.minLength(5)],
      mobileNumber: [''],
      guestEmail: ['',[Validators.required, Validators.email]],
      room : ['',[Validators.required]],
      checkinDate: ['',[Validators.required]],
      checkoutDate: ['',[Validators.required]],
      reservationAmount: [{ value: '', disabled: true }],
    })
  }
}
