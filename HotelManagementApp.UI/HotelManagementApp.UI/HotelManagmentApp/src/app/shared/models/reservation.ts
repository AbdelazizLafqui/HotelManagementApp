export interface Reservation {
    reservationId: number;
    guestName: string;
    mobileNumber: string;
    email: string;
    roomId: number;
    checkInDate: Date;
    checkOutDate: Date;
    Amount: number;
}