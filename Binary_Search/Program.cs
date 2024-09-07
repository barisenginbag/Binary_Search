using System;

class Node
{
    public int Data;
    public Node Left, Right;

    public Node(int item)
    {
        Data = item;
        Left = Right = null;
    }
}

class BinarySearchTree
{
    public Node Root;

    public BinarySearchTree()
    {
        Root = null;
    }

    // BST'ye eleman ekleme fonksiyonu
    public void Insert(int data)
    {
        Root = InsertRec(Root, data);
    }

    // Recursive (özyinelemeli) fonksiyon: Ağaca eleman ekleme işlemi
    Node InsertRec(Node root, int data)
    {
        // Ağaç boşsa yeni düğüm oluştur
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        // Veriyi uygun alt ağaca ekle
        if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }

        return root;
    }

    // BST'yi inorder sırada yazdırma fonksiyonu
    public void Inorder()
    {
        InorderRec(Root);
    }

    // Recursive (özyinelemeli) inorder yazdırma işlemi
    void InorderRec(Node root)
    {
        if (root != null)
        {
            InorderRec(root.Left);
            Console.Write(root.Data + " ");
            InorderRec(root.Right);
        }
    }

    // BST'yi preorder sırada yazdırma fonksiyonu
    public void Preorder()
    {
        PreorderRec(Root);
    }

    // Recursive (özyinelemeli) preorder yazdırma işlemi
    void PreorderRec(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Data + " ");
            PreorderRec(root.Left);
            PreorderRec(root.Right);
        }
    }

    // BST'yi postorder sırada yazdırma fonksiyonu
    public void Postorder()
    {
        PostorderRec(Root);
    }

    // Recursive (özyinelemeli) postorder yazdırma işlemi
    void PostorderRec(Node root)
    {
        if (root != null)
        {
            PostorderRec(root.Left);
            PostorderRec(root.Right);
            Console.Write(root.Data + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();

        // Verilen dizi
        int[] elements = { 7, 5, 1, 8, 3, 6, 0, 9, 4, 2 };

        // Elemanları ağaca ekle
        foreach (int element in elements)
        {
            tree.Insert(element);
        }

        // Ağaç yapısını yazdır
        Console.WriteLine("Inorder Traversal (Küçükten büyüğe): ");
        tree.Inorder();
        Console.WriteLine("\nPreorder Traversal (Kök-Öncelikli): ");
        tree.Preorder();
        Console.WriteLine("\nPostorder Traversal (Kök-Sonralı): ");
        tree.Postorder();

        Console.ReadKey();
    }
}
