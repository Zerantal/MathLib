using System;
using System.Collections.Generic;

namespace MathLib.Evolution
{
    public interface IFitnessSelector<T> where T : class
    {
        IList<T> SelectParents(IList<Tuple<T, double>> populationFitness, int parentsToSelect);
    }
}
