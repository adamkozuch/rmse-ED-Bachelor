using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;

namespace LicencjatInformatyka_RMSE_.Bases
{
  public  class GatheredBases : IGatheredBases
  {
      private RuleBase _ruleBase;
      private ConstrainBase _constrainBase;
      private ModelBase _modelsList;
      private FactBase _factBase;
      private ArgumentBase _argumentBase;
      

      public GatheredBases(ILanguageConfig config)
      {
     

          _ruleBase = new RuleBase(config);
         _constrainBase = new ConstrainBase(config);
        _modelsList =new ModelBase(config);
         _factBase = new FactBase();
        _argumentBase = new ArgumentBase();




      }
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
