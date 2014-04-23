using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticLibrary.BodyParts
{
    class Square : BodyPart
    {
        protected Square() : base() { }
        public Square(String tag) : base(tag) { }
        public Square(GeneticData data) : base(data) { }

        protected override Extension LocalCloneImpl()
        {
            return new Square();
        }
    }
}
