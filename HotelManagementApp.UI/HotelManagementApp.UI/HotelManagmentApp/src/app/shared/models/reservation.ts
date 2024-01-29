export interface Reservation {
    reservationId: string;
    guestName: string;
    mobileNumber: string;
    email: string;
    roomId: number;
    checkInDate: Date;
    checkOutDate: Date;
    amount: number;
}