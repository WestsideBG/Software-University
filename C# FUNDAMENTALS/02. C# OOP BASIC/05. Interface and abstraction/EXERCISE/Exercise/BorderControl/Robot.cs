namespace BorderControl
{
    public class Robot : IRobot
    {
        private string id;
        private string fakeId;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }
        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }

    }
}
