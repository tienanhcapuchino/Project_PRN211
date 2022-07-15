namespace Project_PRN211.Models
{
    public class RoomTY
    {
        public int RoomNo { get; set; }

        public int RoomPrice { get; set; }
        public int NumberOfPersons { get; set; }

        public int Status { get; set; }

        public RoomTY()
        {
        }

        public RoomTY(int roomNo, int roomPrice, int numberOfPersons, int status)
        {
            RoomNo = roomNo;
            RoomPrice = roomPrice;
            NumberOfPersons = numberOfPersons;
            Status = status;
        }
    }
}
