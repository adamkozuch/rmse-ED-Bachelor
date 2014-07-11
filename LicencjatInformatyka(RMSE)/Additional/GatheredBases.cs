using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.NewFolder2;

namespace LicencjatInformatyka_RMSE_.NewFolder5
{
  public  class GatheredBases : IGatheredBases
  {
        private List<Rule> _ruleList = new List<Rule>();
        private List<Constrain> _constrainList = new List<Constrain>();
        private List<Model> _modelsList= new List<Model>();
        private List<Fact> _factsList = new List<Fact>();
        private List<Argument>  _argumentList = new List<Argument>();
        //private List<Advice> _adviceList = new List<Advice>();
        //private List<Advice> _adviceList = new List<Advice>();
        //private List<Advice> _adviceList = new List<Advice>();
        
      
      public List<Fact> FactsList
        {
            get { return _factsList; }
            set { _factsList = value; }
        }

      public List<Rule> RuleList
        {
            get { return _ruleList; }
            set { _ruleList = value; }
        }

        public List<Constrain> ConstrainList
        {
            get { return _constrainList; }
            set { _constrainList = value; }
        }

        public List<Model> ModelsList
        {
            get { return _modelsList; }
            set { _modelsList = value; }
        }

        public List<Argument> ArgumentsList
        {
            get { return _argumentList; }
            set { value = _argumentList; }
        }


       

       

        public List<Sound> SoundsList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public List<Graphic> GraphicsList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }


        public List<Advice> AdvicesList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
  }
}
