namespace _06.TrafficLights
{
    public class TrafficLight
    {
        internal enum TrafficSignal
        {
            Red = 0,
            Green = 1,
            Yellow = 2
        }

        private TrafficSignal _signal;

        public string Signal
        {
            get => _signal.ToString();
            private set { TrafficSignal.TryParse(value, out _signal); }
        }

        public void ToggleSignal()
        {
            var signals = typeof(TrafficSignal).GetEnumValues();
            this._signal = (TrafficSignal)signals.GetValue((int)(_signal + 1) % signals.Length);
        }

        public override string ToString()
        {
            return this.Signal;
        }

        public TrafficLight(string signal)
        {
            this.Signal = signal;
        }
    }
}