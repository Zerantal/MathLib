// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

using MathLib.Matrices;
using MathLib.Statistics;

namespace MathLib.Evolution
{
    public class EsObject : IEvolvableObject<EsObject>
    {
        /*
        double _sigma;
        private double _tau;
        private T _solution;

        NormalRandomGenerator _random;

        public ESObject(T solution)
        {                                   
            _tau = 1 / Math.Sqrt(2 * solution.NumberOfParameters);
            _solution = solution;
            _sigma = 1;
            _random = new NormalRandomGenerator(0, 1);
        }

        private ESObject(double strategyParameter, T solution)
        {
            _sigma = strategyParameter; 
            _tau = 1 / Math.Sqrt(2 * solution.NumberOfParameters);
            _solution = solution;

            _random = new NormalRandomGenerator(0, 1);
        }

        #region IEvolvableObject<ESObject> Members

        public ESObject<T> RecombineWith(ESObject<T> additionalParent)
        {
            int numParents = additionalParent.Count() + 1;
            double meanSigma = _sigma;
            Vector meanParameterSet = _solution.ParameterSet.DeepClone();

            foreach (ESObject<T> f in additionalParent)
            {
                meanSigma += f.StrategyParameter;
                meanParameterSet += f._solution.ParameterSet;                
            }

            return new ESObject<T>(meanSigma / numParents,
                _solution.CreateNewSolution(meanParameterSet / numParents));            
        }

        public void Mutate()
        {
            // mutate strategy parameter
            _sigma *= Math.Exp(_tau * _random.Number);

            // mutate parameter set
            _solution.ParameterSet += _sigma * new Vector(_solution.NumberOfParameters, VectorType.RowVector, _random);
        }

        public double Fitness()
        {
            return _solution.Fitness();            
        }

        #endregion

        public double StrategyParameter
        {
            get { return _sigma; }          
        }

        public T Solution
        {
            get { return _solution; }
        }

        public double Tau
        {
            get { return _tau; }
            set { _tau = value; }
        }
         * */
        #region IEvolvableObject<ESObject> Members

        public EsObject RecombineWith(EsObject additionalParent)
        {
            throw new NotImplementedException();
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public double Fitness()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
