using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Util;

namespace MathLib.Evolution
{
    [ContractClass(typeof(FixedLengthChromosomeContract<,>))]
    public abstract class FixedLengthChromosome<TValue, TChromosome> : IChromosome<TChromosome> 
        where TChromosome : FixedLengthChromosome<TValue, TChromosome> where TValue : class, IDeepCloneable<TValue>
    {
        private readonly TValue[] _genes;      

        protected FixedLengthChromosome(IReadOnlyList<TValue> initialValues)
        {
            // // Contract.Requires(initialValues != null);
            // // Contract.Requires(initialValues.Length > 0);
            // //Contract.Ensures(Length == initialValues.Length);

            _genes = new TValue[initialValues.Count];
            for (int i = 0; i < _genes.Length; i++)
                _genes[i] = initialValues[i].DeepClone();
        }

        public int Length => _genes.Length;

        public TValue this[int index]
        {
            get =>
                // // Contract.Requires(index >= 0 && index < Length);
                // //Contract.Ensures(// Contract.Result<TValue>() != null);
                _genes[index];

            set =>
                // // Contract.Requires(index >= 0 && index < Length);
                // // Contract.Requires(value != null);
                _genes[index] = value;
        }

        public virtual TChromosome Crossover(TChromosome extraChromosome)
        {
                       
            var newGenes = new TValue[Length];

            int pt1;   // crossover points            

            // Contract.Assume(Length == extraChromosome.Length);
            switch (GeneticAlgorithm.CrossoverType)
            {
                case CrossoverMethod.SinglePoint:
                    pt1 = StaticRandom.Next(Length);
                    for (int i = 0; i < pt1; i++)
                        newGenes[i] = this[i];
                    for (int i = pt1; i < Length; i++)
                        newGenes[i] = extraChromosome[i];
                    break;
                case CrossoverMethod.TwoPoint:
                    pt1 = StaticRandom.Next(Length);
                    var pt2 = StaticRandom.Next(Length);   // crossover points            
                    if (pt2 < pt1)  // swap values
                    {
                        (pt1, pt2) = (pt2, pt1);
                    }
                    for (int i = 0; i < pt1; i++)
                        newGenes[i] = this[i];
                    for (int i = pt1; i < pt2; i++)
                        newGenes[i] = extraChromosome[i];
                    for (int i = pt2; i < Length; i++)
                        newGenes[i] = this[i];
                    break;
                case CrossoverMethod.Uniform:
                    for (int i = 0; i < Length; i++)
                        if (StaticRandom.NextDouble() < 0.5)
                            newGenes[i] = extraChromosome[i];
                        else
                            newGenes[i] = this[i];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }            
            
            return CreateChromosome(newGenes);
        }        

        public abstract void Mutate();

        protected abstract TChromosome CreateChromosome(TValue[] geneData);                          

        #region IDeepCloneable<Chromosome<T>> Members

        // ReSharper disable once UnusedMember.Global
        public abstract TChromosome DeepClone();    

        #endregion

    }
}
