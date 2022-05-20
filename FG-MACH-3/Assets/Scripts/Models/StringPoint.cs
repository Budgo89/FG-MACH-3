namespace Models
{
    internal class StringPoint
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public string Point { get; set; }

        public StringPoint(string id, string data, string point)
        {
            Id = id;
            Data = data;
            Point = point;
        }
    }
}
