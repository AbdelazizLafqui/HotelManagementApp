import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reservation } from '../../../../shared/models/reservation';
import { createReservationRequest } from '../../../../shared/Items/createReservationItem';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {


  private addReservationSubscription?: Subscription;
  private deleteReservationSubscription?: Subscription;

  constructor(private http:HttpClient) { }


  getReservations()
  {
    return this.http.get<Reservation[]>('/api/Reservation/reservations');
  }

  addReservation(reservation: createReservationRequest) {
    this.addReservationSubscription = this.http.post<Reservation>('api/Reservation/addReservation', reservation).subscribe({
      complete: () =>{
        alert("Successfully added")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

  deleteReservation(id: string){
    this.deleteReservationSubscription = this.http.delete(`/api/Reservation/${id}`).subscribe({
      complete: () =>{
        alert("Successfully deleted")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

  unsubscribe(): void {
    this.addReservationSubscription?.unsubscribe();
    this.deleteReservationSubscription?.unsubscribe();
  }


}
