/*
 * Author:  Daniel Szelogowski
 * Created: 4/7/17
 * Purpose: A collection of data structures written in C# using generics.
 * 
 * Current implemented:
 *  -Linked List
 *  -Doubly Linked List
 *  -Stack
 *  -Queue
 *  -Sorted Set
 *  -Set
 *  -Multiset (Sorted List)
 *  -Bag
 *  -Binary (Search) Tree
 *  -Priority Queue
 *  -ArrayList
 *  -Deque (Double Ended Queue)
 *  -Circular Queue
 *  -Circular Linked List
 *  -SortedMap
 *  -Map
 *  -TreeMap
 *  -MultiMap
 *  -HashMap (Dictionary)
 *  -Treap
 *  -HashSet
 *  -TreeSet
 *  -Graph (Unweighted) (Adjacency List)
 *  -Graph (Weighted) (Adjacency List)
 *  -Fenwick Tree
 *  -Trie
 *  -Union Find (Disjointed Set)
 *  -Heap
 *  -BitSet
 *  -Skip List
 *  -Unrolled List (Linked List)
 *  -Sorted List (Linked List)
 *  -Interval Tree
 *  -Segment Tree
 *  -Splay Tree
 *  -Ternary Tree
 *  -Red Black Tree
 *
 * To do:
 *  -Queap
 *  -Quad Tree
 *  -Scapegoat Tree
 *  -2 3 Tree (2-3)
 *  -2 4 Tree (2-3-4)
 *  -AVL Tree
 *  -B-Tree
 *  -B+Tree
 * 
 **************************************************************************/

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Adscol
{
    interface AdsClass<T>
    {
        //TODO: void removeAll(T t);, implement IEnumerable, change remove(int) to removeAt, make remove(T), int indexOf
        void print();
        ArrayList<T> getList();
        bool contains(T t);
        void clear();
        int size();
        bool isEmpty();
    }

    interface AdsClassMin
    {
        void clear();
        int size();
        bool isEmpty();
    }

    class Node<T>
    {
        public T myObj;
        public Node<T> myPrev;
        public Node<T> myNext;

        public Node(T t)
        {
            myObj = t;
            myNext = null;
            myPrev = null;
        }
    }

    class LinkedList<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;
        private Node<T> myFront;

        public LinkedList()
        {
            myList = null;
            myLast = null;
            myFront = null;
        }

        public LinkedList(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
            myFront = myList;
        }

        public T this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
                myFront = temp;
            }
            else
            {
                if (myFront == null)
                {
                    myLast = myList;
                    while (myLast.myNext != null)
                    {
                        myLast = myLast.myNext;
                    }
                    myFront = myLast;
                }
                myFront.myNext = temp;
                myFront = myFront.myNext;
            }
        }

        public void add(int index, T t)
        {
            if (index == 0)
            {
                Node<T> temp = new Node<T>(t);
                temp.myNext = myList;
                myList = temp;
            }
            else if (index >= this.size() - 1)
            {
                this.add(t);
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> temp = new Node<T>(t);
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
                myFront = myLast;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        Node<T> temp = myLast;
                        temp.myNext = myLast.myNext.myNext;
                        myLast = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void set(int index, T t)
        {
            Node<T> temp = new Node<T>(t);
            if (index == 0)
            {
                temp.myNext = myList.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = temp;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) return myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) return myLast.myObj;
            return default(T);
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
            myFront = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class DoublyLinkedList<T> : AdsClass<T>
    {
        private Node<T> myList;

        public DoublyLinkedList()
        {
            myList = null;
        }

        public DoublyLinkedList(T t)
        {
            this.add(t);
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myList.myNext = myList;
                myList.myPrev = myList;
            }
            else
            {
                temp.myNext = myList;
                temp.myPrev = myList.myPrev;
                myList.myPrev = temp;
                temp.myPrev.myNext = temp;
            }
        }

        public void add(int index, T t)
        {
            throw new NotImplementedException();
        }

        public void remove(int index)
        {
            throw new NotImplementedException();
        }

        //TODO: Remove
        public void removeLast()
        {
            myList.myPrev = myList.myPrev.myPrev;
            myList.myPrev.myNext = myList;
        }

        //TODO: Remove
        public void removeFirst()
        {
            Node<T> temp = myList.myNext;
            temp.myPrev = myList.myPrev;
            temp.myNext = myList.myNext.myNext;
            myList.myPrev.myNext = temp;
            myList = temp;
        }

        public void set(int index, T t)
        {
            throw new NotImplementedException();
        }

        public T get(int index)
        {
            int cnt = 0;
            Node<T> temp = myList;
            if (cnt == index)
            {
                return temp.myObj;
            }
            else
            {
                cnt++;
                if (cnt == index) return temp.myNext.myObj;
            }
            temp = temp.myNext;

            while ((temp != myList) && (cnt <= index))
            {
                if (cnt == index) return temp.myObj;
                temp = temp.myNext;
                cnt++;
            }
            if (cnt == index) return temp.myObj;
            return default(T);
        }

        public void print()
        {
            Node<T> temp = myList;
            Console.WriteLine(myList.myObj);
            temp = temp.myNext;

            while (temp != myList)
            {
                Console.WriteLine(temp.myObj);
                temp = temp.myNext;
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = getList();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
        }

        public int size()
        {
            if (myList == null) return 0;

            int cnt = 0;
            Node<T> temp = myList;
            cnt++;
            temp = myList.myNext;

            while (temp != myList)
            {
                cnt++;
                temp = temp.myNext;
            }

            return cnt;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }
    }

    class Stack<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Stack()
        {
            myList = new ArrayList<T>();
        }

        public Stack(T t) : this()
        {
            myList.add(t);
        }

        public void push(T t)
        {
            myList.add(t);
        }

        public T pop()
        {
            if (myList.size() == 0) return default(T);
            T temp = myList[myList.size() - 1];
            myList.remove(myList.size() - 1);
            return temp;
        }

        public T peek()
        {
            return myList[myList.size() - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Queue<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Queue()
        {
            myList = new ArrayList<T>();
        }

        public Queue(T t) : this()
        {
            myList.add(t);
        }

        public void enqueue(T t)
        {
            myList.add(t);
        }

        public T dequeue()
        {
            if (myList.size() == 0) return default(T);
            T temp = myList[0];
            myList.remove(0);
            return temp;
        }

        public T peek()
        {
            if (myList.size() == 0) return default(T);
            return myList[0];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class SortedSet<T> : AdsClass<T> where T : IComparable
    {
        private ArrayList<T> myList;

        private void addSorted(T t)
        {
            for (int i = 0; i < myList.size(); i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.add(i, t);
                    return;
                }
            }
            myList.add(t);
        }

        public SortedSet()
        {
            myList = new ArrayList<T>();
        }

        public SortedSet(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Set<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Set()
        {
            myList = new ArrayList<T>();
        }

        public Set(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) myList.add(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Multiset<T> : AdsClass<T> where T : IComparable
    {
        private ArrayList<T> myList;

        private void addSorted(T t)
        {
            for (int i = 0; i < myList.size(); i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.add(i, t);
                    return;
                }
            }
            myList.add(t);
        }

        public Multiset()
        {
            myList = new ArrayList<T>();
        }

        public Multiset(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public Adscol.Set<T> getSet()
        {
            var items = new Adscol.Set<T>();

            foreach (T item in myList)
            {
                items.add(item);
            }

            return items;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Bag<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Bag()
        {
            myList = new ArrayList<T>();
        }

        public Bag(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            myList.add(t);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class TreeNode<T> where T : IComparable
    {
        public T myObj;
        public TreeNode<T> myLeft;
        public TreeNode<T> myRight;

        public TreeNode(T t)
        {
            myObj = t;
            myLeft = null;
            myRight = null;
        }

        public TreeNode(T t, TreeNode<T> myLeft, TreeNode<T> myRight)
        {

            this.myObj = t;
            this.myLeft = myLeft;
            this.myRight = myRight;
        }
    }

    class BinaryTree<T> : AdsClassMin where T : IComparable
    {
        private TreeNode<T> root;
        private ArrayList<T> items;

        private void getListInOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            items.add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.add(r.myObj);
        }

        private static void printInOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            printInOrderT(r.myLeft);
            Console.WriteLine(r.myObj);
            printInOrderT(r.myRight);
        }

        private static void printPreOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            Console.WriteLine(r.myObj);
            printPreOrderT(r.myLeft);
            printPreOrderT(r.myRight);
        }

        private static void printPostOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            printPostOrderT(r.myLeft);
            printPostOrderT(r.myRight);
            Console.WriteLine(r.myObj);
        }

        private static void invertTree(TreeNode<T> r)
        {
            if (r == null) return;
            TreeNode<T> temp = r.myLeft;
            r.myLeft = r.myRight;
            r.myRight = temp;
            invertTree(r.myLeft);
            invertTree(r.myRight);
        }

        private static int countItems(TreeNode<T> r)
        {
            if (r == null) return 0;
            return countItems(r.myLeft) + 1 + countItems(r.myRight);
        }

        private static int numCounter(TreeNode<T> r, T t)
        {
            if (r == null) { return 0; }

            if (r.myObj.Equals(t))
            {
                return numCounter(r.myLeft, t) + 1 + numCounter(r.myRight, t);
            }
            else
            {
                return numCounter(r.myLeft, t) + 0 + numCounter(r.myRight, t);
            }
        }

        private int maxWidth = 0;

        private int findMaxWidth(TreeNode<T> r)
        {
            Queue<TreeNode<T>> q = new Queue<TreeNode<T>>();
            int levelNodes = 0;
            if (r == null) return 0;
            q.enqueue(r);

            while (!q.isEmpty())
            {
                levelNodes = q.size();

                if (levelNodes > maxWidth)
                {
                    maxWidth = levelNodes;
                }

                while (levelNodes > 0)
                {
                    TreeNode<T> n = q.dequeue();
                    if (n.myLeft != null) q.enqueue(n.myLeft);
                    if (n.myRight != null) q.enqueue(n.myRight);
                    levelNodes--;
                }
            }

            return maxWidth;
        }

        private int findMaxHeight(TreeNode<T> r)
        {
            if (r == null) return 0;
            return (1 + Math.Max(findMaxHeight(r.myLeft), findMaxHeight(r.myRight)));
        }

        private void addNode(TreeNode<T> node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                TreeNode<T> prev = root;
                TreeNode<T> spot = root;

                while (spot != null)
                {
                    if (node.myObj.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if (node.myObj.CompareTo(prev.myObj) == -1)
                {
                    prev.myLeft = node;
                }
                else
                {
                    prev.myRight = node;
                }
            }
        }

        public BinaryTree()
        {
            root = null;
            items = new ArrayList<T>();
        }

        public BinaryTree(T t) : this()
        {
            this.add(t);
        }

        public void add(T t)
        {
            TreeNode<T> temp = new TreeNode<T>(t);

            if (root == null)
            {
                root = temp;
            }
            else
            {
                TreeNode<T> prev = root;
                TreeNode<T> spot = root;

                while (spot != null)
                {
                    if (temp.myObj.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if (temp.myObj.CompareTo(prev.myObj) == -1)
                {
                    prev.myLeft = temp;
                }
                else
                {
                    prev.myRight = temp;
                }
            }
        }

        public void remove(T t)
        {
            TreeNode<T> prev = root;
            TreeNode<T> spot = root;
            bool passedRoot = false;
            int oldCount = numCounter(root, t);
            while (numCounter(root, t) != (oldCount - 1))
            {
                if (spot.myObj.Equals(t) && !passedRoot)
                {
                    if (root.myRight != null)
                    {
                        TreeNode<T> temp = root.myRight.myLeft;
                        TreeNode<T> tempL = root.myLeft;
                        root = root.myRight;
                        root.myLeft = tempL;
                        this.addNode(temp);
                    }
                    else if (root.myLeft != null)
                    {
                        TreeNode<T> temp = root.myLeft.myRight;
                        TreeNode<T> tempR = root.myRight;
                        root = root.myLeft;
                        root.myRight = tempR;
                        this.addNode(temp);
                    }
                    else
                    {
                        root = null;
                    }
                }

                while (!spot.myObj.Equals(t))
                {
                    if (t.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if ((spot.myLeft == null) && (spot.myRight == null))
                {
                    if (t.CompareTo(prev.myObj) == -1)
                    {
                        prev.myLeft = null;
                    }
                    else
                    {
                        prev.myRight = null;
                    }
                }
                else
                {
                    if ((spot.myLeft == null) || (spot.myRight == null))
                    {
                        if (t.CompareTo(prev.myObj) == -1)
                        {
                            if (spot.myLeft == null)
                            {
                                prev.myLeft = spot.myRight;
                            }
                            else
                            {
                                prev.myLeft = spot.myLeft;
                            }
                        }
                        else
                        {
                            if (spot.myRight == null)
                            {
                                prev.myRight = spot.myRight;
                            }
                            else
                            {
                                prev.myRight = spot.myLeft;
                            }
                        }
                    }
                    else
                    {
                        TreeNode<T> pmover = spot.myRight;
                        TreeNode<T> mover = spot.myRight;
                        while (mover.myLeft != null)
                        {
                            pmover = mover;
                            mover = mover.myLeft;
                        }
                        if (pmover == mover)
                        {
                            spot.myObj = mover.myObj;
                            spot.myRight = mover.myRight;
                        }
                        else
                        {
                            spot.myObj = mover.myObj;
                            pmover.myLeft = mover.myRight;
                        }
                    }
                }
                passedRoot = true;
            }
        }

        public void removeAll(T t)
        {
            while (this.contains(t))
            {
                remove(t);
            }
        }

        public int width()
        {
            int w = findMaxWidth(root);
            maxWidth = 0;
            return w;
        }

        public int height()
        {
            return findMaxHeight(root);
        }

        public void invert()
        {
            invertTree(root);
        }

        public void printPreOrder()
        {
            printPreOrderT(root);
        }

        public void printInOrder()
        {
            printInOrderT(root);
        }

        public void printPostOrder()
        {
            printPreOrderT(root);
        }

        public ArrayList<T> getListPreOrder()
        {
            items.clear();
            getListPreOrderT(root);
            return items;
        }

        public ArrayList<T> getListInOrder()
        {
            items.clear();
            getListInOrderT(root);
            return items;
        }

        public ArrayList<T> getListPostOrder()
        {
            items.clear();
            getListPostOrderT(root);
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getListInOrder();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            root = null;
            items.clear();
        }

        public int size()
        {
            return countItems(root);
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class PQNode<T> : IComparable<PQNode<T>>
    {
        public int priority;
        public T myObj;

        public PQNode(int p, T t)
        {
            priority = p;
            myObj = t;
        }

        public int CompareTo(PQNode<T> o)
        {
            if (this.priority < o.priority) return -1;
            if (this.priority == o.priority) return 0;
            if (this.priority > o.priority) return 1;
            return -1;
        }

        public override string ToString()
        {
            return "Priority: " + this.priority + " Data: " + this.myObj;
        }
    }

    class PriorityQueue<T> : AdsClass<T>
    {
        private ArrayList<PQNode<T>> myList;

        public PriorityQueue()
        {
            myList = new ArrayList<PQNode<T>>();
        }

        public void enqueue(T t, int priority)
        {
            myList.add(new PQNode<T>(priority, t));

            myList.sort();
        }

        public T dequeue()
        {
            if (myList[0] == null) return default(T);
            T temp = myList[0].myObj;
            myList.remove(0);
            return temp;
        }

        public T peek()
        {
            if (myList[0] == null) return default(T);
            return myList[0].myObj;
        }

        public void print()
        {
            foreach (PQNode<T> item in myList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            foreach (PQNode<T> item in myList)
            {
                items.add(item.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();
            return items.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class ArrayList<T> : AdsClass<T>, System.Collections.IEnumerable
    {
        private T[] array;
        private int _size;
        private int memsize;
        const int basesize = 16;

        private void copy(ArrayList<T> a)
        {
            array = new T[a.memsize];
            if (array == null)
            {
                throw memFail();
            }

            for (int i = 0; i < a._size; i++)
            {
                array[i] = a.array[i];
            }

            memsize = a.memsize;
            _size = a._size;
        }

        private void doubleSize()
        {
            T[] temp = null;
            int new_size;
            if (memsize == 0)
            {
                temp = new T[basesize];
                new_size = 1;
            }
            else
            {
                temp = new T[memsize * 2];
                new_size = memsize * 2;
            }
            if (temp == null)
            {
                throw memFail();
            }

            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
            memsize = new_size;
        }

        private void halfsize()
        {
            int resize = memsize / 2;
            if (memsize < (basesize * 2))
            {
                resize = basesize;
            }

            T[] temp = new T[resize];

            if (temp == null)
            {
                throw memFail();
            }

            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
            memsize = resize;
        }

        private Exception memFail()
        {
            return new Exception("Memory Allocation Failed");
        }

        private IndexOutOfRangeException badAccess()
        {
            return new IndexOutOfRangeException("Attempting to subscript array element that doesn't exist");
        }

        public ArrayList()
        {
            array = new T[basesize];
            if (array == null)
            {
                throw memFail();
            }

            _size = 0;
            memsize = basesize;
        }

        public ArrayList(int size)
        {
            if (size == 0)
            {
                array = null;
            }
            else
            {
                array = new T[size];
                if (array == null)
                {
                    throw memFail();
                }
            }

            _size = 0;
            memsize = size;
        }

        public ArrayList(ArrayList<T> a)
        {
            copy(a);
        }

        public T this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(T t)
        {
            if ((_size + 1) > memsize)
            {
                doubleSize();
            }

            array[_size] = t;
            _size++;
        }

        public void add(int index, T t)
        {
            if (index > _size)
            {
                throw badAccess();
            }
            if ((_size + 1) > memsize)
            {
                doubleSize();
            }
            for (int i = _size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = t;
            _size++;
        }

        public void appendAll(ArrayList<T> items)
        {
            for (int i = 0; i < items._size; i++)
            {
                add(items.array[i]);
            }
        }

        public void appendAll(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                add(items[i]);
            }
        }

        public void remove(int index)
        {
            if (index > (_size - 1))
            {
                throw badAccess();
            }
            for (int i = index; i < _size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            _size--;
            if (_size <= (memsize / 4) && memsize > basesize)
            {
                halfsize();
            }
        }

        public void remove(T t)
        {
            int indx = this.indexOf(t);
            this.remove(indx);
        }

        public void set(int index, T t)
        {
            if (index > _size)
            {
                throw badAccess();
            }
            array[index] = t;
        }

        public T get(int index)
        {
            if (index > (_size - 1))
            {
                throw badAccess();
            }
            return array[index];
        }

        public void print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public System.Collections.Generic.List<T> getCollectionsList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < _size; i++)
            {
                items.Add(array[i]);
            }
            return items;
        }

        public ArrayList<T> getList()
        {
            return this;
        }

        public bool contains(T t)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(t))
                {
                    return true;
                }
            }
            return false;
        }

        public void clear()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                remove(i);
            }
        }

        public int size()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int indexOf(T t)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(t)) return i;
            }
            return -1;
        }

        public bool equals(ArrayList<T> a)
        {
            if (_size != a._size)
            {
                return false;
            }

            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(a.array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void reverse()
        {
            T[] temp = new T[memsize];
            if (temp == null)
            {
                throw memFail();
            }

            for (int i = _size - 1; i >= 0; i--)
            {
                temp[_size - 1 - i] = array[i];
            }

            array = temp;
        }

        public void sort()
        {
            array = array.OrderBy(i => i == null).ThenBy(i => i).ToArray();
        }

        public void trimToSize()
        {
            if (_size == memsize)
            {
                return;
            }
            T[] temp = new T[_size];
            if (temp == null)
            {
                memFail();
            }
            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
            memsize = _size;
        }

        public ArrayList<T> subList(int fromIndex, int toIndex)
        {
            ArrayList<T> temp = new ArrayList<T>();
            if (temp == null)
            {
                throw memFail();
            }

            if (toIndex >= _size || fromIndex >= _size)
            {
                throw badAccess();
            }

            if (fromIndex >= toIndex)
            {
                return temp;
            }

            for (int i = fromIndex; i < toIndex; i++)
            {
                temp.add(array[i]);
            }
            return temp;
        }

        private System.Collections.Generic.IEnumerable<T> itemsEnumerable()
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i] != null) yield return array[i];
            }
        }

        private System.Collections.Generic.IEnumerator<T> getEnumerator()
        {
            return itemsEnumerable().GetEnumerator();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return getEnumerator();
        }

        public struct Enumerator : System.Collections.Generic.IEnumerator<T>
        {
            private ArrayList<T> list;
            private int index;
            private T current;

            internal Enumerator(ArrayList<T> list)
            {
                this.list = list;
                index = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {

                ArrayList<T> localList = list;

                if (((uint)index < (uint)localList._size))
                {
                    current = localList.array[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                index = list._size + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get
                {
                    return current;
                }
            }

            Object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == list._size + 1)
                    {
                        throw new Exception("Invalid Operation");
                    }
                    return Current;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                index = 0;
                current = default(T);
            }

        }
    }

    class Deque<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Deque()
        {
            myList = new ArrayList<T>();
        }

        public void pushFront(T t)
        {
            myList.add(0, t);
        }

        public void pushBack(T t)
        {
            myList.add(t);
        }

        public T popFront()
        {
            T obj = myList[0];
            myList.remove(0);
            return obj;
        }

        public T popBack()
        {
            T obj = myList[myList.size() - 1];
            myList.remove(myList.size() - 1);
            return obj;
        }

        public T peekFront()
        {
            return myList[0];
        }

        public T peekBack()
        {
            return myList[myList.size() - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class CircularQueue<T> : AdsClass<T>
    {
        private const int DEFAULT_SIZE = 10;
        private int myMaxSize;
        private int myCurrentSize;
        private int myStart;
        private int myEnd;
        private T[] myBuffer;

        public CircularQueue()
        {
            myMaxSize = DEFAULT_SIZE;
            myBuffer = new T[myMaxSize];
            myStart = 0;
            myEnd = 0;
            myCurrentSize = 0;
        }

        public CircularQueue(int size)
        {
            myMaxSize = size;
            myBuffer = new T[myMaxSize];
            myStart = 0;
            myEnd = 0;
            myCurrentSize = 0;
        }

        public void enqueue(T t)
        {
            myEnd = (myEnd + 1) % myMaxSize;
            myBuffer[myEnd] = t;
            if (myCurrentSize == myMaxSize)
            {
                myStart = (myStart + 1) % myMaxSize;
            }
            else
            {
                myCurrentSize++;
            }
        }

        public T dequeue()
        {
            if (myCurrentSize == 0)
            {
                return default(T);
            }
            else
            {
                myStart = (myStart + 1) % myMaxSize;
                myCurrentSize--;
                return myBuffer[myStart];
            }
        }

        public T peek()
        {
            if (myCurrentSize == 0)
            {
                return default(T);
            }
            else
            {
                myStart = (myStart + 1) % myMaxSize;
                return myBuffer[myStart];
            }
        }

        public void print()
        {
            int tempLoc = 0;
            for (int i = 0; i < myCurrentSize; i++)
            {
                tempLoc = (tempLoc + 1) % myMaxSize;
                Console.WriteLine(myBuffer[tempLoc]);
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            int tempLoc = 0;
            for (int i = 0; i < myCurrentSize; i++)
            {
                tempLoc = (tempLoc + 1) % myMaxSize;
                items.add(myBuffer[tempLoc]);
            }

            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }

            return false;
        }

        public void clear()
        {
            myCurrentSize = 0;
            myStart = 0;
            myEnd = 0;
            myBuffer = new T[myMaxSize];
        }

        public int size()
        {
            return myCurrentSize;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public bool isFull()
        {
            return (myCurrentSize == myMaxSize);
        }
    }

    class CircularLinkedList<T> : AdsClass<T>
    {
        private Node<T> myList;

        public CircularLinkedList()
        {
            myList = null;
        }

        public void addFront(T t)
        {
            Node<T> temp = new Node<T>(t);

            if (myList == null)
            {
                temp.myNext = temp;
                myList = temp;
                return;
            }

            Node<T> myLast = myList;

            while (myLast.myNext != myList)
            {
                myLast = myLast.myNext;
            }

            if (myList != null)
            {
                temp.myNext = myList;
                myLast.myNext = temp;
                myList = temp;
            }
        }

        public void addBack(T t)
        {
            Node<T> temp = new Node<T>(t);

            if (myList == null)
            {
                temp.myNext = temp;
                myList = temp;
                return;
            }

            Node<T> myLast = myList;
            while (myLast.myNext != myList)
            {
                myLast = myLast.myNext;
            }

            myLast.myNext = temp;
            temp.myNext = myList;
        }

        public T popFront()
        {
            Node<T> temp = myList;
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    myLast = myLast.myNext;
                }
                myList = temp.myNext;
                myLast.myNext = myList;
                T obj = temp.myObj;
                temp = null;
                return obj;
            }
            return default(T);
        }

        public T popBack()
        {
            Node<T> temp = myList;
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    temp = myLast;
                    myLast = myLast.myNext;
                }
                T obj = temp.myObj;
                temp.myNext = myList;
                myLast = null;
                return obj;
            }
            return default(T);
        }

        public void print()
        {
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    Console.WriteLine(myLast.myObj);
                    myLast = myLast.myNext;
                }
                Console.WriteLine(myLast.myObj);
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    items.add(myLast.myObj);
                    myLast = myLast.myNext;
                }
                items.add(myLast.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }

            return false;
        }

        public void clear()
        {
            myList = null;
        }

        public int size()
        {
            Node<T> myLast = myList;
            int cnt = 0;
            if (myList != null)
            {
                cnt++;
                while (myLast.myNext != myList)
                {
                    myLast = myLast.myNext;
                    cnt++;
                }
                return cnt;
            }
            return 0;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Entry<K, V> : IComparable<Entry<K, V>>, IComparable where K : IComparable
    {
        private K key;
        private V value;
        private bool cleared;

        public Entry(K key, V value)
        {
            this.key = key;
            this.value = value;
            this.cleared = false;
        }

        public K getKey()
        {
            return key;
        }

        public V getValue()
        {
            return value;
        }

        public bool isCleared()
        {
            return cleared;
        }

        public void setKey(K key)
        {
            this.key = key;
        }

        public void setValue(V value)
        {
            this.value = value;
        }

        public void setCleared(bool cleared)
        {
            this.cleared = cleared;
        }

        public int CompareTo(Entry<K, V> o)
        {
            return key.CompareTo(o.key);
        }

        public int CompareTo(object o)
        {
            return key.CompareTo(((Entry<K, V>)o).key);
        }
    }

    class SortedMap<K, V> : AdsClassMin where K : IComparable
    {
        private ArrayList<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getKey().Equals(key)) return i;
            }
            return -1;
        }

        public SortedMap()
        {
            myMap = new ArrayList<Entry<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            if (!containsKey(key))
            {
                Entry<K, V> temp = new Entry<K, V>(key, value);
                myMap.add(temp);
                myMap.sort();
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap[this.indexOf(key)].getValue();
            }
            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap[i].getKey() + "\tValue: " + myMap[i].getValue());
            }
        }

        public ArrayList<Entry<K, V>> getEntryList()
        {
            return myMap;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap[i].getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Map<K, V> : AdsClassMin where K : IComparable
    {
        private Set<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return i;
            }
            return -1;
        }

        public Map()
        {
            myMap = new Set<Entry<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            if (!containsKey(key))
            {
                Entry<K, V> temp = new Entry<K, V>(key, value);
                myMap.add(temp);
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap.get(this.indexOf(key)).getValue();
            }
            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap.get(i).getKey() + "\tValue: " + myMap.get(i).getValue());
            }
        }

        public Set<Entry<K, V>> getEntrySet()
        {
            return myMap;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap.get(i).getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap.get(i).getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class TreeMap<K, V> : AdsClassMin where K : IComparable
    {
        private BinaryTree<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            ArrayList<Entry<K, V>> list = myMap.getListInOrder();

            for (int i = 0; i < list.size(); i++)
            {
                if (list.get(i).getKey().Equals(key)) return i;
            }
            return -1;
        }

        public TreeMap()
        {
            myMap = new BinaryTree<Entry<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            if (!containsKey(key))
            {
                Entry<K, V> temp = new Entry<K, V>(key, value);
                myMap.add(temp);
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(new Entry<K, V>(key, default(V)));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap.getListInOrder().get(this.indexOf(key)).getValue();
            }
            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap.getListInOrder().get(i).getKey() + "\tValue: " + myMap.getListInOrder().get(i).getValue());
            }
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap.getListInOrder().get(i).getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap.getListInOrder().get(i).getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.getListInOrder().get(i).getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.getListInOrder().get(i).getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class MultiMap<K, V> : AdsClassMin where K : IComparable
    {
        private ArrayList<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return i;
            }
            return -1;
        }

        public MultiMap()
        {
            myMap = new ArrayList<Entry<K, V>>();
        }

        public V[] this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            Entry<K, V> temp = new Entry<K, V>(key, value);
            myMap.add(temp);
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
            }
        }

        public void removeAll(K key)
        {
            while (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
            }
        }

        public V[] get(K key)
        {
            if (containsKey(key))
            {
                int cnt = 0;
                V[] items = new V[keyCount(key)];

                for (int i = 0; i < myMap.size(); i++)
                {
                    if (myMap.get(i).getKey().Equals(key))
                    {
                        items[cnt] = myMap.get(i).getValue();
                        cnt++;
                    }
                }
                return items;
            }
            return new V[0];
        }

        public void print()
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap.get(i).getKey() + "\tValue: " + myMap.get(i).getValue());
            }
        }

        public ArrayList<Entry<K, V>> getEntryList()
        {
            return myMap;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap.get(i).getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap.get(i).getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int keyCount(K key)
        {
            int cnt = 0;

            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) cnt++;
            }

            return cnt;
        }
    }

    class HashMap<K, V> : AdsClassMin where K : IComparable
    {
        private ArrayList<Entry<K, V>> hashTable;

        private int numberOfEntries;
        private int tableSize;
        private double loadFactor;

        private void checkForRehashing()
        {
            loadFactor = (double)numberOfEntries / tableSize;
            if (loadFactor >= 0.75) rehash();
        }

        private void rehash()
        {
            var prevHashTable = hashTable;

            numberOfEntries = 0;
            tableSize *= 2;
            loadFactor = 0;
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++) hashTable.add(null);

            for (int i = 0; i < prevHashTable.size(); i++)
            {
                if (prevHashTable[i] != null && !prevHashTable[i].isCleared())
                    add(prevHashTable[i].getKey(), prevHashTable[i].getValue());
            }
        }

        public HashMap()
        {
            numberOfEntries = 0;
            tableSize = 16;
            loadFactor = 0;
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.add(null);
            }
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public int searchForEntry(K key)
        {
            int index;
            int homePosition = key.GetHashCode() % tableSize;
            for (int i = 0; i < tableSize; i++)
            {
                index = (homePosition + i * ((((homePosition / tableSize) % (tableSize / 2)) * 2) + 1)) % tableSize;
                index = Math.Abs(index);
                if (hashTable[index] == null) return -1;
                else if (hashTable[index].isCleared()) continue;
                else if (key.GetHashCode() == hashTable[index].getKey().GetHashCode()) return index;
            }
            return -1;
        }

        public void add(K key, V value)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo == -1)
            {
                int homePosition = key.GetHashCode() % tableSize;
                int index;
                for (int i = 0; i < tableSize; i++)
                {
                    index = (homePosition + i * ((((homePosition / tableSize) % (tableSize / 2)) * 2) + 1)) % tableSize;
                    index = Math.Abs(index);
                    if (hashTable[index] == null || hashTable[index].isCleared())
                    {
                        hashTable[index] = new Entry<K, V>(key, value);
                        numberOfEntries++;
                        checkForRehashing();
                        return;
                    }
                }
                Console.WriteLine("Unable to put entry. Memory Full.");
            }
            else
            {
                hashTable[positionInfo].setValue(value);
            }
        }

        public void remove(K key)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo != -1)
            {
                hashTable[positionInfo].setCleared(true);
                numberOfEntries--;
            }
        }

        public V get(K key)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo != -1) return hashTable[positionInfo].getValue();

            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) Console.WriteLine("Key: " + hashTable[i].getKey() + "\tValue: " + hashTable[i].getValue());
            }
        }

        public ArrayList<Entry<K, V>> getList()
        {
            var items = new ArrayList<Entry<K, V>>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) items.add(hashTable[i]);
            }
            return items;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) keys.add(hashTable[i].getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) values.add(hashTable[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            return (searchForEntry(key) != -1);
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared())
                    if (hashTable[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            numberOfEntries = 0;
            tableSize = 16;
            loadFactor = 0;
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.add(null);
            }
        }

        public int size()
        {
            return numberOfEntries;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class TreapNode<T> where T : IComparable
    {
        public T myObj;
        public int priority;
        public TreapNode<T> myLeft;
        public TreapNode<T> myRight;

        public TreapNode(T data, int priority)
        {
            this.myObj = data;
            this.priority = priority;

            myLeft = null;
            myRight = null;
        }
    }

    class Treap<T> : AdsClassMin where T : IComparable
    {
        private int numElements;
        private TreapNode<T> root;
        private HashSet<int> hs;

        private ArrayList<T> items;

        private void getListInOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            items.add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.add(r.myObj);
        }

        private static void printInOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            printInOrderT(r.myLeft);
            Console.WriteLine(r.myObj);
            printInOrderT(r.myRight);
        }

        private static void printPreOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            Console.WriteLine(r.myObj);
            printPreOrderT(r.myLeft);
            printPreOrderT(r.myRight);
        }

        private static void printPostOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            printPostOrderT(r.myLeft);
            printPostOrderT(r.myRight);
            Console.WriteLine(r.myObj);
        }

        private static void invertTree(TreapNode<T> r)
        {
            if (r == null) return;
            TreapNode<T> temp = r.myLeft;
            r.myLeft = r.myRight;
            r.myRight = temp;
            invertTree(r.myLeft);
            invertTree(r.myRight);
        }

        private TreapNode<T> rightRotation(TreapNode<T> workingNode)
        {
            TreapNode<T> oldRoot = workingNode;
            TreapNode<T> rtLChld = workingNode.myLeft;
            TreapNode<T> rtLChldRChld = rtLChld.myRight;

            workingNode = rtLChld;
            workingNode.myRight = oldRoot;
            oldRoot.myLeft = rtLChldRChld;

            return workingNode;
        }

        private TreapNode<T> leftRotation(TreapNode<T> workingNode)
        {
            TreapNode<T> oldRoot = workingNode;
            TreapNode<T> rtRChld = workingNode.myRight;
            TreapNode<T> rtRChldLChld = rtRChld.myLeft;

            workingNode = rtRChld;
            workingNode.myLeft = oldRoot;
            oldRoot.myRight = rtRChldLChld;

            return workingNode;
        }

        private TreapNode<T> insert(TreapNode<T> workingNode, T data, int priority)
        {
            if (workingNode == null)
            {
                ++numElements;
                hs.add(priority);
                return new TreapNode<T>(data, priority);
            }
            else if (data.CompareTo(workingNode.myObj) < 0)
            {
                workingNode.myLeft = insert(workingNode.myLeft, data, priority);

                if (workingNode.myLeft.priority < workingNode.priority)
                {
                    workingNode = rightRotation(workingNode);
                }
            }
            else if (data.CompareTo(workingNode.myObj) > 0)
            {
                workingNode.myRight = insert(workingNode.myRight, data, priority);
                if (workingNode.myRight.priority < workingNode.priority)
                {
                    workingNode = leftRotation(workingNode);
                }
            }
            else
            {
                ;
            }

            return workingNode;
        }

        private TreapNode<T> delete(TreapNode<T> workingNode, T data)
        {
            if (workingNode == null)
            {
                return null;
            }
            else if (data.CompareTo(workingNode.myObj) < 0)
            {
                workingNode.myLeft = delete(workingNode.myLeft, data);
            }
            else if (data.CompareTo(workingNode.myObj) > 0)
            {
                workingNode.myRight = delete(workingNode.myRight, data);
            }
            else
            {
                if (workingNode.myLeft == null && workingNode.myRight == null)
                {
                    --numElements;
                    hs.remove(workingNode.priority);
                    return null;
                }
                else if (workingNode.myRight == null)
                {
                    workingNode = rightRotation(workingNode);
                    workingNode.myRight = delete(workingNode.myRight, data);
                }
                else if (workingNode.myLeft == null)
                {
                    workingNode = leftRotation(workingNode);
                    workingNode.myLeft = delete(workingNode.myLeft, data);
                }
                else
                {
                    if (workingNode.myLeft.priority < workingNode.myRight.priority)
                    {
                        workingNode = rightRotation(workingNode);
                        workingNode.myRight = delete(workingNode.myRight, data);
                    }
                    else
                    {
                        workingNode = leftRotation(workingNode);
                        workingNode.myLeft = delete(workingNode.myLeft, data);
                    }
                }
            }
            return workingNode;
        }

        private bool contains(TreapNode<T> root, T data)
        {
            if (root == null)
            {
                return false;
            }
            else if (data.CompareTo(root.myObj) < 0)
            {
                return contains(root.myLeft, data);
            }
            else if (data.CompareTo(root.myObj) > 0)
            {
                return contains(root.myRight, data);
            }
            else
            {
                return true;
            }
        }

        private int getHeight(TreapNode<T> workingNode, int currHeight)
        {
            if (workingNode == null) return currHeight;

            currHeight += 1;

            int leftHeight = getHeight(workingNode.myLeft, currHeight);
            int rightHeight = getHeight(workingNode.myRight, currHeight);

            return (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        private int maxWidth = 0;

        private int getWidth(TreapNode<T> r)
        {
            Queue<TreapNode<T>> q = new Queue<TreapNode<T>>();
            int levelNodes = 0;
            if (r == null) return 0;
            q.enqueue(r);

            while (!q.isEmpty())
            {
                levelNodes = q.size();

                if (levelNodes > maxWidth)
                {
                    maxWidth = levelNodes;
                }

                while (levelNodes > 0)
                {
                    TreapNode<T> n = q.dequeue();
                    if (n.myLeft != null) q.enqueue(n.myLeft);
                    if (n.myRight != null) q.enqueue(n.myRight);
                    levelNodes--;
                }
            }

            return maxWidth;
        }

        public Treap()
        {
            hs = new HashSet<int>();
            numElements = 0;
            root = null;
            items = new ArrayList<T>();
        }

        public void add(T data)
        {
            Random rand = new Random();
            int tempPriority = (int)(rand.Next() * int.MaxValue);
            tempPriority += 1;
            while (hs.contains(tempPriority))
            {
                tempPriority = (int)(rand.Next() * int.MaxValue);
                tempPriority += 1;
            }

            root = insert(root, data, tempPriority);
        }

        public void add(T data, int priority)
        {
            if (hs.contains(priority)) return;

            root = insert(root, data, priority);
        }

        public void remove(T data)
        {
            root = delete(root, data);
        }


        public void removeAll(T t)
        {
            while (this.contains(t))
            {
                remove(t);
            }
        }

        public int width()
        {
            int w = getWidth(root);
            maxWidth = 0;
            return w;
        }

        public int height()
        {
            return getHeight(root, -1);
        }

        public void invert()
        {
            invertTree(root);
        }

        public void printPreOrder()
        {
            printPreOrderT(root);
        }

        public void printInOrder()
        {
            printInOrderT(root);
        }

        public void printPostOrder()
        {
            printPreOrderT(root);
        }

        public ArrayList<T> getListPreOrder()
        {
            items.clear();
            getListPreOrderT(root);
            return items;
        }

        public ArrayList<T> getListInOrder()
        {
            items.clear();
            getListInOrderT(root);
            return items;
        }

        public ArrayList<T> getListPostOrder()
        {
            items.clear();
            getListPostOrderT(root);
            return items;
        }

        public bool contains(T data)
        {
            return contains(root, data);
        }

        public void clear()
        {
            hs.clear();
            numElements = 0;
            root = null;
            items.clear();
        }

        public int size()
        {
            return numElements;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class HSNode<T> : IComparable<T> where T : IComparable<T>
    {
        private enum State
        {
            EMPTY,
            IN_USE,
            DELETED
        }

        private T element;
        private State state = State.EMPTY;

        public HSNode(T o)
        {
            setElement(o);
        }

        public int CompareTo(T other)
        {
            int cmpTo = element.CompareTo(other);
            return state == State.IN_USE ? cmpTo : -1;
        }

        public bool equals(T other)
        {
            if (state != State.IN_USE)
                return false;

            return this.CompareTo(other) == 0;
        }

        public bool isEmpty()
        {
            return state == State.EMPTY;
        }

        public bool isInUse()
        {
            return state == State.IN_USE;
        }

        public T getElement()
        {
            return element;
        }

        public void setElement(T element)
        {
            state = State.IN_USE;
            this.element = element;
        }

        public void remove()
        {
            state = State.DELETED;
        }
    }

    class HashSet<T> : AdsClass<T> where T : IComparable<T>
    {

        private bool insert(int index, T element)
        {
            if (element == null)
                return false;

            if (elements[index] == null)
            {
                elements[index] = new HSNode<T>(element);
                return true;
            }

            if (elements[index].isInUse())
            {
                if (elements[index].equals(element))
                    return false;

                return doubleHash(index, element);
            }

            elements[index].setElement(element);
            return true;

        }

        private bool doubleHash(int index, T element)
        {

            int loopCount = 1;
            bool spaceFound = false;

            while (!spaceFound)
            {
                int newHash = getDoubleHashVal(index, loopCount);
                if (elements[newHash] == null)
                {
                    elements[newHash] = new HSNode<T>(element);
                    return true;
                }

                if (elements[newHash].equals(element))
                    return false;

                if (!elements[index].isInUse())
                {
                    elements[index].setElement(element);
                    return true;
                }

                loopCount++;

            }

            return false;
        }

        private int getDoubleHashVal(int hash, int loopCount)
        {
            loopCount = loopCount % elements.Length;
            return Math.Abs((hash + loopCount * secondaryHash(hash) % elements.Length) % elements.Length);

        }

        private int secondaryHash(int hash)
        {
            return (7919 - (hash % 7919)) % elements.Length;
        }

        private int hashCode(object o)
        {
            return Math.Abs(o.GetHashCode()) % elements.Length;
        }

        private void extendElementsArray()
        {
            HSNode<T>[] oldArray = elements;
            elements = new HSNode<T>[elements.Length * 2 + 1];


            for (int i = 0; i < oldArray.Length; i++)
            {
                if (oldArray[i] != null && oldArray[i].isInUse())
                    insert(hashCode(oldArray[i].getElement()), oldArray[i].getElement());
            }
        }

        private const int defaultSize = 100;
        private HSNode<T>[] elements;
        private int noElements = 0;

        public HashSet()
        {
            elements = new HSNode<T>[defaultSize];
        }

        public HashSet(int initialSize)
        {
            elements = new HSNode<T>[initialSize];
        }

        public void add(T t)
        {
            if (noElements >= elements.Length - 1) extendElementsArray();

            bool inserted = insert(hashCode(t), t);
            if (inserted) noElements++;
        }

        public void remove(T t)
        {
            int hash = hashCode(t);

            if (elements[hash] == null) return;

            if (elements[hash].equals(t))
            {
                elements[hash].remove();
                noElements--;
                return;
            }

            bool stop = false;
            int loopCount = 1;
            while (!stop)
            {
                int newHash = getDoubleHashVal(hash, loopCount);

                if (elements[newHash] == null || elements[newHash].isEmpty()) return;

                if (elements[newHash].equals(t))
                {
                    elements[newHash].remove();
                    noElements--;
                    return;
                }
                loopCount++;
            }
        }

        public void print()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].isInUse())
                    Console.WriteLine(elements[i].getElement());
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].isInUse())
                    items.add(elements[i].getElement());
            }

            return items;
        }

        public bool contains(T t)
        {
            int hash = hashCode(t);
            if (elements[hash] == null)
                return false;


            if (elements[hash].equals(t))
            {
                return true;
            }

            bool stop = false;
            int loopCount = 1;
            while (!stop)
            {
                int newHash = getDoubleHashVal(hash, loopCount);

                if (elements[newHash] == null || elements[newHash].isEmpty())
                    return false;

                if (elements[newHash].equals(t))
                {
                    return true;
                }
                loopCount++;
            }

            return false;

        }

        public void clear()
        {
            elements = new HSNode<T>[defaultSize];
            noElements = 0;
        }
        public int size()
        {
            return noElements;
        }

        public bool isEmpty()
        {
            return noElements == 0;
        }
    }

    class TreeSet<T> : AdsClass<T> where T : IComparable
    {
        private BinaryTree<T> tree;

        public TreeSet()
        {
            tree = new BinaryTree<T>();
        }

        public TreeSet(T t) : this()
        {
            tree.add(t);
        }

        public void add(T t)
        {
            if (!tree.contains(t))
            {
                tree.add(t);
            }
        }

        public void remove(T t)
        {
            tree.remove(t);
        }

        public void print()
        {
            tree.printInOrder();
        }

        public ArrayList<T> getList()
        {
            return tree.getListInOrder();
        }

        public bool contains(T t)
        {
            return tree.contains(t);
        }

        public void clear()
        {
            tree.clear();
        }

        public int size()
        {
            return tree.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class GraphNode<T> : IComparable<GraphNode<T>>
    {
        private string id;
        private T data;
        private ArrayList<GraphNode<T>> neighbors;

        public GraphNode(string id, T data)
        {
            this.id = id;
            this.data = data;
            this.neighbors = new ArrayList<GraphNode<T>>();
        }

        public string getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public T getData()
        {
            return this.data;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public bool hasNeighbor(GraphNode<T> node)
        {
            return this.neighbors.contains(node);
        }

        public void addNeighbor(GraphNode<T> node)
        {
            if (!this.neighbors.contains(node))
            {
                this.neighbors.add(node);
            }
        }

        public void removeNeighbor(GraphNode<T> node)
        {
            this.neighbors.remove(node);
        }

        public void sortNeighbors()
        {
            this.neighbors.sort();
        }

        public ArrayList<GraphNode<T>> getNeighbors()
        {
            return this.neighbors;
        }

        public override string ToString()
        {
            string neighborArray = "[ ";

            foreach (GraphNode<T> x in neighbors)
            {
                neighborArray += x.id + " ";
            }
            neighborArray += "]";
            return "Id: " + this.id + "\tData: " + this.data + "\tNeigbors: " + neighborArray;
        }

        public int CompareTo(GraphNode<T> g)
        {
            return this.id.CompareTo(g.id);
        }
    }

    class Graph<T> : AdsClassMin
    {
        private ArrayList<GraphNode<T>> vertices;

        private GraphNode<T> getVertex(string id)
        {
            foreach (GraphNode<T> vertex in this.vertices)
            {
                if (vertex.getId() == id)
                {
                    return vertex;
                }
            }
            return null;
        }

        public Graph()
        {
            this.vertices = new ArrayList<GraphNode<T>>();
        }

        public void addVertex(string id, T data)
        {
            if (contains(id))
            {
                return;
            }

            this.vertices.add(new GraphNode<T>(id, data));
        }

        /// <summary>
        /// Adds node idTo as a neighbor of idFrom only
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdgeForward(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.addNeighbor(vertexB);
        }

        /// <summary>
        /// Adds node idFrom as a neighbor of idTo only
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdgeBackward(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexB.addNeighbor(vertexA);
        }

        /// <summary>
        /// Adds nodes idFrom and idTo as neighbors of each other
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdge(string idFrom, string idTo)
        {
            addEdgeForward(idFrom, idTo);
            addEdgeBackward(idFrom, idTo);
        }

        public void removeVertex(string id)
        {
            GraphNode<T> vertex = getVertex(id);

            if (vertex == null)
            {
                return;
            }

            vertices.remove(vertices.indexOf(vertex));
        }

        public void removeEdge(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.removeNeighbor(vertexB);
            vertexB.removeNeighbor(vertexA);
        }

        public T getNodeData(string id)
        {
            GraphNode<T> node = getVertex(id);

            if (node != null)
            {
                return node.getData();
            }
            else
            {
                return default(T);
            }
        }

        public void setNodeData(string id, T data)
        {
            GraphNode<T> node = getVertex(id);

            if (node != null)
            {
                node.setData(data);
            }
        }

        public void print()
        {
            foreach (GraphNode<T> x in vertices)
            {
                Console.WriteLine(x.ToString());
            }
        }

        public ArrayList<GraphNode<T>> getList()
        {
            return vertices.getList();
        }

        public bool contains(string vertexId)
        {
            return getVertex(vertexId) != null;
        }

        public void clear()
        {
            vertices.clear();
        }

        public int size()
        {
            return vertices.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int distanceBetween(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return 0;
            }

            ArrayList<GraphNode<T>> visited = new ArrayList<GraphNode<T>>();
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();

            int distance = 0;
            queue.enqueue(vertexA);

            while (!queue.isEmpty())
            {
                GraphNode<T> current = queue.dequeue();
                visited.add(current);

                distance++;

                foreach (GraphNode<T> currentNeighbor in current.getNeighbors())
                {
                    if (currentNeighbor == vertexB)
                    {
                        return distance;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                    }
                }
            }

            return 0;
        }

        public bool pathExists(string idFrom, string idTo)
        {
            return distanceBetween(idFrom, idTo) > 0;
        }

        public void depthFirstSearch(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<GraphNode<T>> visited = new ArrayList<GraphNode<T>>();
            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();

            stack.push(vertexA);
            bool founder = false;

            while (!stack.isEmpty() && !founder)
            {
                GraphNode<T> current = stack.pop();
                current.sortNeighbors();
                visited.add(current);

                if (current.getNeighbors().contains(vertexB))
                {
                    founder = true;
                }

                foreach (GraphNode<T> currentNeighbor in current.getNeighbors())
                {
                    currentNeighbor.sortNeighbors();
                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    foreach (GraphNode<T> neighborFriends in currentNeighbor.getNeighbors())
                    {
                        if (!visited.contains(neighborFriends))
                        {
                            stack.push(neighborFriends);
                        }
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        stack.push(currentNeighbor);
                    }
                }
            }

            Console.Write("DFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "-->");
            }
            Console.WriteLine(idTo);
        }

        public void breadthFirstSearch(string idFrom, string idTo)
        {
            GraphNode<T> vertexA = getVertex(idFrom);
            GraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<GraphNode<T>> visited = new ArrayList<GraphNode<T>>();
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();

            queue.enqueue(vertexA);
            bool founder = false;

            while (!queue.isEmpty() && !founder)
            {
                GraphNode<T> current = queue.dequeue();
                visited.add(current);

                foreach (GraphNode<T> currentNeighbor in current.getNeighbors())
                {
                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                    }
                }
            }

            Console.Write("BFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "-->");
            }
            Console.WriteLine(idTo);
        }
    }

    class WeightedGraphNode<T> : IComparable<WeightedGraphNode<T>>, IComparable
    {
        private string id;
        private T data;
        private SortedMap<WeightedGraphNode<T>, int> neighbors;

        public WeightedGraphNode(string id, T data)
        {
            this.id = id;
            this.data = data;
            this.neighbors = new SortedMap<WeightedGraphNode<T>, int>();
        }

        public string getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public T getData()
        {
            return this.data;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public bool hasNeighbor(WeightedGraphNode<T> node)
        {
            return this.neighbors.containsKey(node);
        }

        public void addNeighbor(WeightedGraphNode<T> node, int cost)
        {
            if (!this.neighbors.containsKey(node))
            {
                this.neighbors.add(node, cost);
            }
        }

        public void removeNeighbor(WeightedGraphNode<T> node)
        {
            this.neighbors.remove(node);
        }

        public SortedMap<WeightedGraphNode<T>, int> getNeighbors()
        {
            return this.neighbors;
        }

        public override string ToString()
        {
            string neighborArray = "[ ";

            foreach (Entry<WeightedGraphNode<T>, int> x in neighbors.getEntryList())
            {
                neighborArray += x.getKey().id + " " + "Cost: " + x.getValue() + " ";
            }
            neighborArray += "]";
            return "Id: " + this.id + "\tData: " + this.data + "\tNeigbors: " + neighborArray;
        }

        public int CompareTo(WeightedGraphNode<T> g)
        {
            return this.id.CompareTo(g.id);
        }

        public int CompareTo(object g)
        {
            return CompareTo((WeightedGraphNode<T>)g);
        }
    }

    class WeightedGraph<T> : AdsClassMin
    {
        private ArrayList<WeightedGraphNode<T>> vertices;

        private WeightedGraphNode<T> getVertex(string id)
        {
            foreach (WeightedGraphNode<T> vertex in this.vertices)
            {
                if (vertex.getId() == id)
                {
                    return vertex;
                }
            }
            return null;
        }

        public WeightedGraph()
        {
            this.vertices = new ArrayList<WeightedGraphNode<T>>();
        }

        public void addVertex(string id, T data)
        {
            if (contains(id))
            {
                return;
            }

            this.vertices.add(new WeightedGraphNode<T>(id, data));
        }

        /// <summary>
        /// Adds node idTo as a neighbor of idFrom only
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdgeForward(string idFrom, string idTo, int cost)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.addNeighbor(vertexB, cost);
        }

        /// <summary>
        /// Adds node idFrom as a neighbor of idTo only
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdgeBackward(string idFrom, string idTo, int cost)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexB.addNeighbor(vertexA, cost);
        }

        /// <summary>
        /// Adds nodes idFrom and idTo as neighbors of each other
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="idTo"></param>
        public void addEdge(string idFrom, string idTo, int cost)
        {
            addEdgeForward(idFrom, idTo, cost);
            addEdgeBackward(idFrom, idTo, cost);
        }

        public void removeVertex(string id)
        {
            WeightedGraphNode<T> vertex = getVertex(id);

            if (vertex == null)
            {
                return;
            }

            vertices.remove(vertices.indexOf(vertex));
        }

        public void removeEdge(string idFrom, string idTo)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.removeNeighbor(vertexB);
            vertexB.removeNeighbor(vertexA);
        }

        public T getNodeData(string id)
        {
            WeightedGraphNode<T> node = getVertex(id);

            if (node != null)
            {
                return node.getData();
            }
            else
            {
                return default(T);
            }
        }

        public void setNodeData(string id, T data)
        {
            WeightedGraphNode<T> node = getVertex(id);

            if (node != null)
            {
                node.setData(data);
            }
        }

        public void print()
        {
            foreach (WeightedGraphNode<T> x in vertices)
            {
                Console.WriteLine(x.ToString());
            }
        }

        public ArrayList<WeightedGraphNode<T>> getList()
        {
            return vertices.getList();
        }

        public bool contains(string vertexId)
        {
            return getVertex(vertexId) != null;
        }

        public void clear()
        {
            vertices.clear();
        }

        public int size()
        {
            return vertices.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int distanceBetween(string idFrom, string idTo)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return 0;
            }

            ArrayList<WeightedGraphNode<T>> visited = new ArrayList<WeightedGraphNode<T>>();
            Queue<WeightedGraphNode<T>> queue = new Queue<WeightedGraphNode<T>>();
            Queue<int> costs = new Queue<int>();

            int distance = 0;
            queue.enqueue(vertexA);
            costs.enqueue(0);

            while (!queue.isEmpty())
            {
                WeightedGraphNode<T> current = queue.dequeue();
                visited.add(current);
                distance += costs.dequeue();

                foreach (Entry<WeightedGraphNode<T>, int> cn in current.getNeighbors().getEntryList())
                {
                    WeightedGraphNode<T> currentNeighbor = cn.getKey();

                    if (currentNeighbor == vertexB)
                    {
                        return distance;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                        costs.enqueue(cn.getValue());
                    }
                }
            }

            return 0;
        }

        public bool pathExists(string idFrom, string idTo)
        {
            return distanceBetween(idFrom, idTo) > 0;
        }

        public void depthFirstSearch(string idFrom, string idTo)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<WeightedGraphNode<T>> visited = new ArrayList<WeightedGraphNode<T>>();
            Stack<WeightedGraphNode<T>> stack = new Stack<WeightedGraphNode<T>>();
            Stack<int> costs = new Stack<int>();

            stack.push(vertexA);
            bool founder = false;

            while (!stack.isEmpty() && !founder)
            {
                WeightedGraphNode<T> current = stack.pop();
                visited.add(current);

                if (current.getNeighbors().getKeyList().contains(vertexB))
                {
                    founder = true;
                }

                foreach (Entry<WeightedGraphNode<T>, int> cn in current.getNeighbors().getEntryList())
                {
                    WeightedGraphNode<T> currentNeighbor = cn.getKey();

                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    foreach (Entry<WeightedGraphNode<T>, int> nf in currentNeighbor.getNeighbors().getEntryList())
                    {
                        WeightedGraphNode<T> neighborFriends = nf.getKey();

                        if (!visited.contains(neighborFriends))
                        {
                            stack.push(neighborFriends);
                            costs.push(nf.getValue());
                        }
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        stack.push(currentNeighbor);
                        costs.push(cn.getValue());
                    }
                }
            }

            Console.Write("DFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "--" + costs.pop() + "-->");
            }
            Console.WriteLine(idTo);
        }

        public void breadthFirstSearch(string idFrom, string idTo)
        {
            WeightedGraphNode<T> vertexA = getVertex(idFrom);
            WeightedGraphNode<T> vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<WeightedGraphNode<T>> visited = new ArrayList<WeightedGraphNode<T>>();
            Queue<WeightedGraphNode<T>> queue = new Queue<WeightedGraphNode<T>>();
            ArrayList<int> costs = new ArrayList<int>();

            queue.enqueue(vertexA);
            bool founder = false;

            while (!queue.isEmpty() && !founder)
            {
                WeightedGraphNode<T> current = queue.dequeue();
                visited.add(current);

                foreach (Entry<WeightedGraphNode<T>, int> cn in current.getNeighbors().getEntryList())
                {
                    WeightedGraphNode<T> currentNeighbor = cn.getKey();

                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                        costs.add(cn.getValue());
                    }
                }
            }

            Console.Write("BFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "--" + costs[i] + "-->");
            }
            Console.WriteLine(idTo);
        }

        public void dijkstrasAlgorithm(string idTo, string idFrom)
        {
            throw new NotImplementedException();
        }
    }

    class FenwickTree : AdsClassMin
    {
        private int leastSignificantBit(int i)
        {
            return i & -i;
        }

        private long[] tree;
        private int originalSize;

        public FenwickTree(int size)
        {
            tree = new long[size + 1];
            originalSize = size;
        }

        public FenwickTree(long[] values)
        {

            if (values == null) throw new ArgumentNullException("Values array cannot be null!");

            this.tree = (long[])values.Clone();

            for (int i = 1; i < tree.Length; i++)
            {
                int j = i + leastSignificantBit(i);
                if (j < tree.Length) tree[j] += tree[i];
            }
            originalSize = values.Length;

        }

        public void add(int i, long k)
        {
            while (i < tree.Length)
            {
                tree[i] += k;
                i += leastSignificantBit(i);
            }
        }

        public void set(int i, long k)
        {
            long value = sum(i, i);
            add(i, k - value);
        }

        public void print()
        {
            foreach (long x in tree)
            {
                Console.WriteLine(x);
            }
        }

        public ArrayList<long> getList()
        {
            var items = new ArrayList<long>();

            foreach (long x in tree)
            {
                items.add(x);
            }

            return items;
        }

        public bool contains(long l)
        {
            return tree.Contains(l);
        }

        public void clear()
        {
            tree = new long[originalSize + 1];
        }

        public int size()
        {
            return tree.Length;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public long prefixSum(int i)
        {
            long sum = 0L;
            while (i > 0)
            {
                sum += tree[i];
                i &= ~leastSignificantBit(i);
            }
            return sum;
        }

        public long sum(int i, int j)
        {
            if (j < i) throw new ArgumentOutOfRangeException("j must be greater than or equal to i");
            return prefixSum(j) - prefixSum(i - 1);
        }

    }

    class TrieNode
    {
        public char ch;
        public int count = 0;
        public bool isWordEnding = false;
        public HashMap<char, TrieNode> children = new HashMap<char, TrieNode>();

        public TrieNode(char ch)
        {
            this.ch = ch;
        }

        public void addChild(TrieNode node, char c)
        {
            children.add(c, node);
        }
    }

    class Trie
    {
        private void clear(TrieNode node)
        {

            if (node == null) return;

            foreach (char ch in node.children.getKeyList())
            {
                TrieNode nextNode = node.children.get(ch);
                clear(nextNode);
                nextNode = null;
            }

            node.children.clear();
            node.children = null;
        }

        private void findWordsThatStartWith(TrieNode node, string prefix, int currentLevel, string currentWord, ArrayList<string> lstResult)
        {
            if (currentLevel <= prefix.Length - 1)
            {
                TrieNode child = node.children.get(prefix[currentLevel]);
                if (child != null)
                {
                    findWordsThatStartWith(child, prefix, currentLevel + 1, currentWord + prefix[currentLevel], lstResult);
                }
            }
            else
            {
                var enumerator = node.children.getList().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string newWord = currentWord + ((Entry<char, TrieNode>)(enumerator.Current)).getKey();

                    if (((Entry<char, TrieNode>)(enumerator.Current)).getValue().isWordEnding)
                    {
                        lstResult.add(newWord);
                    }

                    findWordsThatStartWith(((Entry<char, TrieNode>)(enumerator.Current)).getValue(), prefix, currentLevel, newWord, lstResult);
                }
            }
        }

        private const char rootCharacter = '\0';
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode(rootCharacter);

        }

        public void add(string key, int numInserts)
        {

            if (key == null) throw new ArgumentNullException();
            if (numInserts <= 0) throw new ArgumentOutOfRangeException("Number of inserts must be greater than zero");

            TrieNode node = root;

            for (int i = 0; i < key.Length; ++i)
            {
                char ch = key[i];
                TrieNode nextNode = node.children.get(ch);

                if (nextNode == null)
                {
                    nextNode = new TrieNode(ch);
                    node.addChild(nextNode, ch);
                }

                node = nextNode;
                node.count += numInserts;
            }

            if (node != root)
            {
                node.isWordEnding = true;
            }
        }

        public void add(string key)
        {
            add(key, 1);
        }

        public void remove(string key, int numDeletions)
        {
            if (!contains(key)) return;

            if (numDeletions <= 0) throw new ArgumentOutOfRangeException("Number of deletions must be positive");

            TrieNode node = root;
            for (int i = 0; i < key.Length; i++)
            {

                char ch = key[i];
                TrieNode curNode = node.children.get(ch);
                curNode.count -= numDeletions;

                if (curNode.count <= 0)
                {
                    node.children.remove(ch);
                    curNode.children = null;
                    curNode = null;
                    return;
                }

                node = curNode;
            }
        }

        public void remove(string key)
        {
            remove(key, 1);
        }

        public bool contains(string key)
        {
            return count(key) != 0;
        }

        public void clear()
        {

            root.children = null;
            root = new TrieNode(rootCharacter);

        }

        public int count(string key)
        {

            if (key == null) throw new ArgumentNullException();

            TrieNode node = root;

            for (int i = 0; i < key.Length; i++)
            {
                char ch = key[i];
                if (node == null) return 0;
                node = node.children.get(ch);
            }

            if (node != null) return node.count;
            return 0;
        }

        public ArrayList<string> findWordsThatStartWith(string prefix)
        {
            ArrayList<string> result = new ArrayList<string>();

            findWordsThatStartWith(root, prefix, 0, string.Empty, result);

            return result;
        }

    }

    class UnionFind
    {
        private int _size;
        private int[] sizers;

        private int[] id;

        private int numComponents;

        public UnionFind(int size)
        {

            if (size <= 0) throw new ArgumentOutOfRangeException("Size <= 0 is not allowed");

            this._size = numComponents = size;
            sizers = new int[size];
            id = new int[size];

            for (int i = 0; i < size; i++)
            {
                id[i] = i;
                sizers[i] = 1;
            }

        }

        public int find(int p)
        {
            int root = p;
            while (root != id[root])
                root = id[root];

            while (p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }

            return root;

        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }

        public int componentSize(int p)
        {
            return sizers[find(p)];
        }

        public int size()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int components()
        {
            return numComponents;
        }

        public void unify(int p, int q)
        {

            int root1 = find(p);
            int root2 = find(q);

            if (root1 == root2) return;

            if (sizers[root1] < sizers[root2])
            {
                sizers[root2] += sizers[root1];
                id[root1] = root2;
            }
            else
            {
                sizers[root1] += sizers[root2];
                id[root2] = root1;
            }

            numComponents--;
        }

    }

    class Heap<T> : AdsClass<T> where T : IComparable
    {
        private TreeNode<T>[] nodes;

        private int elements;
        private int current;

        private bool maxHeapMode;

        private const int FIRST_ELEMENT = 0;
        private const double RESIZE_FACTOR = 0.90;
        private const int RESIZE_INCREMENT = 100;

        private int SIZE = 100;

        private int getmyLeftPos(int parentPos)
        {
            return (2 * parentPos) + 1;
        }

        private int getmyRightPos(int parentPos)
        {
            return (2 * parentPos) + 2;
        }

        private int getParentPos(int sonPos)
        {
            int parentPos;

            if (sonPos % 2 == 0) parentPos = (sonPos / 2) - 1;
            else parentPos = sonPos / 2;

            return parentPos;
        }

        private bool resizeIsNeeded()
        {
            return ((double)(elements / SIZE)) >= RESIZE_FACTOR;
        }

        private void resort()
        {
            bool ordered = false;
            int current = FIRST_ELEMENT;

            while (!ordered)
            {

                int left = getmyLeftPos(current);
                int right = getmyRightPos(current);

                if (left >= elements) ordered = true;
                else
                {

                    if (maxHeapMode)
                    {

                        if (nodes[right] == null || nodes[left].myObj.CompareTo(nodes[right].myObj) > 0)
                        {

                            if (nodes[current].myObj.CompareTo(nodes[left].myObj) < 0)
                            {

                                T aux = nodes[current].myObj;
                                nodes[current].myObj = nodes[left].myObj;
                                nodes[left].myObj = aux;
                                current = left;
                            }
                            else ordered = true;
                        }
                        else if (nodes[left].myObj.CompareTo(nodes[right].myObj) < 0)
                        {

                            if (nodes[current].myObj.CompareTo(nodes[right].myObj) < 0)
                            {
                                T aux = nodes[current].myObj;
                                nodes[current].myObj = nodes[right].myObj;
                                nodes[right].myObj = aux;
                                current = right;
                            }
                            else ordered = true;
                        }
                    }
                    else
                    {

                        if (nodes[right] == null || nodes[left].myObj.CompareTo(nodes[right].myObj) < 0)
                        {
                            if (nodes[current].myObj.CompareTo(nodes[left].myObj) > 0)
                            {

                                T aux = nodes[current].myObj;
                                nodes[current].myObj = nodes[left].myObj;
                                nodes[left].myObj = aux;
                                current = left;
                            }
                            else ordered = true;
                        }
                        else if (nodes[left].myObj.CompareTo(nodes[right].myObj) > 0)
                        {
                            if (nodes[current].myObj.CompareTo(nodes[right].myObj) > 0)
                            {

                                T aux = nodes[current].myObj;
                                nodes[current].myObj = nodes[right].myObj;
                                nodes[right].myObj = aux;
                                current = right;
                            }
                            else ordered = true;
                        }
                    }
                }
            }
        }

        private void resizeTree()
        {
            SIZE += RESIZE_INCREMENT;

            TreeNode<T>[] copy = new TreeNode<T>[SIZE];

            nodes.CopyTo(copy, 0);

            nodes = copy;
        }

        private void sort(int addedPos)
        {
            int parentPos = getParentPos(addedPos);
            bool ordered = false;

            while (parentPos >= 0 && !ordered)
            {
                if (nodes[addedPos].myObj.CompareTo(nodes[parentPos].myObj) < 0 && !maxHeapMode)
                {
                    T aux = nodes[addedPos].myObj;
                    nodes[addedPos].myObj = nodes[parentPos].myObj;
                    nodes[parentPos].myObj = aux;
                    addedPos = parentPos;
                }
                else if (nodes[addedPos].myObj.CompareTo(nodes[parentPos].myObj) > 0 && maxHeapMode)
                {
                    T aux = nodes[addedPos].myObj;
                    nodes[addedPos].myObj = nodes[parentPos].myObj;
                    nodes[parentPos].myObj = aux;
                    addedPos = parentPos;
                }
                else
                {
                    ordered = true;
                }

                parentPos = getParentPos(addedPos);
            }
        }

        /// <summary>
        /// Generates a default (max) heap
        /// </summary>
        public Heap() : this(false)
        {
        }

        /// <summary>
        /// Generates a new heap based on the "minHeap" parameter. If set to true, the heap will be a min heap, otherwise it will default to a max heap.
        /// </summary>
        /// <param name="minHeap"></param>
        public Heap(bool minHeap)
        {
            nodes = new TreeNode<T>[SIZE];

            maxHeapMode = !minHeap;
            elements = 0;
            current = 0;
        }

        public void push(T element)
        {

            if (current == FIRST_ELEMENT && nodes[current] == null)
            {
                nodes[current] = new TreeNode<T>(element);
                elements++;
            }
            else
            {

                int pos = getmyLeftPos(current);
                if (nodes[pos] == null)
                {

                    nodes[pos] = new TreeNode<T>(element);
                    nodes[current].myLeft = nodes[pos];
                    elements++;
                }
                else
                {

                    pos = getmyRightPos(current);
                    if (nodes[pos] == null)
                    {
                        nodes[pos] = new TreeNode<T>(element);
                        nodes[current].myRight = nodes[pos];
                        elements++;
                        current++;
                    }
                }

                sort(pos);
            }

            if (resizeIsNeeded()) resizeTree();
        }

        public T pop()
        {

            T element = peek();
            nodes[FIRST_ELEMENT] = null;

            if (element != null && elements > 0)
            {

                elements--;
                current = getParentPos(elements);

                nodes[FIRST_ELEMENT] = nodes[elements];
                nodes[elements] = null;

                resort();
            }

            return element;
        }

        public T peek()
        {
            if (nodes == null) return default(T);
            return nodes[FIRST_ELEMENT].myObj;
        }

        public void print()
        {
            for (int i = 0; i < elements; i++)
            {
                Console.WriteLine(nodes[i].myObj);
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < elements; i++)
            {
                items.add(nodes[i].myObj);
            }

            return items;
        }

        public bool contains(T t)
        {
            return this.getList().contains(t);
        }

        public void clear()
        {
            nodes = new TreeNode<T>[SIZE];

            SIZE = 100;
            elements = 0;
            current = 0;
        }

        public int size()
        {
            return elements;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public void setMaxHeapMode()
        {
            if (elements > 0) throw new AccessViolationException("This method can only be called if the heap is empty.");
            maxHeapMode = true;
        }

        public void setMinHeapMode()
        {
            if (elements > 0) throw new AccessViolationException("This method can only be called if the heap is empty.");
            maxHeapMode = false;
        }
    }

    class BitSet : AdsClassMin
    {
        private bool[] myList;

        /// <summary>
        /// Generates a bitset of specified size with all values preset to "initialValue"
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initalValue"></param>
        public BitSet(int size, bool initalValue)
        {
            myList = new bool[size];

            for (int i = 0; i < size; i++)
            {
                myList[i] = initalValue;
            }
        }

        /// <summary>
        /// Generates a bitset of specified size with all values preset to false
        /// </summary>
        /// <param name="size"></param>
        public BitSet(int size) : this(size, false)
        {
        }

        public bool this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void set(int index, bool value)
        {
            myList[index] = value;
        }

        public void setAll(bool value)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                myList[i] = value;
            }
        }

        public bool get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            string bin = "";
            for (int i = 0; i < myList.Length; i++)
            {
                bin += ((myList[i]) ? 1 : 0);
                if ((i + 1) % 4 == 0 && (i + 1) != myList.Length) bin += " ";
            }
            char[] arr = bin.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);
        }

        public ArrayList<bool> getList()
        {
            var items = new ArrayList<bool>();

            foreach (bool x in myList)
            {
                items.add(x);
            }

            return items;
        }

        public void clear()
        {
            for (int i = 0; i < myList.Length; i++)
            {
                myList[i] = false;
            }
        }

        /// <summary>
        /// Returns amount of values set to true
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            int cnt = 0;

            for (int i = 0; i < myList.Length; i++)
            {
                if (myList[i])
                {
                    cnt++;
                }
            }

            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public void and(BitSet bits)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                try
                {
                    myList[i] = myList[i] & bits[i];
                }
                catch (Exception)
                { }
            }
        }

        public void or(BitSet bits)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                try
                {
                    myList[i] = myList[i] | bits[i];
                }
                catch (Exception)
                { }
            }
        }

        public void xor(BitSet bits)
        {
            for (int i = 0; i < myList.Length; i++)
            {
                try
                {
                    myList[i] = myList[i] ^ bits[i];
                }
                catch (Exception)
                { }
            }
        }

        public void not()
        {
            for (int i = 0; i < myList.Length; i++)
            {
                myList[i] = !myList[i];
            }
        }

    }

    class SkipNode<T> where T : IComparable
    {
        private int myHeight;
        private SkipNodeList<T> myNodes;
        public T myValue;

        public SkipNode(T t, int height)
        {
            myValue = t;
            myHeight = height;
            myNodes = new SkipNodeList<T>(height);
        }

        public void set(int index, SkipNode<T> n)
        {
            myNodes[index] = n;
        }

        public SkipNode<T> get(int index)
        {
            return myNodes[index];
        }

        public void incrementHeight()
        {
            myNodes.incrementHeight();
        }

        public void decrementHeight()
        {
            myNodes.decremenetHeight();
        }

        public int getHeight()
        {
            return myNodes.getCapacity();
        }

        public SkipNode<T> this[int index]
        {
            get { return myNodes[index]; }
            set { myNodes[index] = value; }
        }

        public override string ToString()
        {
            string str = myValue + "\n";

            foreach (SkipNode<T> node in myNodes.getList())
            {
                str += node.ToString();
                break;
            }

            return str;
        }
    }

    class SkipNodeList<T> : System.Collections.CollectionBase where T : IComparable
    {
        private int myCapacity;

        public SkipNodeList(int height)
        {
            base.InnerList.Capacity = height;
            myCapacity = height;

            for (int i = 0; i < height; i++)
            {
                base.InnerList.Add(null);
            }
        }

        public void incrementHeight()
        {
            myCapacity++;
            base.InnerList.Capacity = myCapacity;
            base.InnerList.Add(null);
        }

        public void decremenetHeight()
        {
            myCapacity--;
            base.InnerList.RemoveAt(myCapacity);
        }

        public void add(SkipNode<T> n)
        {
            if (base.InnerList.Count == myCapacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                base.InnerList.Add(n);
            }
        }

        public void set(int index, SkipNode<T> n)
        {
            base.InnerList[index] = n;
        }

        public SkipNode<T> get(int index)
        {
            return (SkipNode<T>)base.InnerList[index];
        }

        public int getCapacity()
        {
            return myCapacity;
        }

        public SkipNode<T> this[int index]
        {
            get { return get(index); }
            set { set(index, value); }
        }

        public ArrayList<SkipNode<T>> getList()
        {
            var items = new ArrayList<SkipNode<T>>();

            foreach (var x in base.InnerList)
            {
                if (x != null) items.add((SkipNode<T>)x);
            }

            return items;
        }

    }

    class SkipList<T> : AdsClass<T> where T : IComparable
    {
        private SkipNode<T> myHead;
        private int myCount;
        private Random rndNum;

        private const double PROB = 0.5;

        private int chooseRandomHeight(int maxLevel)
        {
            int level = 1;
            while (rndNum.NextDouble() < PROB && level < maxLevel)
            {
                level++;
            }

            return level;
        }

        public SkipList() : this(-1)
        {
        }

        public SkipList(int randomSeed)
        {
            myHead = new SkipNode<T>(default(T), 1);
            myCount = 0;

            if (randomSeed < 0)
            {
                rndNum = new Random();
            }
            else
            {
                rndNum = new Random(randomSeed);
            }
        }

        public void add(T t)
        {
            SkipNode<T>[] updates = new SkipNode<T>[myHead.getHeight()];
            SkipNode<T> current = myHead;
            int i = 0;

            for (i = myHead.getHeight() - 1; i >= 0; i--)
            {
                while (current[i] != null && current[i].myValue.CompareTo(t) < 0)
                    current = current[i];

                updates[i] = current;
            }

            if (current[0] != null && current[0].myValue.CompareTo(t) == 0)
            {
                return;
            }

            SkipNode<T> n = new SkipNode<T>(t, chooseRandomHeight(myHead.getHeight() + 1));
            myCount++;

            if (n.getHeight() > myHead.getHeight())
            {
                myHead.incrementHeight();
                myHead[myHead.getHeight() - 1] = n;
            }

            for (i = 0; i < n.getHeight(); i++)
            {
                if (i < updates.Length)
                {
                    n[i] = updates[i][i];
                    updates[i][i] = n;
                }
            }
        }

        public void remove(T t)
        {
            SkipNode<T>[] updates = new SkipNode<T>[myHead.getHeight()];
            SkipNode<T> current = myHead;

            int i = 0;

            for (i = myHead.getHeight() - 1; i >= 0; i--)
            {
                while (current[i] != null && current[i].myValue.CompareTo(t) < 0)
                    current = current[i];

                updates[i] = current;
            }

            current = current[0];
            if (current != null && current.myValue.CompareTo(t) == 0)
            {
                myCount--;

                for (i = 0; i < myHead.getHeight(); i++)
                {
                    if (updates[i][i] != current)
                    {
                        break;
                    }
                    else
                    {
                        updates[i][i] = current[i];
                    }
                }

                if (myHead[myHead.getHeight() - 1] == null)
                {
                    myHead.decrementHeight();
                }
            }
            else
            {
                return;
            }
        }

        public void print()
        {
            Console.WriteLine(myHead[0].ToString());
        }

        public ArrayList<T> getList()
        {
            throw new NotImplementedException();
        }

        public bool contains(T t)
        {
            SkipNode<T> current = myHead;

            for (int i = myHead.getHeight() - 1; i >= 0; i--)
            {
                while (current[i] != null)
                {
                    int results = current[i].myValue.CompareTo(t);
                    if (results == 0)
                    {
                        return true;
                    }
                    else if (results < 0)
                    {
                        current = current[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return false;
        }

        public void clear()
        {
            myHead = new SkipNode<T>(default(T), 1);
            myCount = 0;
        }

        public int size()
        {
            return myCount;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int getHeight()
        {
            return myHead.getHeight();
        }
    }

    class UnrolledNode<T>
    {
        public T[] myData;
        public int myCount;
        public UnrolledNode<T> myNext;

        public UnrolledNode(int maxCount, params T[] t)
        {
            myNext = null;
            myCount = 0;
            myData = new T[maxCount];

            if (t.Length > maxCount)
            {
                throw new ArgumentOutOfRangeException("Amount of elements must be smaller than maxCount");
            }

            Array.Copy(t, myData, t.Length);
            myCount = t.Length;
        }
    }

    class UnrolledList<T> : AdsClass<T>
    {
        private UnrolledNode<T> myList;
        private UnrolledNode<T> myLast;
        private UnrolledNode<T> myFront;
        private int maxSize;

        /// <param name="maxSize">The max size of each node</param>
        public UnrolledList(int maxSize)
        {
            this.maxSize = maxSize;
            myList = null;
            myLast = null;
            myFront = null;
        }

        /// <param name="maxSize">The max size of each node</param>
        public UnrolledList(int maxSize, params T[] data)
        {
            this.maxSize = maxSize;
            myList = new UnrolledNode<T>(maxSize, data);
            myLast = myList;
            myFront = myList;
        }

        public T[] this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(params T[] t)
        {
            UnrolledNode<T> temp = new UnrolledNode<T>(maxSize, t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
                myFront = temp;
            }
            else
            {
                if (myFront == null)
                {
                    myLast = myList;
                    while (myLast.myNext != null)
                    {
                        myLast = myLast.myNext;
                    }
                    myFront = myLast;
                }
                myFront.myNext = temp;
                myFront = myFront.myNext;
            }
        }

        public void add(int index, params T[] t)
        {
            if (index == 0)
            {
                UnrolledNode<T> temp = new UnrolledNode<T>(maxSize, t);
                temp.myNext = myList;
                myList = temp;
            }
            else if (index >= this.size() - 1)
            {
                this.add(t);
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                UnrolledNode<T> temp = new UnrolledNode<T>(maxSize, t);
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                UnrolledNode<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
                myFront = myLast;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        UnrolledNode<T> temp = myLast;
                        temp.myNext = myLast.myNext.myNext;
                        myLast = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void set(int index, params T[] t)
        {
            UnrolledNode<T> temp = new UnrolledNode<T>(maxSize, t);
            if (index == 0)
            {
                temp.myNext = myList.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = temp;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T[] get(int index)
        {
            int cnt = 0;
            myLast = myList;
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) return myLast.myData;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) return myLast.myData;
            return new T[0];
        }

        public void print()
        {
            myLast = myList;
            int cnt = 1;
            while (myLast != null)
            {
                Console.Write("Node {0}: ", cnt);
                for (int i = 0; i < myLast.myCount; i++)
                {
                    Console.Write(myLast.myData[i]);
                }
                Console.WriteLine();
                cnt++;
                myLast = myLast.myNext;
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            myLast = myList;

            while (myLast != null)
            {
                for (int i = 0; i < myLast.myCount; i++)
                {
                    items.add(myLast.myData[i]);
                }
                myLast = myLast.myNext;
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
            myFront = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt += myLast.myCount;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class SortedList<T> : AdsClass<T> where T : IComparable
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addSorted(T t)
        {
            myLast = myList;
            Node<T> temp = new Node<T>(t);
            if (temp.myObj.CompareTo(myLast.myObj) == -1)
            {
                temp.myNext = myLast;
                myList = temp;
                return;
            }

            while (myLast.myNext != null)
            {
                if (temp.myObj.CompareTo(myLast.myNext.myObj) == -1)
                {
                    temp.myNext = myLast.myNext;
                    myLast.myNext = temp;
                    return;
                }
                myLast = myLast.myNext;
            }

            myLast.myNext = temp;
        }

        public SortedList()
        {
            myList = null;
            myLast = null;
        }

        public SortedList(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }


        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            }
            else
            {
                this.addSorted(t);
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index >= (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> tempx;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        tempx = myLast;
                        tempx.myNext = myLast.myNext.myNext;
                        myLast = tempx;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            T obj = default(T);
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) obj = myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) obj = myLast.myObj;
            myLast = myList;
            return obj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < this.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Interval<T> : IComparable
    {
        private long start;
        private long end;
        private T data;

        public Interval(long start, long end, T data)
        {
            this.start = start;
            this.end = end;
            this.data = data;
        }

        public long getStart()
        {
            return start;
        }

        public void setStart(long start)
        {
            this.start = start;
        }

        public long getEnd()
        {
            return end;
        }

        public void setEnd(long end)
        {
            this.end = end;
        }

        public T getData()
        {
            return data;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public bool contains(long time)
        {
            return time < end && time > start;
        }

        public bool intersects(Interval<T> other)
        {
            return other.getEnd() > start && other.getStart() < end;
        }

        public int CompareTo(object other)
        {
            if (start < ((Interval<T>)other).getStart())
            {
                return -1;
            }
            else if (start > ((Interval<T>)other).getStart())
            {
                return 1;
            }
            else if (end < ((Interval<T>)other).getEnd())
            {
                return -1;
            }
            else if (end > ((Interval<T>)other).getEnd())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }

    class IntervalNode<T>
    {

        private SortedMap<Interval<T>, ArrayList<Interval<T>>> intervals;
        private long center;
        private IntervalNode<T> leftNode;
        private IntervalNode<T> rightNode;

        public IntervalNode()
        {
            intervals = new SortedMap<Interval<T>, ArrayList<Interval<T>>>();
            center = 0;
            leftNode = null;
            rightNode = null;
        }

        public IntervalNode(ArrayList<Interval<T>> intervalList)
        {

            intervals = new SortedMap<Interval<T>, ArrayList<Interval<T>>>();

            SortedSet<long> endpoints = new SortedSet<long>();

            foreach (Interval<T> interval in intervalList)
            {
                endpoints.add(interval.getStart());
                endpoints.add(interval.getEnd());
            }

            long median = getMedian(endpoints);
            center = median;

            ArrayList<Interval<T>> left = new ArrayList<Interval<T>>();
            ArrayList<Interval<T>> right = new ArrayList<Interval<T>>();

            foreach (Interval<T> interval in intervalList)
            {
                if (interval.getEnd() < median)
                {
                    left.add(interval);
                }
                else if (interval.getStart() > median)
                {
                    right.add(interval);
                }
                else
                {
                    ArrayList<Interval<T>> posting = intervals.get(interval);
                    if (posting == null)
                    {
                        posting = new ArrayList<Interval<T>>();
                        intervals.add(interval, posting);
                    }
                    posting.add(interval);
                }
            }

            if (left.size() > 0)
            {
                leftNode = new IntervalNode<T>(left);
            }
            if (right.size() > 0)
            {
                rightNode = new IntervalNode<T>(right);
            }
        }

        public ArrayList<Interval<T>> stab(long time)
        {
            ArrayList<Interval<T>> result = new ArrayList<Interval<T>>();

            foreach (Entry<Interval<T>, ArrayList<Interval<T>>> entry in intervals.getEntryList())
            {
                if (entry.getKey().contains(time))
                {
                    foreach (Interval<T> interval in entry.getValue())
                    {
                        result.add(interval);
                    }
                }
                else if (entry.getKey().getStart() > time)
                {
                    break;
                }
            }

            if (time < center && leftNode != null)
            {
                result.appendAll(leftNode.stab(time));
            }
            else if (time > center && rightNode != null)
            {
                result.appendAll(rightNode.stab(time));
            }
            return result;
        }

        public ArrayList<Interval<T>> query(Interval<T> target)
        {
            ArrayList<Interval<T>> result = new ArrayList<Interval<T>>();

            foreach (Entry<Interval<T>, ArrayList<Interval<T>>> entry in intervals.getEntryList())
            {
                if (entry.getKey().intersects(target))
                {
                    foreach (Interval<T> interval in entry.getValue())
                    {
                        result.add(interval);
                    }
                }
                else if (entry.getKey().getStart() > target.getEnd())
                {
                    break;
                }
            }

            if (target.getStart() < center && leftNode != null)
            {
                result.appendAll(leftNode.query(target));
            }
            if (target.getEnd() > center && rightNode != null)
            {
                result.appendAll(rightNode.query(target));
            }

            return result;
        }

        public long getCenter()
        {
            return center;
        }

        public void setCenter(long center)
        {
            this.center = center;
        }

        public IntervalNode<T> getLeft()
        {
            return leftNode;
        }

        public void setLeft(IntervalNode<T> left)
        {
            this.leftNode = left;
        }

        public IntervalNode<T> getRight()
        {
            return rightNode;
        }

        public void setRight(IntervalNode<T> right)
        {
            this.rightNode = right;
        }

        private long getMedian(SortedSet<long> set)
        {
            int i = 0;
            int middle = set.size() / 2;
            foreach (long point in set.getList())
            {
                if (i == middle)
                    return point;
                i++;
            }
            return default(long);
        }

        public override string ToString()
        {
            string sb = "";
            sb += (center + ": ");
            foreach (Entry<Interval<T>, ArrayList<Interval<T>>> entry in intervals.getEntryList())
            {
                sb += ("[" + entry.getKey().getStart() + "," + entry.getKey().getEnd() + "]:{");
                foreach (Interval<T> interval in entry.getValue())
                {
                    sb += ("(" + interval.getStart() + "," + interval.getEnd() + "," + interval.getData() + ")");
                }
                sb += ("} ");
            }
            return sb;
        }
    }

    class IntervalTree<T>
    {
        private IntervalNode<T> head;
        private ArrayList<Interval<T>> intervalList;
        private bool inSync;
        private int _size;

        public IntervalTree()
        {
            this.head = new IntervalNode<T>();
            this.intervalList = new ArrayList<Interval<T>>();
            this.inSync = true;
            this._size = 0;
        }

        public IntervalTree(ArrayList<Interval<T>> intervalList)
        {
            this.head = new IntervalNode<T>(intervalList);
            this.intervalList = new ArrayList<Interval<T>>();
            this.intervalList.appendAll(intervalList);
            this.inSync = true;
            this._size = intervalList.size();
        }

        public ArrayList<T> get(long time)
        {
            ArrayList<Interval<T>> intervals = getIntervals(time);
            ArrayList<T> result = new ArrayList<T>();
            foreach (Interval<T> interval in intervals)
            {
                result.add(interval.getData());
            }

            return result;
        }

        public ArrayList<Interval<T>> getIntervals(long time)
        {
            build();
            return head.stab(time);
        }

        public ArrayList<T> get(long start, long end)
        {
            ArrayList<Interval<T>> intervals = getIntervals(start, end);
            ArrayList<T> result = new ArrayList<T>();

            foreach (Interval<T> interval in intervals)
            {
                result.add(interval.getData());
            }

            return result;
        }

        public ArrayList<Interval<T>> getIntervals(long start, long end)
        {
            build();
            return head.query(new Interval<T>(start, end, default(T)));
        }

        public void addInterval(Interval<T> interval)
        {
            intervalList.add(interval);
            inSync = false;
        }

        public void addInterval(long begin, long end, T data)
        {
            intervalList.add(new Interval<T>(begin, end, data));
            inSync = false;
        }

        public bool isInSync()
        {
            return inSync;
        }

        public void build()
        {
            if (!inSync)
            {
                head = new IntervalNode<T>(intervalList);
                inSync = true;
                _size = intervalList.size();
            }
        }

        public int size()
        {
            return _size;
        }

        public int listSize()
        {
            return intervalList.size();
        }

        public override string ToString()
        {
            return nodeString(head, 0);
        }

        private string nodeString(IntervalNode<T> node, int level)
        {
            if (node == null)
            {
                return "";
            }

            string sb = "";
            for (int i = 0; i < level; i++)
            {
                sb += ("\t");
            }

            sb += (node + "\n");
            sb += (nodeString(node.getLeft(), level + 1));
            sb += (nodeString(node.getRight(), level + 1));

            return sb;
        }
    }

    class SegmentTree<T> : AdsClassMin where T : IComparable
    {
        private int length;
        private ArrayList<T> tree;
        private int startLen;

        private void buildTree(T[] arr, int node, int begin, int end)
        {
            if (begin == end)
            {
                this.tree.set(node, arr[begin]);
            }
            else
            {
                int left = 2 * node;
                int right = 2 * node + 1;
                this.buildTree(arr, left, begin, (begin + end) / 2);
                this.buildTree(arr, right, (begin + end) / 2 + 1, end);
                T i1 = this.tree.get(left);
                T i2 = this.tree.get(right);
                this.tree.set(node, max(i1, i2));
            }
        }

        private T set(T value, int node, int b, int e, int i, int j)
        {
            if (i > e || j < b)
            {
                return this.get(b, e);
            }
            if (b == e)
            {
                this.tree.set(node, value);
                return value;
            }

            if (this.get(node, b, e, i, j).Equals(value))
            {
                return value;
            }

            T t1 = set(value, node * 2, b, (b + e) / 2, i, j);
            T t2 = set(value, node * 2 + 1, (b + e) / 2 + 1, e, i, j);
            T tt = max(t1, t2);
            this.tree.set(node, tt);
            return tt;
        }

        private T get(int node, int b, int e, int i, int j)
        {
            if (i > e || j < b)
            {
                return default(T);
            }
            if (b >= i && e <= j)
            {
                return this.tree.get(node);
            }

            T t1 = get(2 * node, b, (b + e) / 2, i, j);
            T t2 = get(2 * node + 1, (b + e) / 2 + 1, e, i, j);
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            return max(t1, t2);
        }

        public SegmentTree(int len)
        {
            startLen = len;
            this.length = len;
            int arrayLen = 1;
            while (arrayLen < 2 * len)
            {
                arrayLen <<= 1;
            }

            this.tree = new ArrayList<T>();
            for (int i = 0; i < arrayLen; i++)
            {
                this.tree.add(default(T));
            }
        }

        public T max(T t1, T t2)
        {
            return (t1.CompareTo(t2) >= 0) ? t1 : t2;
        }

        public void buildTree(T[] arr)
        {
            this.buildTree(arr, 1, 0, arr.Length - 1);
        }

        public void set(T value, int i)
        {
            set(value, i, i);
        }

        public void set(T value, int i, int j)
        {
            if (i < 0 || j > this.length - 1 || i > j) return;
            set(value, 1, 0, this.length - 1, i, j);
        }

        public T get(int i, int j)
        {
            return this.get(1, 0, this.length - 1, i, j);
        }

        public void clear()
        {
            length = startLen;
            this.tree = new ArrayList<T>();
            int arrayLen = 1;
            while (arrayLen < 2 * length)
            {
                arrayLen <<= 1;
            }
            for (int i = 0; i < arrayLen; i++)
            {
                this.tree.add(default(T));
            }
        }

        public int size()
        {
            return length;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class SplayNode<T> where T : IComparable
    {
        public T data;
        public SplayNode<T> left;
        public SplayNode<T> right;

        public SplayNode(T element)
        {
            this.data = element;
            left = null;
            right = null;
        }
    }

    class SplayTree<T> where T : IComparable
    {
        private static class Add<T>
        {
            public static readonly Func<T, T, T> Do;

            static Add()
            {
                var par1 = Expression.Parameter(typeof(T));
                var par2 = Expression.Parameter(typeof(T));

                var add = Expression.Add(par1, par2);

                Do = Expression.Lambda<Func<T, T, T>>(add, par1, par2).Compile();
            }
        }

        private SplayNode<T> root;
        private string stringx;

        private SplayNode<T> leftRotate(SplayNode<T> node)
        {
            SplayNode<T> newT = node.left;
            node.left = newT.right;
            newT.right = node;
            return newT;
        }

        private SplayNode<T> rightRotate(SplayNode<T> node)
        {
            SplayNode<T> newT = node.right;
            node.right = newT.left;
            newT.left = node;
            return newT;
        }

        private SplayNode<T> add(T item, SplayNode<T> node)
        {
            if (node == null)
            {
                return new SplayNode<T>(item);
            }
            else
            {
                if (item.CompareTo(node.data) < 0)
                {
                    node.left = add(item, node.left);
                }
                else if (item.CompareTo(node.data) > 0)
                {
                    node.right = add(item, node.right);
                }
                return node;
            }
        }

        private void adjustTree(T data)
        {
            bool flag = true;
            SplayNode<T> node = root;
            SplayNode<T> parent;
            SplayNode<T> grparent;
            SplayNode<T> ggparent;
            parent = null;
            grparent = null;
            ggparent = null;

            while (true)
            {
                if (node == null || data.Equals(node.data))
                {
                    break;
                }
                else if (node.left != null && data.CompareTo(node.data) < 0)
                {
                    if (data.Equals(node.left.data))
                    {
                        node = leftRotate(node);
                    }
                    else if (node.left.left != null && data.Equals(node.left.left.data))
                    {
                        grparent = node;
                        parent = node.left;
                        node = leftRotate(grparent);
                        node = leftRotate(parent);
                        flag = true;
                    }
                    else if (node.left.right != null && data.Equals(node.left.right.data))
                    {
                        grparent = node;
                        parent = node.left;
                        grparent.left = rightRotate(parent);
                        node = leftRotate(grparent);
                        flag = true;
                    }
                    else if (data.CompareTo(node.data) < 0)
                    {
                        ggparent = node;
                        node = node.left;
                    }
                }
                else if (node.right != null && data.CompareTo(node.data) > 0)
                {
                    if (data.Equals(node.right.data))
                    {
                        node = rightRotate(node);
                    }
                    else if (node.right.right != null && data.Equals(node.right.right.data))
                    {
                        grparent = node;
                        parent = node.right;
                        node = rightRotate(grparent);
                        node = rightRotate(parent);
                        flag = true;
                    }
                    else if (node.right.left != null && data.Equals(node.right.left.data))
                    {
                        grparent = node;
                        parent = node.right;
                        grparent.right = leftRotate(parent);
                        node = rightRotate(grparent);
                        flag = true;
                    }
                    else if (data.CompareTo(node.data) > 0)
                    {
                        ggparent = node;
                        node = node.right;
                    }
                }
                else if ((node.left == null && data.CompareTo(node.data) < 0) || (node.right == null && data.CompareTo(node.data) > 0))
                {
                    data = node.data;
                    node = root;
                    ggparent = null;
                }
                if (flag && ggparent != null)
                {
                    if (node.data.CompareTo(ggparent.data) < 0)
                    {
                        ggparent.left = node;
                    }
                    else if (node.data.CompareTo(ggparent.data) > 0)
                    {
                        ggparent.right = node;
                    }

                    node = root;
                    ggparent = null;
                    flag = false;
                }
            }
            root = node;
        }

        public SplayTree()
        {
            root = null;
        }

        public void add(T item)
        {
            root = add(item, root);
            adjustTree(item);
        }

        public void remove(T item)
        {
            if (!isNull())
            {
                adjustTree(item);
                if (root != null && root.data.Equals(item))
                {
                    if (root.left != null)
                    {
                        SplayNode<T> tmp = root.right;
                        root = root.left;
                        adjustTree(item);
                        root.right = tmp;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
            }
        }

        public T getRootValue()
        {
            if (root != null)
            {
                return root.data;
            }
            else
            {
                return default(T);
            }
        }

        public SplayNode<T> getRoot()
        {
            return root;
        }

        void preOrder(SplayNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            stringx += node.data + " -> ";
            preOrder(node.left);
            preOrder(node.right);
        }

        public bool isNull()
        {
            return root == null;
        }

        public int leafCount(SplayNode<T> node)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null)
            {
                return 1;
            }
            else
            {
                return leafCount(node.left) + leafCount(node.right);
            }
        }

        public T leafSum(SplayNode<T> node)
        {
            if (node == null)
            {
                return default(T);
            }
            if (node.left == null && node.right == null)
            {
                return node.data;
            }
            else
            {
                return Add<T>.Do(leafSum(node.left), leafSum(node.right));
            }
        }

        public bool contains(T item)
        {
            if (isNull())
            {
                return false;
            }

            adjustTree(item);
            return (root.data.Equals(item));
        }

        public override string ToString()
        {
            stringx = "";
            preOrder(getRoot());
            return stringx;
        }

    }

    class TernaryNode<T> : IComparable<TernaryNode<T>> where T : IComparable
    {
        private T value;

        private TernaryNode<T> smallerChild;
        private TernaryNode<T> largerChild;
        private TernaryNode<T> equalChild;

        public TernaryNode(T value)
        {
            this.value = value;
        }

        public TernaryNode<T> getEqualChild()
        {
            return equalChild;
        }

        public void setEqualChild(TernaryNode<T> equalChild)
        {
            this.equalChild = equalChild;
        }

        public TernaryNode<T> getLargerChild()
        {
            return largerChild;
        }

        public void setLargerChild(TernaryNode<T> largerChild)
        {
            this.largerChild = largerChild;
        }

        public TernaryNode<T> getSmallerChild()
        {
            return smallerChild;
        }

        public void setSmallerChild(TernaryNode<T> smallerChild)
        {
            this.smallerChild = smallerChild;
        }

        public T getValue()
        {
            return value;
        }

        public int CompareTo(TernaryNode<T> o)
        {
            return value.CompareTo(o.getValue());
        }
    }

    class TernaryTree<T> where T : IComparable
    {
        private string sb;
        private TernaryNode<T> root;

        private string printTreeDepthFirst(TernaryNode<T> parent, TernaryNode<T> node, int depth)
        {
            depth++;
            sb += (depth);
            for (int i = 0; i < depth + 1; i++)
            {
                sb += ("\t");
            }
            sb += (String.Format("{0}:{1}\n", node.getValue(), (parent != null) ? parent.getValue().ToString() : ""));

            if (node.getSmallerChild() != null)
            {
                printTreeDepthFirst(node, node.getSmallerChild(), depth);
            }
            if (node.getEqualChild() != null)
            {
                printTreeDepthFirst(node, node.getEqualChild(), depth);
            }
            if (node.getLargerChild() != null)
            {
                printTreeDepthFirst(node, node.getLargerChild(), depth);
            }
            return sb;
        }

        private void addToTree(TernaryNode<T> curNode, TernaryNode<T> newNode)
        {
            int diff = curNode.CompareTo(newNode);

            if (diff < 0)
            {
                if (curNode.getLargerChild() != null)
                {
                    addToTree(curNode.getLargerChild(), newNode);
                }
                else
                {
                    curNode.setLargerChild(newNode);
                }
            }
            else if (diff > 0)
            {
                if (curNode.getSmallerChild() != null)
                {
                    addToTree(curNode.getSmallerChild(), newNode);
                }
                else
                {
                    curNode.setSmallerChild(newNode);
                }
            }
            else
            {
                if (curNode.getEqualChild() != null)
                {
                    addToTree(curNode.getEqualChild(), newNode);
                }
                else
                {
                    curNode.setEqualChild(newNode);
                }
            }
        }

        public TernaryTree()
        {
            root = null;
        }

        public void addToTree(ArrayList<T> list)
        {
            foreach (T t in list)
            {
                addToTree(t);
            }
        }

        public void addToTree(T obj)
        {
            TernaryNode<T> newNode = new TernaryNode<T>(obj);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                addToTree(root, newNode);
            }
        }

        public void print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            sb = "";
            sb += ("Depth\tNode:Parent Values\n");
            sb += ("-----\t------------------\n");
            return printTreeDepthFirst(null, root, 0);
        }
    }

    class RBNode<T> where T : IComparable
    {
        public const bool RED = true;
        public const bool BLACK = false;

        private T data;
        private bool colour = RED;
        private RBNode<T> rightChild;
        private RBNode<T> leftChild;
        private bool _isDeleted;

        public RBNode(T data)
        {
            this.data = data;
            _isDeleted = false;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public void setRed()
        {
            colour = RED;
        }

        public void setBlack()
        {
            colour = BLACK;
        }

        public bool setColour(bool c)
        {
            if (c != colour)
            {
                colour = c;
                return true;
            }
            return false;
        }

        public void setLeftChild(RBNode<T> node)
        {
            leftChild = node;
        }

        public void setRightChild(RBNode<T> node)
        {
            rightChild = node;
        }

        public void delete()
        {
            _isDeleted = true;
        }

        public T getData()
        {
            return data;
        }

        public bool isRed()
        {
            return colour == true;
        }

        public RBNode<T> getLeftChild()
        {
            return leftChild;
        }

        public RBNode<T> getRightChild()
        {
            return rightChild;
        }

        public bool isDeleted()
        {
            return _isDeleted;
        }

        public void display(int n)
        {
            string indent = "- ";

            for (int i = 1; i <= n; i++)
            {
                Console.Write(indent);
            }
            Console.WriteLine("Root: " + data + "\tColor: " + colour);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(indent);
            }

            Console.WriteLine("Left");
            if (leftChild == null)
            {
                for (int i = 1; i <= n + 1; i++)
                {
                    Console.Write(indent);
                }
            }
            else
            {
                leftChild.display(n + 1);
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write(indent);
            }

            Console.WriteLine("Right");
            if (rightChild == null)
            {
                for (int i = 1; i <= n + 1; i++)
                {
                    Console.Write(indent);
                }
            }
            else
            {
                rightChild.display(n + 1);
            }
        }
    }

    class RedBlackTree<T> where T : IComparable
    {
        private RBNode<T> root;

        private RBNode<T> put(RBNode<T> node, T data)
        {
            if (node == null)
            {
                RBNode<T> newNode = new RBNode<T>(data);
                return newNode;
            }

            int cmp = data.CompareTo(node.getData());

            if (cmp < 0)
            {
                node.setLeftChild(put(node.getLeftChild(), data));
            }
            else if (cmp > 0)
            {
                node.setRightChild(put(node.getRightChild(), data));
            }

            if (isRed(node.getLeftChild()) && isRed(node.getLeftChild().getLeftChild()))
            {
                node.setRed();
                node.getLeftChild().setBlack();
                node = rightRotation(node);
            }

            if (isRed(node.getRightChild()) && isRed(node.getRightChild().getRightChild()))
            {
                node.setRed();
                node.getRightChild().setBlack();
                node = leftRotation(node);
            }

            if (isRed(node.getLeftChild()) && isRed(node.getLeftChild().getRightChild()))
            {
                node.setRed();
                node.getLeftChild().getRightChild().setBlack();
                node.setLeftChild(leftRotation(node.getLeftChild()));
                node = rightRotation(node);
            }

            if (isRed(node.getRightChild()) && isRed(node.getRightChild().getLeftChild()))
            {
                node.setRed();
                node.getRightChild().getLeftChild().setBlack();
                node.setRightChild(rightRotation(node.getRightChild()));
                node = leftRotation(node);
            }

            colourFlip(node);
            return node;
        }

        private void colourFlip(RBNode<T> parent)
        {
            if (parent.getRightChild() == null || parent.getLeftChild() == null)
            {
                return;
            }

            if (!isRed(parent) && isRed(parent.getRightChild()) && isRed(parent.getLeftChild()))
            {
                if (parent != root)
                {
                    parent.setRed();
                }

                parent.getRightChild().setBlack();
                parent.getLeftChild().setBlack();
            }
        }

        private RBNode<T> rightRotation(RBNode<T> grandparent)
        {
            RBNode<T> parent = grandparent.getLeftChild();
            RBNode<T> rightChildOfParent = parent.getRightChild();

            parent.setRightChild(grandparent);
            grandparent.setLeftChild(rightChildOfParent);
            return parent;
        }

        private RBNode<T> leftRotation(RBNode<T> grandparent)
        {
            RBNode<T> parent = grandparent.getRightChild();
            RBNode<T> leftChildOfParent = parent.getLeftChild();

            parent.setLeftChild(grandparent);
            grandparent.setRightChild(leftChildOfParent);
            return parent;
        }

        private RBNode<T> containsx(T data)
        {
            RBNode<T> current = root;
            while (data.CompareTo(current.getData()) != 0)
            {
                if (data.CompareTo(current.getData()) < 0)
                {
                    current = current.getLeftChild();
                }
                else
                {
                    current = current.getRightChild();
                }

                if (current == null)
                {
                    return null;
                }
            }

            if (current.isDeleted())
            {
                return null;
            }

            return current;
        }

        private void displaySubtreeInOrder(RBNode<T> current)
        {
            if (current != null)
            {
                displaySubtreeInOrder(current.getLeftChild());
                Console.WriteLine("Data: " + current.getData() + "\tColor: " + (current.isRed() ? "Red" : "Black"));
                displaySubtreeInOrder(current.getRightChild());
            }
        }

        public RedBlackTree()
        {
            root = null;
        }

        public RBNode<T> getRoot()
        {
            return root;
        }

        public void add(T data)
        {
            root = put(root, data);
            root.setBlack();
        }

        public void remove(T data)
        {
            RBNode<T> node = containsx(data);

            if (node != null)
            {
                node.delete();
            }
        }

        public bool isRed(RBNode<T> node)
        {
            if (node == null)
            {
                return false;
            }
            return node.isRed();
        }

        public void print()
        {
            displaySubtreeInOrder(root);
        }

        public bool contains(T data)
        {
            return (containsx(data) != null);
        }
    }
}