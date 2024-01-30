export interface createReservationRequest {
    guestName: string;
    mobileNumber: string;
    email: string;
    roomId: string; 
    checkInDate: Date;
    checkOutDate: Date;
    amount: number;
  }