﻿using UnityEngine;
using System.Collections;
using GeneticLibrary.Recombination;
using GeneticLibrary;
using Tools;
using GeneticLibrary.Mutations;
using GeneticLibrary.Mutations.GeneticModifiers;
using GeneticLibrary.Collections;

namespace States {
	public class Adult : State {
		private static float OrganismSight = Simulation.OrganismSight;
		private static Probability mutation1 = new Probability(0.1);
		public State inner;

		public int NoNewChild {get; set;}

		public Adult(Organism organism, DUpdateState updateState) : base(organism, updateState) {
			Debug.Log(Organism + " is adult");
			inner = new Movement(Organism, MovementToReproduction);
			NoNewChild = 0;
		}

		public override string Tag() {
			return "Adult";
		}

		#region State changing methods

		/// <summary>
		/// Called directly inside the state.
		/// </summary>
		public void ReproductionToMovement() {
			inner = new Movement(Organism, MovementToReproduction);
		}

		public void MovementToReproduction() {
			RaycastHit hit;
			var rayDirection = Organism.gameObject.transform.forward;
			Debug.DrawRay(Organism.gameObject.transform.position, rayDirection * OrganismSight);
			Physics.Raycast(Organism.gameObject.transform.position, rayDirection, out hit, OrganismSight);
			
			if(hit.collider != null && hit.collider.CompareTag(Simulation.OrganismTag)) {

				// Récupération de l'instance de script.s
				Organism other = hit.collider.gameObject.GetComponent<Organism>();

				if(NoNewChild <= 0 && other.State.Tag() == Organism.State.Tag()) {
					Adult a = (Adult) Organism.State;
					Adult b = (Adult) other.GetComponent<Organism>().State;

					a.inner = new Reproduction(Organism, other, null, true);
					b.inner = new Reproduction(other, Organism, null, false);
				}
			}
		}
		#endregion

		#region implemented abstract members of State
		public override void Action ()
		{
			inner.Update();

			Organism.Age++;
			if(NoNewChild > 0) {
				NoNewChild--;
			}

//			// Mutation during adult life.
//			if(mutation1.Test()) {
//				Mutation m = new Mutation();
//
//				m.AddGeneticModifier(new Blur(Set.ALL, new Set(new [] {"scale"}), 0.1f));
//				Debug.Log("Mutation");
////
////				Organism.Genotype.Mutate(m);
////				Organism.ModifyPhenotype(Organism.Genotype); // Not working as intendeed because of position attribute reset.
//
//				// Need Organisme.Mutate(M); for convienience.
//			}
		}

		public override void FixedAction ()
		{
			inner.FixedUpdate();
		}
		#endregion
	}
}