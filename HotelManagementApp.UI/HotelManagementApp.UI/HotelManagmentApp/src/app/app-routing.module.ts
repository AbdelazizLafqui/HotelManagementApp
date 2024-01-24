import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoomComponent } from './Modules/Room/room/room.component';
import { ReservationComponent } from './Modules/Reservation/reservation/reservation.component';
import { HomeComponent } from './Modules/Home/home/home.component';

const routes: Routes = [
  { path: 'room', component: RoomComponent },
  { path: 'reservation', component: ReservationComponent },
  { path: 'home', component: HomeComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
