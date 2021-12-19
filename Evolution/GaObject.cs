using System.Diagnostics.Contracts;

namespace MathLib.Evolution
{
    [ContractClass(typeof(GaObjectContract<,>))]
    public abstract class GaObject<TObject, TChromosome> : IEvolvableObject<TObject>
        where TObject : GaObject<TObject, TChromosome>
        where TChromosome : class, IChromosome<TChromosome>
    {
        protected TChromosome Chromosome { get; set; }

        protected abstract TObject CreateObject();        

        #region IEvolvableObject<GAObject<Genome>> Members

        public TObject RecombineWith(TObject additionalParent)
        {
            TObject child = CreateObject();

            child.Chromosome = Chromosome.Crossover(additionalParent.Chromosome);

            return child;            
        }        

        public void Mutate()
        {
            Chromosome.Mutate();            
        }

        public abstract double Fitness();
        #endregion

    }
}
