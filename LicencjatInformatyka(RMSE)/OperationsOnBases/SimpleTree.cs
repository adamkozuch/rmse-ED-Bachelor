using System.Collections.Generic;
using LicencjatInformatyka_RMSE_.NewFolder2;

namespace LicencjatInformatyka_RMSE_.NewFolder3
{
  public  class SimpleTree
    {
      public  Rule rule { get; set; }

      public bool Dopytywalny
      {
          get { return _dopytywalny; }
          set { _dopytywalny = value; }
      }

      public SimpleTree _parent { get; set; }
    List<SimpleTree> _children = new List<SimpleTree>();
      private bool _dopytywalny=false;

      public List<SimpleTree> Children {
        get { return _children; }
    }
        public SimpleTree Parent 
        {
            get{return _parent; }
            set { _parent = value; }
        }


        public int Depth
        {
            get
            {
                //return (Parent == null ? -1 : Parent.Depth) + 1;

                int depth = 0;
                SimpleTree node = this;
                while (node.Parent != null)
                {
                    node = node.Parent;
                    depth++;
                }
                return depth;
            }
        }

    }

       //static IEnumerable<SimpleTree> SimpleTreeToEnumerable(SimpleTree f)
       // {
       //     Stack<SimpleTree> stack = new Stack<SimpleTree>();
       //     stack.Push(f);
       //     while (stack.Count > 0)
       //     {
       //         var SimpleTree = stack.Pop();
       //         yield return SimpleTree;
       //         foreach (var child in SimpleTree.Children)
       //             stack.Push(child);
       //     }
       // }

    }

