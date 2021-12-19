using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace MathLib.Evolution
{
    public class RouletteSelector<T> : IFitnessSelector<T> where T : class
    {
        #region IFitnessSelector<T> Members

        public IList<T> SelectParents(IList<Tuple<T, double>> populationFitness, int parentsToSelect)
        {
            List<T> parents = new List<T>();

            T parent = populationFitness.First().Item1;
            for (int i = 0; i < parentsToSelect; i++)
            {                
                double runningFitnessTotal = 0;                

                double r = StaticRandom.NextDouble();
                foreach (var (solution, fitness) in populationFitness)
                {
                    runningFitnessTotal += fitness;
                    if (runningFitnessTotal < r) continue;
                    parent = solution;                        
                    break;
                }                
                
                parents.Add(parent);
            }
            return parents;
        }

        #endregion
    }
}
