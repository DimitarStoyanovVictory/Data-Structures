using System;
using System.Collections.Generic;
using System.Text;

public class Tree
{
    private int? SubtreeSum;
    private int _value;

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

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Tree Parent { get; set; }

    public IList<Tree> Children
    {
        get { return new List<Tree>(); }
    }

    public int FindRootNode()
    {
        if (Parent == null)
        {
            return Value;
        }

        return Parent.FindRootNode();
    }

    public IList<int> FindLeafNodes()
    {
        List<int> leafNodes = new List<int>();

        if (Children.Count == 0)
        {
            leafNodes.Add(Value);
        }
        else
        {
            foreach (var child in Children)
            {
                leafNodes.AddRange(child.FindLeafNodes());
            }
        }

        // Sort all the leaf nodes in increasing order if this is the root node
        if (Parent == null)
        {
            leafNodes.Sort();
        }
        return leafNodes;
    }

    public IList<int> FindMiddleNodes()
    {
        List<int> middleNodes = new List<int>();

        if (Children.Count > 0 && Parent != null)
        {
            middleNodes.Add(Value);
        }

        foreach (var child in Children)
        {
            middleNodes.AddRange(child.FindMiddleNodes());
        }

        // Sort all the leaf nodes in increasing order if this is the root node
        if (Parent == null)
        {
            middleNodes.Sort();
        }
        return middleNodes;
    }

    public IList<int> FindLongestPath()
    {
        IList<int> longestPath = new List<int>();
        IList<int> currentPath;

        foreach (var child in Children)
        {
            currentPath = child.FindLongestPath();
            if (currentPath.Count > longestPath.Count)
            {
                longestPath = currentPath;
            }
        }

        longestPath.Insert(0, Value);

        return longestPath;
    }

    public IList<IList<int>> FindPathsWithSum(int sum)
    {
        IList<IList<int>> paths = new List<IList<int>>();

        foreach (var child in Children)
        {
            IList<IList<int>> currentpaths = child.FindPathsWithSum(sum - Value);

            foreach (var path in currentpaths)
            {
                paths.Add(path);
            }
        }

        foreach (var path in paths)
        {
            path.Insert(0, Value);
        }

        if (paths.Count == 0 && Value == sum)
        {
            paths.Add(new List<int> { Value });
        }

        return paths;
    }

    public List<Tree> FindSubtreesWithSum(int sum)
    {
        List<Tree> currentSubtrees = new List<Tree>();

        foreach (var child in Children)
        {
            foreach (var tree in child.FindSubtreesWithSum(sum))
            {
                currentSubtrees.Add(tree);
            }
        }

        if (FindSubtreeSum() == sum)
        {
            currentSubtrees.Add(this);
        }

        return currentSubtrees;
    }

    /* 
     * This method is for optimisation. Once a Subtree finds its sum,
     * it keeps it in a variable and returns that variable everytime
     * the method is invoked again instead of calcullating its sum all over
     * again. 
     */
    public int? FindSubtreeSum()
    {
        if (SubtreeSum != null)
        {
            return SubtreeSum;
        }
        SubtreeSum = 0;
        foreach (var child in Children)
        {
            SubtreeSum += child.FindSubtreeSum();
        }

        SubtreeSum += Convert.ToInt32(Value);

        return SubtreeSum;
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        if (Children.Count == 0)
        {
            output.AppendFormat(Value.ToString());
        }
        else
        {
            output.AppendFormat("{0} + ", Value);
        }

        output.Append(string.Join(" + ", Children));

        return output.ToString();
    }
}