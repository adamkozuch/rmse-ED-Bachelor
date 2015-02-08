using System;
using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.Bases.ElementsOfBases
{
    [Serializable()]
  public  class Rule
    { 
     
        private int _numberOfRule;
        private string _conclusion;
        private List<string> _conditions;
        
        public   Rule()
        {}

      public  Rule(int number, string conclusion, List<string>  conditions, bool semaphor)
        {
            Conclusion = conclusion;           
            NumberOfRule = number;
            Conditions = conditions;
            Semaphor = semaphor;
        }
  

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

        

        public List<string> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }

        public bool Semaphor { get; set; }
    }
}
