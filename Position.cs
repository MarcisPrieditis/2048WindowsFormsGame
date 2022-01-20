using System.Reflection.Emit;

namespace Game2048
{
    public class Position
    {
        private Label _labels;
        public int Value { get; set; }

        public Position()
        {
            _labels = new Label();
            Value = 0;
        }
    }
}