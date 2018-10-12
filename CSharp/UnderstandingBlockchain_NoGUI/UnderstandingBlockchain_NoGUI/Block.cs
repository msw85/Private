using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBlockchain_NoGUI {
    class Block {
        int BlockIndex { get; set; }
        public string BlockHash { get; set; }
        string Timestamp { get; set; }
        string Ident { get; set; }
        public string PrevBlockHash { get; set; }

        private SHA256 Hash = SHA256.Create();
        private int _shaSalt;

        public Block(int blockIndex, string timestamp, string ident, string prevBlockHash) {
            BlockIndex = blockIndex;
            BlockHash = CalculateHash();
            Timestamp = timestamp;
            Ident = ident;
            PrevBlockHash = prevBlockHash;
            _shaSalt = 69;
        }

        public void MineBlock(int difficulty) {
            while(BlockHash.Substring(0, difficulty) != new string('0', difficulty)) {
                _shaSalt++;
                BlockHash = CalculateHash();
                Console.WriteLine("Currently mining: " + BlockHash);
            }

            Console.WriteLine("Block " + BlockHash + " have been mined!");
        }

        public string CalculateHash() {
            return GenerateHash(BlockIndex + PrevBlockHash + Timestamp + Ident + _shaSalt);
        }

        public override string ToString() {
            return Ident;
        }
        private string GenerateHash(string source) {
            StringBuilder stringBuilder = new StringBuilder();
            Encoding encoding = Encoding.UTF8;

            byte[] hashes = Hash.ComputeHash(encoding.GetBytes(source));

            foreach (byte hash in hashes) {
                stringBuilder.Append(hash.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
