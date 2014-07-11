using System;
using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.NewFolder2
{
    [Serializable()]
  public  class Rule
    {
      private bool _dopytywalne=true;

     



     public   Rule()
        {}

      public  Rule(int number, string conclusion, List<string>  conditions, bool semaphor)
        {
            Conclusion = conclusion;           //_conclusionValue = conclusionValue;
            NumberOfRule = number;
            Conditions = conditions;
            Semaphor = semaphor;
        }
  
        
        public bool Dopytywalne
        {
            get { return _dopytywalne; }
            set { _dopytywalne = value; }
        }


      public int NumberOfRule { get; set; }


      public string Conclusion { get; set; }

      public bool ConclusionValue { get; set; }

      public List<string> Conditions { get; set; }

      public bool Semaphor { get; set; }
    }
}
