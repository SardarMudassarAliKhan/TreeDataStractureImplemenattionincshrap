namespace TreeDataStractureImplemenattionincshrap
{
    public class TreeDataStracture
    {
        public int data;
        public TreeDataStracture left;
        public TreeDataStracture right;
        public TreeDataStracture(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public void Insert(int value)
        {
            if(value <= data)
            {
                if(left == null)
                {
                    left = new TreeDataStracture(value);
                }
                else
                {
                    left.Insert(value);
                }
            }
            else
            {
                if(right == null)
                {
                    right = new TreeDataStracture(value);
                }
                else
                {
                    right.Insert(value);
                }
            }
        }

        public bool Contains(int value)
        {
            if(value == data)
            {
                return true;
            }
            else if(value < data)
            {
                if(left == null)
                {
                    return false;
                }
                else
                {
                    return left.Contains(value);
                }
            }
            else
            {
                if(right == null)
                {
                    return false;
                }
                else
                {
                    return right.Contains(value);
                }
            }
        }

        public void PrintInOrder()
        {
            if(left != null)
            {
                left.PrintInOrder();
            }
            Console.WriteLine(data);
            if(right != null)
            {
                right.PrintInOrder();
            }
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(data);
            if(left != null)
            {
                left.PrintPreOrder();
            }
            if(right != null)
            {
                right.PrintPreOrder();
            }
        }

        public void PrintPostOrder()
        {
            if(left != null)
            {
                left.PrintPostOrder();
            }
            if(right != null)
            {
                right.PrintPostOrder();
            }
            Console.WriteLine(data);
        }

        public int FindSmallestValue()
        {
            if(left == null)
            {
                return data;
            }
            else
            {
                return left.FindSmallestValue();
            }
        }

        public int FindLargestValue()
        {
            if(right == null)
            {
                return data;
            }
            else
            {
                return right.FindLargestValue();
            }
        }

        public int FindHeight()
        {
            if(left == null && right == null)
            {
                return 0;
            }
            else if(left == null)
            {
                return 1 + right.FindHeight();
            }
            else if(right == null)
            {
                return 1 + left.FindHeight();
            }
            else
            {
                return 1 + Math.Max(left.FindHeight(), right.FindHeight());
            }
        }

        public void Delete(int value)
        {
            Delete(value);
        }

        private TreeDataStracture Delete(TreeDataStracture root, int value)
        {
            if(root == null)
            {
                return root;
            }
            else if(value < root.data)
            {
                root.left = Delete(root.left, value);
            }
            else if(value > root.data)
            {
                root.right = Delete(root.right, value);
            }
            else
            {
                if(root.left == null && root.right == null)
                {
                    root = null;
                }
                else if(root.left == null)
                {
                    root = root.right;
                }
                else if(root.right == null)
                {
                    root = root.left;
                }
                else
                {
                    int temp = root.right.FindSmallestValue();
                    root.data = temp;
                    root.right = Delete(root.right, temp);
                }
            }
            return root;
        }

        public void PrintLevelOrder()
        {
            Queue<TreeDataStracture> queue = new Queue<TreeDataStracture>();
            queue.Enqueue(this);
            while(queue.Count != 0)
            {
                TreeDataStracture temp = queue.Dequeue();
                Console.WriteLine(temp.data);
                if(temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if(temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
            }
        }

        public void PrintGivenLevel(int level)
        {
            if(level == 1)
            {
                Console.WriteLine(data);
            }
            else
            {
                if(left != null)
                {
                    left.PrintGivenLevel(level - 1);
                }
                if(right != null)
                {
                    right.PrintGivenLevel(level - 1);
                }
            }
        }

        public void PrintLevelOrderLineByLine()
        {
            int height = FindHeight();
            for(int i = 1; i <= height; i++)
            {
                PrintGivenLevel(i);
            }
        }

        public void PrintLevelOrderLineByLineUsingQueue()
        {
            Queue<TreeDataStracture> queue = new Queue<TreeDataStracture>();
            queue.Enqueue(this);
            while(true)
            {
                int nodeCount = queue.Count;
                if(nodeCount == 0)
                {
                    break;
                }
                while(nodeCount > 0)
                {
                    TreeDataStracture temp = queue.Dequeue();
                    Console.WriteLine(temp.data);
                    if(temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                    }
                    if(temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                    }
                    nodeCount--;
                }
                Console.WriteLine();
            }
        }

    }
}
