namespace MathLib.Evolution
{
    public interface IChromosome<TChromosome> where TChromosome : class, IChromosome<TChromosome>
    {
        TChromosome Crossover(TChromosome extraChromosome);

        void Mutate();
    }
}
