﻿using System;

namespace PracticeQuestionsSharp.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTree<T> Insert(T data)
        {
            if (root == null) { root = new BinaryTreeNode<T>(data); }
            else Insert(data, root);
            return this;
        }

        private void Insert(T data, BinaryTreeNode<T> origin)
        {
            //TODO: if the value is the same add a linked list here that stores all equal values?
            if (data.CompareTo(origin.Data) < 0)
            {
                if (origin.Left == null) origin.Left = new BinaryTreeNode<T>(data);
                else Insert(data, origin.Left);
            }
            else
            {
                if (origin.Right == null) origin.Right = new BinaryTreeNode<T>(data);
                else Insert(data, origin.Right);
            }
        }

        public void Remove(T data)
        {
            Remove(data, root);
        }

        private BinaryTreeNode<T> Remove(T data, BinaryTreeNode<T> origin)
        {
            if (origin == null) return null;

            if (data.CompareTo(origin.Data) == -1)
            {
                return origin.Left = Remove(data, origin.Left);
            }

            if (data.CompareTo(origin.Data) == 1)
            {
                return origin.Right = Remove(data, origin.Right);
            }

            if (data.CompareTo(origin.Data) == 0)
            {
                if (origin.Left != null && origin.Right != null)
                {
                    var minimum = Minimum(origin.Right);

                    origin.Data = minimum;
                    return origin.Right = Remove(minimum, origin.Right);
                }
                if (origin.Left == null) return origin.Right;
                if (origin.Right == null) return origin.Left;

            }

            return null;
        }

        T Minimum(BinaryTreeNode<T> origin)
        {
            while (origin.Left != null) origin = origin.Left;
            return origin.Data;
        }

        public void PrintAll()
        {
            Print(root);
        }

        private void Print(BinaryTreeNode<T> origin)
        {
            if (origin.Left != null) Print(origin.Left);

            Console.WriteLine(origin.Data);

            if (origin.Right != null) Print(origin.Right);
        }

        public bool IsEmpty => root == null;
        private BinaryTreeNode<T> root;
    }

    class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data) { Data = data; }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }
}
