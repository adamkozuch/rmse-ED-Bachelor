using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.Bases.ElementsOfBases
{
  public  class Constrain
    {
        private int _numberOfConstrain;
        private List<string> _constrainConditions;

        public Constrain( List<string> constrainConditions, int numberOfConstrain)
        {
            _numberOfConstrain = numberOfConstrain;
            ConstrainConditions = constrainConditions;

        }

      public Constrain()
      {
         
      }

      public int NumberOfConstrain
        {
            get { return _numberOfConstrain; }
            set { _numberOfConstrain = value; }
        }

      public List<string> ConstrainConditions
      {
          get { return _constrainConditions; }
          set { _constrainConditions = value; }
      }
    }
}
