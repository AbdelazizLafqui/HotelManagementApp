import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reservation } from '../../../../shared/models/reservation';
import { createReservationRequest } from '../../../../shared/Items/createReservationItem';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http:HttpClient) { }


  getReservations()
  {
    return this.http.get<Reservation[]>('/api/Reservation/reservations');
  }

  addReservation(reservation: createReservationRequest) {
    return this.http.post<Reservation>('api/Reservation/addReservation', reservation).subscribe({
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }
  deleteReservation(id: string){
    return this.http.delete(`/api/Reservation/${id}`).subscribe({
      complete: () =>{
        alert("Successfully deleted")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

}
