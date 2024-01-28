using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestHard
{
    public class Node
    {

        public int value;
        //public Dictionary<int, Node> neighbours = new Dictionary<int, Node>();
        public Dictionary<int, int> costs = new Dictionary<int, int>();

        public List<Node> neighbours = new List<Node>();
        //public List<int> costs = new();

        public Node(int value) => this.value = value;
    }
}
