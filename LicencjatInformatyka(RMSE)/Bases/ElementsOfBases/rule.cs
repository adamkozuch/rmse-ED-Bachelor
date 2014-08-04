using System;
using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.Bases.ElementsOfBases
{
    [Serializable()]
  public  class Rule
    {
      private bool _dopytywalne;
      private bool _conclusionValue;
       
        private int _numberOfRule;
        private string _conclusion;
        private List<string> _conditions;
        


        public   Rule()
        {}

      public  Rule(int number, string conclusion, List<string>  conditions, bool semaphor)
        {
            Conclusion = conclusion;           //_conclusionValue = conclusionValue;
            NumberOfRule = number;
            Conditions = conditions;
            Semaphor = semaphor;
        }
  
        
        //public bool Dopytywalne
        //{
        //    get { return _dopytywalne; }
        //    set { _dopytywalne = value; }
        //}


        public int NumberOfRule
        {
            get { return _numberOfRule; }
            set { _numberOfRule = value; }
        }


        public string Conclusion
        {
            get { return _conclusion; }
            set { _conclusion = value; }
        }

        public bool ConclusionValue
        {
            get { return  _conclusionValue; }
            set { _conclusionValue = value; }
        }

        public List<string> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }

        public bool Semaphor { get; set; }
    }
}
