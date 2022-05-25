namespace Models
{
    internal class StringPoint
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int Point { get; set; }


        public StringPoint() { }

        public StringPoint(int id, string data, int point)
        {
            Id = id;
            Data = data;
            Point = point;
        }
    }
}
