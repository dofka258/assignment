using HierarchicalStructure;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi ReizTech!");
        Branch tree = PopulatedTreeByExample(new Branch());
        var depth = DepthOfTree(tree);
        Console.WriteLine($"The depth of example structure is {depth}");
        Console.WriteLine("How many randomly generated structures would you like to see?");
        int generateStructures = Convert.ToInt32(Console.ReadLine());
        if(generateStructures > 0)
        for(int i = 0; i < generateStructures; i++)
        {
            tree = PopulatedRandomTree(new Branch(), 0, 12);
            depth = DepthOfTree(tree);
            Console.WriteLine($"The depth of a randomly generated structure ({i+1}/{generateStructures}) is {depth}");
            Task.Delay(1000).Wait();
        }
    }

    private static int DepthOfTree(Branch tree)
    {
        if (tree.branches.Count == 0)
            return 1;

        var maxDepth = 0;
        foreach (var branch in tree.branches)
        {
            var tempDepth = DepthOfTree(branch);
            if (tempDepth > maxDepth)
                maxDepth = tempDepth;
        }
        return maxDepth + 1;
    }

    private static Branch PopulatedRandomTree(Branch tree, int iteration, int maxIteration)
    {
        if(iteration >= maxIteration - 1)
            return tree;

        Random rnd = new Random();
        int random = rnd.Next(0, 3);
        for (int i = 0; i < random; i++)
            tree.branches.Add(new Branch());

        int branchAmount = tree.branches.Count;
        for (int i = 0; i < branchAmount; i++)
            tree.branches[i] = PopulatedRandomTree(new Branch(), iteration+1, maxIteration);
        return tree;
    }

    private static Branch PopulatedTreeByExample(Branch tree)
    {
        tree.branches.Add(new Branch());
        tree.branches.Add(new Branch());
        tree.branches[0].branches.Add(new Branch());
        tree.branches[1].branches.Add(new Branch());
        tree.branches[1].branches.Add(new Branch());
        tree.branches[1].branches.Add(new Branch());
        tree.branches[1].branches[0].branches.Add(new Branch());
        tree.branches[1].branches[1].branches.Add(new Branch());
        tree.branches[1].branches[1].branches.Add(new Branch());
        tree.branches[1].branches[1].branches[0].branches.Add(new Branch());
        return tree;
    }
}

