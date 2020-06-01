using MessagePack;

namespace BlazorGrpc.Shared
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class Person : Popsicle
    {
        private string name;
        public string Name { get => name; set => Setter(() => value == name, () => name = value); }


        private double age;
        public double Age { get => age; set => Setter(() => value == age, () => age = value); }

        public override string ToString()
        {
            return $"{Name}, {Age}, {base.ToString()}";
        }
    }
}
