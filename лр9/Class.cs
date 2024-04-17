using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лр9
{
    // Абстрактный класс Element
    public abstract class Element
    {
        public int Id { get; set; }
        public int InputCount { get; set; }
        public List<int> ConnectedElements { get; set; }
        public bool[] InputValues { get; set; }
        public bool OutputValue { get; set; }

        public Element(int id, int inputCount)
        {
            Id = id;
            InputCount = inputCount;
            ConnectedElements = new List<int>();
            InputValues = new bool[inputCount];
        }

        public abstract void CalculateOutput();
    }

    // Класс AND
    public class AND : Element
    {
        public AND(int id, int inputCount) : base(id, inputCount) { }

        public override void CalculateOutput()
        {
            OutputValue = InputValues.All(x => x);
        }
    }

    // Класс OR
    public class OR : Element
    {
        public OR(int id, int inputCount) : base(id, inputCount) { }

        public override void CalculateOutput()
        {
            OutputValue = InputValues.Any(x => x);
        }
    }

    // Класс Scheme
    public class Scheme
    {
        public List<Element> Elements { get; set; }

        public Scheme()
        {
            Elements = new List<Element>();
        }

        public void CalculateOutputs()
        {
            foreach (var element in Elements)
            {
                element.CalculateOutput();
            }
        }
    }
}
