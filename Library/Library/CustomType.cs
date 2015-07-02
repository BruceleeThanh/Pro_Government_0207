

namespace Library
{

    public static class CustomType
    {
        public enum ActiveStatusType
        {
            Inactive = 0,
            Active = 1
        }
        public enum UserType
        {

            Admin = 1,
            Partner = 2,
            Content = 3,
            User = 4
        }
        public enum PermitActionType
        {
            View = 0,
            Insert = 1,
            Update = 2,
            Delele = 3,
            Special = 4
        }
    }

    public static class BookingType
    {
        public enum PayMethod
        {
            Other = 0,
            TienMat = 1, 
            ChuyenKhoan =2,
            Sec = 3
        }
        public enum StatusPay
        {
            Other = 0,
            ChuaThanhToan = 1,
            TamUngDatCoc = 2,
            DaThanhToan = 3
        }
        public enum BookingStatus
        {
            CheckOut = 0,
            CheckIn = 1,
            Cancel = 2,
            CustomerBookingOnline = 3,
            StaffBooking =4
        }
    }
}
