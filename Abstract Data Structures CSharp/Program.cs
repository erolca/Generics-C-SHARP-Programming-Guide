using System;
using Adscol;

namespace CS_Abstract_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call method to test corresponding data structure methods
            // LinkedListTest();
            Console.WriteLine("Hello world!");

            RedBlackTreeTest();

            Console.ReadKey();
        }

        #region TestMethods
        static void LinkedListTest()
        {
            LinkedList<char> list = new LinkedList<char>();
            list.add('x');
            list.add('y');
            list.add('d');
            list.add('q');
            list.add('u');
            list.add('i');
            list.print();

            Console.WriteLine(list.size());
            list.clear();
            list.print();

            string st = "abcdefghijklmnopqrstuvwxyz";
            list.add(st[0]);

            Console.WriteLine();
            for (int i = 0; i < st.Length; i++)
            {
                list.add(st[i]);
            }

            list.print();
            list.clear();

            LinkedList<int> nums = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                nums.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nums.get(i));
            }
        }

        static void DoublyLinkedListTest()
        {
            DoublyLinkedList<int> nums = new DoublyLinkedList<int>();

            nums.add(5);

            for (int i = 1; i <= 10; i++)
            {
                nums.add(i);
            }

            nums.print();

            Console.WriteLine();
            nums.print();

            Console.WriteLine();
            Console.WriteLine("Is Empty: ");
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine("Size: ");
            Console.WriteLine(nums.size());

            nums.clear();
            Console.WriteLine("Is Empty: ");
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine("Size: ");
            Console.WriteLine(nums.size());
        }

        static void StackTest()
        {
            Stack<int> nums = new Stack<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.push(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.size());
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine();
            nums.print();
        }

        static void QueueTest()
        {
            Queue<int> nums = new Queue<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.size());

            Console.WriteLine("Is empty: " + nums.isEmpty() + "\n");

            nums.print();
            nums.clear();
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            nums.print();
        }

        static void SortedSetTest()
        {
            SortedSet<int> numsList = new SortedSet<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            SortedSet<int> nums2 = new SortedSet<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void SetTest()
        {
            Set<int> numsList = new Set<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            Set<int> nums2 = new Set<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void MultisetTest()
        {
            Multiset<int> nums = new Multiset<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {

                int x = rand.Next(0, 10);

                nums.add(x);
            }

            nums.print();

            Console.WriteLine("Size: " + nums.size());

            Set<int> list = nums.getSet();
            list.print();
        }

        static void BagTest()
        {
            Bag<char> items = new Bag<char>();

            string happy = "Happy Birthday";

            foreach (char x in happy)
            {
                items.add(x);
            }

            items.print();

            Console.WriteLine("Size: " + items.size());
        }

        static void BinaryTreeTest()
        {
            BinaryTree<int> nums = new BinaryTree<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums.add(x);
            }

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine("Height: " + nums.height());
            Console.WriteLine("Width: " + nums.width());
            Console.WriteLine();

            nums.remove(9);
            nums.removeAll(3);
            nums.invert();

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinaryTree<char> tree = new BinaryTree<char>();

            tree.add('2');
            tree.add('+');
            tree.add('3');
            tree.add('*');
            tree.add('6');

            tree.printPreOrder();
            Console.WriteLine();
            tree.printInOrder();
            Console.WriteLine();
            tree.printPostOrder();
            Console.WriteLine();
        }

        static void PriorityQueueTest()
        {
            PriorityQueue<char> queue = new PriorityQueue<char>();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int pr = rand.Next(0, 10);
                char let = (char)rand.Next(65, 126);

                queue.enqueue(let, pr);
            }
            Console.WriteLine("Size: " + queue.size());
            queue.print();

            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.peek());

            queue.print();
        }

        static void ArrayListTest()
        {
            ArrayList<int> list = new ArrayList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.add(i);
            }

            Console.WriteLine("Size: " + list.size());

            list = list.subList(0, 50);
            Console.WriteLine("Size: " + list.size());

            list.print();

            Console.WriteLine(list.isEmpty());

            list.reverse();
            list[0] = 350;
            Console.WriteLine(list.get(5));
            Console.WriteLine(list[5]);
            Console.WriteLine(list.contains(3));
            list.print();
        }

        static void DequeTest()
        {
            Deque<int> list = new Deque<int>();

            try
            {
                if (list.isEmpty())
                {
                    Console.WriteLine("Empty queue");
                }

                list.pushBack(100);
                list.pushBack(200);
                list.pushBack(300);

                Console.WriteLine("Size: " + list.size());

                Console.WriteLine(list.popBack());
                Console.WriteLine(list.popBack());
                Console.WriteLine(list.popBack());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Deque<int> list2 = new Deque<int>();

            try
            {
                if (list2.isEmpty())
                {
                    Console.WriteLine("Empty queue");
                }

                list2.pushBack(100);
                list2.pushBack(200);
                list2.pushBack(300);

                Console.WriteLine("Size: " + list2.size());

                Console.WriteLine(list2.popFront());
                Console.WriteLine(list2.popFront());
                Console.WriteLine(list2.popFront());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void CircularQueueTest()
        {
            CircularQueue<int> list = new CircularQueue<int>(5);

            for (int i = 0; i < 5; i++)
            {
                list.enqueue(i);
            }

            list.print();

            Console.WriteLine();
            Console.WriteLine("Size: " + list.size());
            list.clear();
            Console.WriteLine("Size: " + list.size());

            CircularQueue<string> q = new CircularQueue<string>(3);

            q.enqueue("The");
            q.enqueue("end");
            q.enqueue("is");
            q.enqueue("nigh!");

            q.enqueue("Cool");

            q.print();
        }

        static void CircularLinkedListTest()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            Console.WriteLine("Starting");

            list.addBack(43);
            list.addBack(83);
            list.addBack(98);
            list.addBack(65);
            list.addBack(4983);
            list.addBack(9898);
            list.addFront(5555555);

            Console.WriteLine("Size: " + list.size());

            list.print();

            list.popBack();
            Console.WriteLine("Size: " + list.size());
            list.print();

            list.popFront();
            Console.WriteLine("Size: " + list.size());
            list.print();

            Console.WriteLine("Finished");
        }

        static void SortedMapTest()
        {
            SortedMap<string, int> table = new SortedMap<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            table.remove("Jane");
            table.remove("Joe");

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }

        static void MapTest()
        {
            Map<string, int> table = new Map<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            table.remove("Jane");
            table.remove("Joe");

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }

        static void HashMapTest()
        {
            HashMap<string, int> table = new HashMap<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            table.remove("Jane");
            table.remove("Joe");

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }

        static void TreapTest()
        {
            Treap<int> nums = new Treap<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums.add(x);
            }

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine("Height: " + nums.height());
            Console.WriteLine("Width: " + nums.width());
            Console.WriteLine();

            nums.remove(9);
            nums.removeAll(3);
            nums.invert();

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Treap<char> tree = new Treap<char>();

            tree.add('2');
            tree.add('+');
            tree.add('3');
            tree.add('*');
            tree.add('6');

            tree.printPreOrder();
            Console.WriteLine();
            tree.printInOrder();
            Console.WriteLine();
            tree.printPostOrder();
            Console.WriteLine();
        }

        static void HashSetTest()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                evenNumbers.add(i * 2);

                oddNumbers.add((i * 2) + 1);
            }

            Console.WriteLine("Even numbers: " + evenNumbers.size());
            Console.WriteLine("Odd numbers: " + oddNumbers.size());

            Console.WriteLine("\n\nEvens:");
            evenNumbers.print();
            Console.WriteLine("\n\nOdds:");
            oddNumbers.print();

            oddNumbers.remove(7);
            oddNumbers.remove(3);

            Console.WriteLine("\n\nOdds:");
            oddNumbers.print();
        }

        static void TreeSetTest()
        {
            Set<int> numsList = new Set<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            Set<int> nums2 = new Set<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void GraphTest()
        {
            Graph<int> curGraph = new Graph<int>();

            curGraph.addVertex("A", 0);
            curGraph.addVertex("B", 1);
            curGraph.addVertex("C", 2);
            curGraph.addVertex("D", 3);
            curGraph.addVertex("E", 4);
            curGraph.addVertex("F", 5);

            curGraph.addEdge("A", "B");
            curGraph.addEdge("B", "C");
            curGraph.addEdge("D", "C");
            curGraph.addEdge("E", "B");
            curGraph.addEdge("D", "G");

            Console.WriteLine(curGraph.distanceBetween("A", "B"));
            Console.WriteLine(curGraph.distanceBetween("A", "C"));
            Console.WriteLine(curGraph.distanceBetween("A", "D"));
            Console.WriteLine(curGraph.distanceBetween("C", "B"));
            Console.WriteLine(curGraph.distanceBetween("D", "B"));
            Console.WriteLine(curGraph.distanceBetween("D", "E"));
            Console.WriteLine(curGraph.distanceBetween("D", "F"));
            Console.WriteLine(curGraph.distanceBetween("D", "G"));

            Console.WriteLine();
            Console.WriteLine();
            curGraph.print();

            Console.WriteLine();
            Console.WriteLine();

            Graph<int> testGraph = new Graph<int>();

            testGraph.addVertex("A", 0);
            testGraph.addVertex("B", 1);
            testGraph.addVertex("C", 2);

            testGraph.addEdge("A", "B");
            testGraph.addEdge("B", "C");

            Console.WriteLine(testGraph.distanceBetween("A", "B"));
            Console.WriteLine(testGraph.distanceBetween("A", "C"));

            testGraph.removeEdge("B", "C");
            testGraph.removeEdge("B", "F");

            Console.WriteLine(testGraph.distanceBetween("A", "B"));
            Console.WriteLine(testGraph.distanceBetween("A", "C"));

            Console.WriteLine();
            testGraph.print();

            Console.WriteLine();
            Console.WriteLine();

            curGraph.breadthFirstSearch("A", "D");
            curGraph.depthFirstSearch("A", "D");
        }

        static void FenwickTreeTest()
        {
            long[] ar = { 0 /*Dummy value*/, 1, 2, 3, 4, 5, 6 };
            //first entry is not used and can be any value

            FenwickTree ft = new FenwickTree(ar);

            // Range queries should start at an index of 1
            Console.WriteLine(ft.sum(1, 6));
            Console.WriteLine(ft.sum(1, 5));
            Console.WriteLine(ft.sum(1, 4));
            Console.WriteLine(ft.sum(1, 3));
            Console.WriteLine(ft.sum(1, 2));
            Console.WriteLine(ft.sum(1, 1));

            try
            {
                Console.WriteLine(ft.sum(1, 0)); // <-- invalid bounds!
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

            Console.WriteLine(ft.sum(3, 5));
            Console.WriteLine(ft.sum(2, 6));
            Console.WriteLine(ft.sum(4, 4));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ft.print();
        }

        static void TrieTest()
        {
            Trie t1 = new Trie();

            t1.add("");
            Console.WriteLine(t1.contains(""));
            t1.add("");
            Console.WriteLine(t1.contains(""));
            t1.add("");
            Console.WriteLine(t1.contains(""));

            Trie t2 = new Trie();
            t2.add("aaaaa");
            t2.add("aaaaa");
            t2.add("aaaaa");
            t2.add("aaaaa");
            t2.add("aaaaa");
            Console.WriteLine(t2.contains("aaaaa"));
            Console.WriteLine(t2.contains("aaaa"));
            Console.WriteLine(t2.contains("aaa"));
            Console.WriteLine(t2.contains("aa"));
            Console.WriteLine(t2.contains("a"));

            Trie t3 = new Trie();

            t3.add("AE");
            t3.add("AE");
            t3.add("AH");
            t3.add("AH");
            t3.add("AH7");
            t3.add("AHH7");
            t3.add("AHHD7");
            t3.add("AHHDE7");
            t3.add("AHHDEG7");
            t3.add("AHHDEGE7");
            t3.add("AHHDEGEF7");
            t3.add("A7");
            t3.add("7");
            t3.add("7");
            t3.add("B");
            t3.add("B");
            t3.add("B");
            t3.add("B");

            Console.WriteLine(t3.contains("A"));
            Console.WriteLine(t3.contains("AH"));
            Console.WriteLine(t3.contains("A7"));
            Console.WriteLine(t3.contains("AE"));
            Console.WriteLine(t3.contains("AH7"));
            Console.WriteLine(t3.contains("7"));
            Console.WriteLine(t3.contains("B"));

            Console.WriteLine(t3.contains("Ar"));
            Console.WriteLine(t3.contains("A8"));
            Console.WriteLine(t3.contains("AH6"));
            Console.WriteLine(t3.contains("C"));

            Console.WriteLine();

            do
            {
                Console.Write("Enter prefix: ");
                string prefixSearch = Console.ReadLine();

                var results = t3.findWordsThatStartWith(prefixSearch);

                Console.WriteLine("\nWords that start with {0}:", prefixSearch);
                results.print();

            } while (true);
        }

        static void UnionFindTest()
        {
            UnionFind uf = new UnionFind(5);
            Console.WriteLine(uf.componentSize(0));
            Console.WriteLine(uf.componentSize(1));
            Console.WriteLine(uf.componentSize(2));
            Console.WriteLine(uf.componentSize(3));
            Console.WriteLine(uf.componentSize(4));

            uf.unify(0, 1);
            Console.WriteLine(uf.componentSize(0));
            Console.WriteLine(uf.componentSize(1));
            Console.WriteLine(uf.componentSize(2));
            Console.WriteLine(uf.componentSize(3));
            Console.WriteLine(uf.componentSize(4));

            Console.WriteLine(uf.components());

            int sz = 7;
            UnionFind uf2 = new UnionFind(sz);

            for (int i = 0; i < sz; i++) Console.WriteLine(uf2.connected(i, i));

            uf2.unify(0, 2);

            Console.WriteLine(uf2.connected(0, 2));
            Console.WriteLine(uf2.connected(2, 0));

            UnionFind uf3 = new UnionFind(5);
            Console.WriteLine(uf3.size());
            uf3.unify(0, 1);
            uf3.find(3);
            Console.WriteLine(uf3.size());
            uf3.unify(1, 2);
            Console.WriteLine(uf3.size());
            uf3.unify(0, 2);
            uf3.find(1);
            Console.WriteLine(uf3.size());
            uf3.unify(2, 1);
        }

        static void HeapTest()
        {
            Console.WriteLine("Max heap test:");

            Heap<int> heapTree = new Heap<int>();

            heapTree.push(4);
            heapTree.push(12);
            heapTree.push(14);
            heapTree.push(5);
            heapTree.push(8);
            heapTree.push(15);
            heapTree.push(30);
            heapTree.push(1);

            Console.WriteLine("Size: " + heapTree.size());

            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();

            int extract = heapTree.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();

            extract = heapTree.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();

            extract = heapTree.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();

            heapTree.push(6);
            heapTree.push(13);

            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();



            Console.WriteLine("\n\nMin heap test:");

            Heap<int> heapTree2 = new Heap<int>(true);

            heapTree2.push(4);
            heapTree2.push(12);
            heapTree2.push(14);
            heapTree2.push(5);
            heapTree2.push(8);
            heapTree2.push(15);
            heapTree2.push(30);
            heapTree2.push(1);

            Console.WriteLine("Size: " + heapTree2.size());

            Console.WriteLine();
            Console.WriteLine();
            heapTree2.print();

            extract = heapTree2.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree2.print();

            extract = heapTree2.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree.print();

            extract = heapTree2.pop();
            Console.WriteLine("Extracted: " + extract);
            Console.WriteLine();
            Console.WriteLine();
            heapTree2.print();

            heapTree2.push(6);
            heapTree2.push(13);

            Console.WriteLine();
            Console.WriteLine();
            heapTree2.print();
        }

        static void BitSetTest()
        {
            BitSet set = new BitSet(8);

            set[2] = true;
            set[3] = true;
            set[4] = true;
            set[5] = true;

            set.print();

            Console.WriteLine();

            set.not();
            set.print();

            set.not();

            BitSet set2 = new BitSet(6);

            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                int ran = rand.Next(0, 2);

                set2[i] = (ran == 0);
            }

            Console.WriteLine("Set 2:");
            set2.print();

            Console.WriteLine("\nSet 1 AND Set 2");
            set.and(set2);
            set.print();

            Console.WriteLine("\nSet 1 OR Set 2");
            set.or(set2);
            set.print();

            Console.WriteLine("\nSet 1 XOR Set 2");
            set.xor(set2);
            set.print();
        }

        static void SkipListTest()
        {
            SkipList<int> list = new SkipList<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.add(i);
            }

            list.print();

            list.remove(7);
            list.remove(3);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            list.print();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(list.contains(3));
            Console.WriteLine(list.contains(5));

        }

        static void UnrolledLinkedListTest()
        {
            UnrolledList<char> list = new UnrolledList<char>(5);
            list.add('w', 'x', 'y', 'z');
            list.add('w', 'x', 'y', 'z');
            list.add('w', 'x', 'y', 'z');
            list.add('w', 'x', 'y', 'z');
            list.add('w', 'x', 'y', 'z');
            list.add('w', 'x', 'y', 'z');
            list.print();

            Console.WriteLine(list.size());
            list.clear();
            list.print();

            string st = "abcdefghijklmnopqrstuvwxyz";

            Console.WriteLine();
            for (int i = 0; i < st.Length - 3; i++)
            {
                list.add(st[i], st[i + 1], st[i + 2], st[i + 3]);
            }

            list.print();
            list.clear();

            Console.WriteLine("Printed alphabet");

            UnrolledList<int> nums = new UnrolledList<int>(5);

            for (int i = 0; i < 10; i++)
            {
                nums.add(i, i * 2, i * 3, i * 4);
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (int x in nums.get(i))
                {
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }
        }

        static void SortedListTest()
        {
            Random rand = new Random();

            SortedList<int> list = new SortedList<int>();

            for (int i = 0; i < 50; i++)
            {
                list.add(rand.Next(0, 20));
            }

            Console.WriteLine("Size: " + list.size());
            list.print();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SortedList<double> nums = new SortedList<double>();

            for (int i = 0; i < 25; i++)
            {
                nums.add(rand.NextDouble() + rand.Next(0, 10));
            }

            nums.print();
        }

        static void MultiMapTest()
        {
            MultiMap<char, int> map = new MultiMap<char, int>();

            Random rand = new Random();

            for (int i = 0; i < 25; i++)
            {
                char key = (char)rand.Next(65, 71);
                map.add(key, rand.Next(0, 50));
            }

            map.print();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int[] items = map.get('A');

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }

        static void TreeMapTest()
        {
            TreeMap<string, int> table = new TreeMap<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }

        static void IntervalTreeTest()
        {
            IntervalTree<int> it = new IntervalTree<int>();

            it.addInterval(0L, 10L, 1);
            it.addInterval(20L, 30L, 2);
            it.addInterval(15L, 17L, 3);
            it.addInterval(25L, 35L, 4);

            ArrayList<int> result1 = it.get(5L);
            ArrayList<int> result2 = it.get(10L);
            ArrayList<int> result3 = it.get(29L);
            ArrayList<int> result4 = it.get(5L, 15L);

            Console.WriteLine("Intervals that contain 5L:");
            foreach (int r in result1)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("Intervals that contain 29L:");
            foreach (int r in result3)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("Intervals that intersect (5L,15L):");
            foreach (int r in result4)
            {
                Console.WriteLine(r);
            }
        }

        static void WeightedGraphTest()
        {
            WeightedGraph<int> curGraph = new WeightedGraph<int>();

            curGraph.addVertex("A", 0);
            curGraph.addVertex("B", 1);
            curGraph.addVertex("C", 2);
            curGraph.addVertex("D", 3);
            curGraph.addVertex("E", 4);
            curGraph.addVertex("F", 5);

            Random rand = new Random();

            curGraph.addEdge("A", "B", rand.Next(1, 50));
            curGraph.addEdge("B", "C", rand.Next(1, 50));
            curGraph.addEdge("D", "C", rand.Next(1, 50));
            curGraph.addEdge("E", "B", rand.Next(1, 50));
            curGraph.addEdge("D", "G", rand.Next(1, 50));

            Console.WriteLine(curGraph.distanceBetween("A", "B"));
            Console.WriteLine(curGraph.distanceBetween("A", "C"));
            Console.WriteLine(curGraph.distanceBetween("A", "D"));
            Console.WriteLine(curGraph.distanceBetween("C", "B"));
            Console.WriteLine(curGraph.distanceBetween("D", "B"));
            Console.WriteLine(curGraph.distanceBetween("D", "E"));
            Console.WriteLine(curGraph.distanceBetween("D", "F"));
            Console.WriteLine(curGraph.distanceBetween("D", "G"));

            Console.WriteLine();
            Console.WriteLine();
            curGraph.print();

            Console.WriteLine();
            Console.WriteLine();

            WeightedGraph<int> testGraph = new WeightedGraph<int>();

            testGraph.addVertex("A", 0);
            testGraph.addVertex("B", 1);
            testGraph.addVertex("C", 2);

            testGraph.addEdge("A", "B", rand.Next(1, 50));
            testGraph.addEdge("B", "C", rand.Next(1, 50));

            Console.WriteLine(testGraph.distanceBetween("A", "B"));
            Console.WriteLine(testGraph.distanceBetween("A", "C"));

            testGraph.removeEdge("B", "C");
            testGraph.removeEdge("B", "F");

            Console.WriteLine(testGraph.distanceBetween("A", "B"));
            Console.WriteLine(testGraph.distanceBetween("A", "C"));

            Console.WriteLine();
            testGraph.print();

            Console.WriteLine();
            Console.WriteLine();

            curGraph.breadthFirstSearch("A", "D");
            curGraph.depthFirstSearch("A", "D");
        }

        static void SegmentTreeTest()
        {
            int[] A = { 8, 7, 3, 9, 5, 1, 10 };
            SegmentTree<int> t = new SegmentTree<int>(A.Length);
            t.buildTree(A);
            Console.WriteLine("{0} ", t.get(0, 1));
            Console.WriteLine("{0} ", t.get(1, 1));
            Console.WriteLine("{0} ", t.get(1, 2));
            Console.WriteLine("{0} ", t.get(1, 3));
            Console.WriteLine("{0} ", t.get(0, 3));
            Console.WriteLine("{0} ", t.get(3, 3));
            Console.WriteLine();
            t.set(11, 2, 2);
            Console.WriteLine("{0} ", t.get(0, 1));
            Console.WriteLine("{0} ", t.get(1, 1));
            Console.WriteLine("{0} ", t.get(1, 2));
            Console.WriteLine("{0} ", t.get(1, 3));
            Console.WriteLine("{0} ", t.get(0, 3));
            Console.WriteLine("{0} ", t.get(3, 3));
            Console.WriteLine();
            t.set(33, 1, 2);
            Console.WriteLine("{0} ", t.get(0, 1));
            Console.WriteLine("{0} ", t.get(1, 1));
            Console.WriteLine("{0} ", t.get(1, 2));
            Console.WriteLine("{0} ", t.get(1, 3));
            Console.WriteLine("{0} ", t.get(0, 3));
            Console.WriteLine("{0} ", t.get(3, 3));
            Console.WriteLine();
        }

        static void SplayTreeTest()
        {
            SplayTree<int> impl = new SplayTree<int>();
            impl.add(17);
            impl.add(39);
            impl.add(22);
            impl.add(42);
            impl.add(70);
            impl.add(64);
            impl.add(84);
            impl.add(99);

            Console.WriteLine("Preorder after insert: " + impl);

            Console.WriteLine("Leave counts: " + impl.leafCount(impl.getRoot()));
            Console.WriteLine("Leave counts: " + impl.leafSum(impl.getRoot()));

            impl.remove(22);
            Console.WriteLine("After delete preorder: " + impl);

            Console.WriteLine("Node found or not: " + impl.contains(42));
            Console.WriteLine("After search preorder: " + impl);

            Console.WriteLine("Node found or not: " + impl.contains(98));
            Console.WriteLine("After search preorder: " + impl);
        }

        static void TernaryTreeTest()
        {
            TernaryTree<int> testTree = new TernaryTree<int>();
            ArrayList<int> list = new ArrayList<int>();
            list.appendAll(new int[] { 5, 4, 9, 5, 7, 2, 2 });
            testTree.addToTree(list);

            testTree.print();
        }

        static void RedBlackTreeTest()
        {
            RedBlackTree<int> tree = new RedBlackTree<int>();

            Random rand = new Random();

            for (int i = 0; i < 25; i++)
            {
                tree.add(rand.Next(0, 10));
            }

            tree.print();
        }
        #endregion
    }
}