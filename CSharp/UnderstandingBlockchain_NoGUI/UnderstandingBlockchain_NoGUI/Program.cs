using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBlockchain_NoGUI {
    class Program {
        static void Main(string[] args) {
            Chain chain = new Chain();
            if (args.Count() != 0) {
                chain.Difficulty = Int32.Parse(args[0]);
            } else {
                chain.Difficulty = 2;
            }

            for (int i = 1; i < 100; i++) {
                Block block = new Block(i, DateTime.Now.ToString("d"), "Block #" + i, "");
                chain.MineAndAddBlock(block);
            }

            try {
                chain.Validate();
            }catch (Exception e) {
                Console.WriteLine("{0}", e);
            }
            
            if(Console.ReadLine().Equals("l")) {
                chain.PrintChain();
                Console.ReadKey();
            }
        }
    }
}
