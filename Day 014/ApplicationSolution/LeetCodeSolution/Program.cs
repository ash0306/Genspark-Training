namespace LeetCodeSolutionApplication
{
    internal class Program
    {
        public static void PrintMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Choose a program to run:");
            Console.WriteLine("1. Minimum Dpeth of Binary Tree");
            Console.WriteLine("2. Excel Sheet Column Name");
            Console.WriteLine("3. Linked List Cycle");
            Console.WriteLine("4. Exit");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Enter your choice:");
        }
        public static int GetUserChoice()
        {
            int choice = int.Parse(Console.ReadLine()!);
            return choice;
        }
        public async static void MinDepthOfBinaryTree()
        {
            MinimumDepthOfBinaryTree tree = new MinimumDepthOfBinaryTree();
            List<int> treeData = new List<int>();
            string? strNum;
            while (true)
            {
                Console.WriteLine("Enter values one by one (Enter -1 for null, Type stop, if you want to exit): ");
                strNum = Console.ReadLine();
                if (strNum.ToLower() == "stop")
                {
                    break;
                }
                int n;
                while (!int.TryParse(strNum, out n))
                {
                    Console.WriteLine("Invalid input, please try again...");
                    Console.WriteLine("Enter values one by one (Enter -1 for null, Type stop if you want to exit): ");
                }
                treeData.Add(n);
            }

            TreeNode root = tree.InsertNode(treeData);

            int minmumDepth = await tree.MinDepth(root);

            Console.WriteLine("The minimum depth of the binary tree is : " + minmumDepth);
        }

        public async static void ExcelColumn()
        {
            ExcelColumnName excel = new ExcelColumnName();

            Console.WriteLine("Enter the column number:");
            int num = int.Parse(Console.ReadLine()!);

            Console.WriteLine("The column name is :");
            Console.WriteLine(await excel.GetColumnName(num));
        }

        public async static void LinkedListCycle()
        {
            LinkedListCycle linkedList = new LinkedListCycle();
            ListNode head = null;
            int value = 0;
            while (true)
            {
                Console.WriteLine("Enter value for list node(Enter -1 to stop entering values):");
                value = int.Parse(Console.ReadLine()!);
                if (value == -1)
                {
                    break;
                }
                linkedList.InsertNode(ref head, value);
            }

            Console.WriteLine("Enter the value to create cycle:");
            int loopVal = int.Parse(Console.ReadLine()!);

            linkedList.CreateLoop(head, loopVal);

            bool IsLoop = await linkedList.HasCycle(head);
            Console.WriteLine("Does the Linked list have a cycle?" + IsLoop);
        }

        static void Main(string[] args)
        {

            while (true)
            {
                PrintMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        MinDepthOfBinaryTree();
                        break;
                    case 2:
                        ExcelColumn();
                        break;
                    case 3:
                        LinkedListCycle();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!! Enter a valid choice!!");
                        break;
                }
            }
        }
    }
}
