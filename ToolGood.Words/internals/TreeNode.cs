﻿using System.Collections.Generic;

namespace ToolGood.Words.internals
{
    public class TreeNode
    {
        #region Constructor & Methods

        public TreeNode(TreeNode parent, char c)
        {
            _char = c; _parent = parent;
            _results = new List<string>();

            _transitionsAr = new List<TreeNode>();
            _transHash = new Dictionary<char, TreeNode>();
        }

        public void AddResult(string result)
        {
            if (_results.Contains(result)) return;
            _results.Add(result);
        }

        public void AddTransition(TreeNode node)
        {
            _transHash.Add(node.Char, node);
            _transitionsAr.Add(node);
        }

        public TreeNode GetTransition(char c)
        {
            TreeNode tn;
            if (_transHash.TryGetValue(c, out tn)) { return tn; }
            return null;
        }

        public bool ContainsTransition(char c)
        {
            return _transHash.ContainsKey(c);
        }

        #endregion Constructor & Methods

        #region Properties

        private char _char;
        private TreeNode _parent;
        private TreeNode _failure;
        private List<string> _results;
        private List<TreeNode> _transitionsAr;
        private Dictionary<char, TreeNode> _transHash;

        public char Char
        {
            get { return _char; }
        }

        public TreeNode Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Failure function - descendant node
        /// </summary>
        public TreeNode Failure
        {
            get { return _failure; }
            set { _failure = value; }
        }

        /// <summary>
        /// Transition function - list of descendant nodes
        /// </summary>
        public List<TreeNode> Transitions
        {
            get { return _transitionsAr; }
        }

        /// <summary>
        /// Returns list of patterns ending by this letter
        /// </summary>
        public List<string> Results
        {
            get { return _results; }
        }

        #endregion Properties
    }
}