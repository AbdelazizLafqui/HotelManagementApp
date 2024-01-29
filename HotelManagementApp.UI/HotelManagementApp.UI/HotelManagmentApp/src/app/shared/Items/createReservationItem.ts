export interface createReservationRequest {
    guestName: string;
    mobileNumber: string;
    email: string;
    roomId: number; 
    checkInDate: Date;
    checkOutDate: Date;
    amount: number;
  }