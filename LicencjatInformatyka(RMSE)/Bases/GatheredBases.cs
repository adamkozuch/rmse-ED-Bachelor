using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.Additional;
using LicencjatInformatyka_RMSE_.Bases.ElementsOfBases;
using LicencjatInformatyka_RMSE_.ViewModelFolder;

namespace LicencjatInformatyka_RMSE_.Bases
{
  public  class GatheredBases : IGatheredBases
  {
      private readonly ViewModel _model;
      private RuleBase _ruleBase;
      private ConstrainBase _constrainBase;
      private ModelBase _modelsList;
      private FactBase _factBase;
      private ArgumentBase _argumentBase;
      private FactBase _orginalFactBase;
      private ArgumentBase _orginalArgumentBase;


      private AdviceBase _advicesList;
      private SoundBase _soundsList;
      private GraphicBase _graphicsList;

      public GatheredBases(ViewModel model)
      {
          _model = model;


          _ruleBase = new RuleBase(model);
        _constrainBase = new ConstrainBase( model);
        _modelsList =new ModelBase(model);
         _factBase = new FactBase(model);
        _argumentBase = new ArgumentBase(model);
          _orginalArgumentBase = new ArgumentBase(model);
          _orginalFactBase = new FactBase(model);

          _advicesList = new AdviceBase(model);
          _soundsList = new SoundBase(model);
          _graphicsList = new GraphicBase(model);




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

        public FactBase OrginalFactBase
        {
            get { return _orginalFactBase; }
            set { _orginalFactBase = value; }
        }

        public ArgumentBase OrginalArgumentBase
        {
            get { return _orginalArgumentBase; }
            set { _orginalArgumentBase = value; }
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

      public AdviceBase AdviceBase
      {
          get { return _advicesList; }
          set { _advicesList = value; }
      }

      public SoundBase SoundBase
      {
          get { return _soundsList; }
          set { _soundsList = value; }
      }

      public GraphicBase GraphicBase
      {
          get { return _graphicsList; }
          set { _graphicsList = value; }
      }
  }
}
