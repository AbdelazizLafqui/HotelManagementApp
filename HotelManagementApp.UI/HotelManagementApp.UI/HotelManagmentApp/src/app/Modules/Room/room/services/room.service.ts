import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Room } from '../../../../shared/models/room';
import { createRoomItem } from '../../../../shared/Items/createRoomItem';
import { roomLookupItem } from '../../../../shared/Items/roomLookupItem';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class RoomService {


  private addRoomSubscription?: Subscription;
  private deleteRoomSubscription?: Subscription;

  constructor(private http:HttpClient) { }

  getRooms()
  {
    return this.http.get<Room[]>('/api/Room/rooms');
  }

  getRoomsLookups()
  {
    return this.http.get<roomLookupItem[]>('/api/Room/lookups');
  }

  addRoom(room: createRoomItem) {
    this.addRoomSubscription = this.http.post<Room>('api/Room/addRoom', room).subscribe({
      complete: () =>{
        alert("Successfully added")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

  deleteRoom(id: string){
    this.deleteRoomSubscription = this.http.delete(`/api/Room/${id}`).subscribe({
      complete: () =>{
        alert("Successfully deleted")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

  unsubscribe(): void {
    this.addRoomSubscription?.unsubscribe();
    this.deleteRoomSubscription?.unsubscribe();
  }


}
