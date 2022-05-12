using System;
using System.Collections;
using System.Collections.Generic;

namespace _11._Collections_and_Generics
{
    [Serializable]
    public class BynaryTree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        private TItem NodeData { get; set; }

        private BynaryTree<TItem> _leftTree;

        private BynaryTree<TItem> _rightTree;

        public BynaryTree(TItem nodeValue)
        {
            NodeData = nodeValue;
            _leftTree = null;
            _rightTree = null;
        }

        public void Insert(TItem newItem)
        {
            if (NodeData == null)
            {
                NodeData = newItem;
                return;
            }
            TItem currentNodeValue = NodeData;
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (_leftTree == null)
                {
                    _leftTree = new BynaryTree<TItem>(newItem);
                }
                else
                {
                    _leftTree.Insert(newItem);
                }
            }
            else
            {
                if (_rightTree == null)
                {
                    _rightTree = new BynaryTree<TItem>(newItem);
                }
                else
                {
                    _rightTree.Insert(newItem);
                }
            }
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            if (_leftTree != null)
            {
                foreach (TItem tree in _leftTree)
                {
                    yield return tree;
                }
            }

            yield return NodeData;

            if (_rightTree != null)
            {
                foreach (TItem tree in _rightTree)
                {
                    yield return tree;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
