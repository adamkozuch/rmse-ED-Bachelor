using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Bases;
using LicencjatInformatyka_RMSE_.NewFolder2;
using LicencjatInformatyka_RMSE_.NewFolder4;
using LicencjatInformatyka_RMSE_.NewFolder5;

namespace LicencjatInformatyka_RMSE_.Additional
{
  public  class GatheredBases : IGatheredBases
  {
        private RuleBase _ruleBase = new RuleBase();
        private ConstrainBase _constrainBase = new ConstrainBase();
        private ModelBase _modelsList =new ModelBase();
        private FactBase _factBase = new FactBase();
        private ArgumentBase _argumentBase = new ArgumentBase();


        public FactBase FactBase
        {
            get { return _factBase; }
            set { _factBase = value; }
        }

        public ArgumentBase ArgumentBase
        {
            get { return _argumentBase; }
            set { _argumentBase = value; }
        }
 

      public RuleBase RuleBase
        {
            get { return _ruleBase; }
            set { _ruleBase = value; }
        }

        public ConstrainBase ConstrainBase
        {
            get { return _constrainBase; }
            set { _constrainBase = value; }
        }

        public ModelBase ModelsBase
        {
            get { return _modelsList; }
            set { _modelsList = value; }
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
