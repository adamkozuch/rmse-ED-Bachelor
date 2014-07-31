using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.Bases.ElementsOfBases
{
  public  class Constrain
    {
        private int _numberOfLimit;
        private List<string> _constrainConditions;

        public Constrain( List<string> constrainConditions, int numberOfLimit)
        {
            _numberOfLimit = numberOfLimit;
            ConstrainConditions = constrainConditions;

        }

        public int NumberOfLimit
        {
            get { return _numberOfLimit; }
            set { _numberOfLimit = value; }
        }

      public List<string> ConstrainConditions
      {
          get { return _constrainConditions; }
          set { _constrainConditions = value; }
      }
    }
}
