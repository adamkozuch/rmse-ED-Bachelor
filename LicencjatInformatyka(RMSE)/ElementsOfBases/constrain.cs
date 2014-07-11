using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.NewFolder2
{
  public  class Constrain
    {
        private int _numberOfLimit;
        private List<string> _constrainsList;

        public Constrain( List<string> constrainsList, int numberOfLimit)
        {
            _numberOfLimit = numberOfLimit;
            ConstrainsList = constrainsList;

        }

        public int NumberOfLimit
        {
            get { return _numberOfLimit; }
            set { _numberOfLimit = value; }
        }

      public List<string> ConstrainsList
      {
          get { return _constrainsList; }
          set { _constrainsList = value; }
      }
    }
}
