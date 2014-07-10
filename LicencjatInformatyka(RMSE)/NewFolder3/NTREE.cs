using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.NewFolder3
{
    class NTree<T>
    {
         T data;
        LinkedList<NTree<T>> children;

        public NTree(T data)
        {
            this.data = data;
            children = new LinkedList<NTree<T>>();
        }

        public void addChild(T data)
        {
            children.AddFirst(new NTree<T>(data));
        }

        public NTree<T> getChild(int i)
        {
            foreach (NTree<T> n in children)
                if (--i == 0) return n;
            return null;
            
        }

        public void traverse(NTree<T> node, TreeVisitor<T> visitor)
        {
            visitor(node.data);
            foreach (NTree<T> kid in node.children)
                traverse(kid, visitor);
        }        
    }
}
