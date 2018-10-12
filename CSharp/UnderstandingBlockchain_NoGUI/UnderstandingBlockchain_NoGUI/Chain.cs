using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBlockchain_NoGUI {
    class Chain {
        List<Block> _chain;
        public int Difficulty { get; set; }

        public Chain() {
            _chain = new List<Block>();
            _chain.Add(CreateGenesisBlock());
            Difficulty = 0;
        }
        public void MineAndAddBlock(Block block) {
            block.PrevBlockHash = GetLastBlock().BlockHash;
            block.MineBlock(Difficulty);

            _chain.Add(block);
        }

        public void Validate() {
            for(int i = 1; i < _chain.Count; i++) {
                Block currBlock = _chain[i];
                Block prevBlock = _chain[i-1];

                if(currBlock.BlockHash != currBlock.CalculateHash()) {
                    throw new Exception("Current hash not correct, chain is invalid!");
                }

                if (currBlock.PrevBlockHash != prevBlock.BlockHash) {
                    throw new Exception("Previous hash on current block does not match hash of previous block, chain is invalid!");
                }

            }

            Console.WriteLine("\n" + _chain.Count + " blocks OK, chain valid!");
        }

        public void PrintChain() {
            foreach (Block block in _chain) {
                Console.WriteLine(block.ToString());
            }
        }

        private Block CreateGenesisBlock() {
            return new Block(0, DateTime.Now.ToString("d"), "Genesis Block", "");
        }

        private Block GetLastBlock() {
            return _chain.Last();
        }
    }
}
