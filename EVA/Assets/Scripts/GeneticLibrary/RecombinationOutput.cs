//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;


namespace GeneticLibrary.Recombination
{
	public class RecombinationOutput
	{
		private IList<Genotype> Genotypes;

		public int Count { get {
				return Genotypes.Count;
			}}

		public RecombinationOutput() {
			Genotypes = new List<Genotype>();
		}

		public RecombinationOutput(IList<Genotype> genotypes) {
			Genotypes = genotypes;
		}

		public void Add(Genotype genotype) {
			Genotypes.Add(genotype);
		}

		public IEnumerator GetEnumerator()
		{
			return Genotypes.GetEnumerator();
		}
	}
}

