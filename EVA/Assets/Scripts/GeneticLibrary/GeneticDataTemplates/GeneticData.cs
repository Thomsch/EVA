using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticLibrary.Interfaces;
using GeneticLibrary.Mutations;

namespace GeneticLibrary
{
    public class GeneticData : IEnumerable, IDeepClonable
    {
        // Tag of the geneticData.
        public String tag { get; set; }

        private Dictionary<String, IDeepClonable> data = new Dictionary<String, IDeepClonable>();

        public GeneticData() : this("") {}

        public GeneticData(String s)
        {
            tag = s;
        }

        public void Set(String element, IDeepClonable data)
        {
            this.data[element] = data;
        }

        public IDeepClonable Get(String element) {
            return this.data[element];
        }

        public IEnumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }

        override public string ToString()
        {
            string result = "";
            foreach (KeyValuePair<String, IDeepClonable> entry in data)
            {
                result += entry.ToString() + " ";
            }
            return result;
        }

        public Object DeepClone()
        {
            var clone = new GeneticData(tag);
            foreach (KeyValuePair<String, IDeepClonable> entry in data)
            {
                clone.Set((String) entry.Key.Clone(), (IDeepClonable) entry.Value.DeepClone());
            }
            return clone;
        }
    }
}
