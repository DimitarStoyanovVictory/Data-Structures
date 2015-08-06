using System.Collections.Generic;

namespace PlayWithTree
{
    public class Tree
    {
        private Dictionary<int, Tree> nodeTrees = new Dictionary<int, Tree>(); 

        public Tree()
        {
        }

        public Tree(int value, params Tree[] children)
        {
            Value = value;
            Children.Clear();

            foreach (var child in children)
            {
                Children.Add(child);
                child.Parent = this;
            }
        }

        public int Count { get; set; }

        public Tree Parent { get; set; }

        public int Value { get; set; }

        public List<Tree> Children
        {
            get { return new List<Tree>(); }
        }

        public void AddTree(Tree tree)
        {
            if (Count == 0)
            {
                RooTree = tree;
                nodeTrees.Add(tree.Value, tree);
            }
            else
            {
                foreach (var node in nodeTrees)
                {
                    //if (nodeTrees[tree.Value] == node.Value)
                    //{
                    //    Parent.Children.Add(node.Value);
                    //}
                }
            }
        }

        public Tree RooTree { get; set; }
    }
}
