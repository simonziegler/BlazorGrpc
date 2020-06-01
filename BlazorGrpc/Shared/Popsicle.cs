using MessagePack;
using Newtonsoft.Json;
using System;

namespace BlazorGrpc.Shared
{
    [MessagePackObject(keyAsPropertyName: true)]
    public abstract class Popsicle
    {
        private readonly bool performFreezeTest = false;

        private bool frozen = false;
        [JsonProperty]
        public bool Frozen { get => frozen; set => frozen = frozen ? frozen : value; }

        public void Freeze() => Frozen = true;

        protected void Setter<T>(Func<bool> equalityTest, Func<T> setter)
        {
            if (performFreezeTest && Frozen) throw new InvalidOperationException("Cannot set a property on a frozen instance");

            if (!equalityTest())
            {
                setter();
                // Do some more stuff to notify observers of a change.
            }
        }

        public Popsicle()
        {
            performFreezeTest = true;
        }

        public override string ToString()
        {
            return Frozen ? "Immutable" : "Mutable";
        }
    }
}
