import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoomComponent } from './Modules/Room/room/room.component';
import { ReservationComponent } from './Modules/Reservation/reservation/reservation.component';
import { HomeComponent } from './Modules/Home/home/home.component';
import { LoginComponent } from './Modules/login/login.component';

const routes: Routes = [
  { path: 'room', component: RoomComponent },
  { path: 'reservation', component: ReservationComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
