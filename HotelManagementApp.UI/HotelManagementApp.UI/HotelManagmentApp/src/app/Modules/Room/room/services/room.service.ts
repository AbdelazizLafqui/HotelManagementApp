import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Room } from '../../../../shared/models/room';
import { createRoomItem } from '../../../../shared/Items/createRoomItem';
import { roomLookupItem } from '../../../../shared/Items/roomLookupItem';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

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
    return this.http.post<Room>('api/Room/addRoom', room).subscribe({
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }
  deleteRoom(id: string){
    return this.http.delete(`/api/Room/${id}`).subscribe({
      complete: () =>{
        alert("Successfully deleted")
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      }
    });
  }

}
