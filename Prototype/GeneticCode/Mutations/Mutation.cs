﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticCode.Interfaces;

namespace GeneticCode.Mutations
{
    /// <summary>
    /// Represents a mutation.
    /// A mutation is a set of modifiers to apply to the organism. Each modifier
    /// can be applied at a custom place in the organism.
    /// </summary>
    class Mutation : IMutation
    {
        private IList<GeneticModifier> gModifiers;
        private IList<StructuralModifier> sModifiers;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Mutation()
        {
            gModifiers = new List<GeneticModifier>();
            sModifiers = new List<StructuralModifier>();
        }

        /// <summary>
        /// Add a new genetic modifier to the mutation.
        /// </summary>
        /// <param name="modifier">The modifier</param>
        public void addGeneticModifier(GeneticModifier modifier)
        {
            gModifiers.Add(modifier);
        }

        /// <summary>
        /// Add a new structural modifier to the mutation.
        /// </summary>
        /// <param name="modifier">The modifier</param>
        public void addStructuralModifier(StructuralModifier modifier)
        {
            sModifiers.Add(modifier);
        }

        /// <summary>
        /// Apply the mutation on the extension.
        /// </summary>
        /// <param name="extension">The extension where is applied the mutation.</param>
        public void apply(Extension extension)
        {
            // Apply structural modifications first.
            foreach (StructuralModifier op in sModifiers)
            {
                if(op.targetsExtension(extension)) {
                    op.execute(extension);
                }
            }

            // Apply genetic modification second.
            foreach (GeneticModifier op in gModifiers)
            {
                // Sorting if this geneticData is elligible for theses operations.
                if (op.targetsExtension(extension))
                {
                    op.execute(extension.geneticData);
                }
            } 
        }
    }
}